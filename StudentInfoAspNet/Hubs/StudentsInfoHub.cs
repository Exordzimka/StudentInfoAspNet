using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using StudentInfoAspNet.Models;
using StudentInfoAspNet.Repositories.Implementation;

namespace StudentInfoAspNet.Hubs
{
    public class StudentsInfoHub : Hub
    {
        GroupRepository _groupsRepository;
        StudentRepository _studentsRepository;

        public StudentsInfoHub()
        {
            _groupsRepository = new GroupRepository();
            _studentsRepository = new StudentRepository();
        }
        
        public async Task SendGroup(Dictionary<string, string> groupProperties)
        {
            var title = groupProperties["Title"];
            var curatorFamily = groupProperties["CuratorFamily"];
            var titleDirection = groupProperties["TitleDirection"];
            _groupsRepository.Create(new Groups{Title = title, CuratorFamily = curatorFamily, TitleDirection = titleDirection});
            await Clients.All.SendAsync(Method.ReceiveGroups.ToString(), _groupsRepository.GetAll());
        }

        public async Task SendStudent(Dictionary<string, string> studentProperties)
        {
            var name = studentProperties["Name"];
            var secondName = studentProperties["SecondName"];
            var lastName = studentProperties["LastName"];
            var averageScore = int.Parse(studentProperties["AverageScore"]);
            var group = _groupsRepository.GetById(int.Parse(studentProperties["GroupId"])).Result;
            _studentsRepository.Create(new Students{Name = name, SecondName = secondName, LastName = lastName, AverageScore = averageScore, GroupId = group.Id});
            group.AverageScore = getAverageGroupScore(group);
            _groupsRepository.Update(group);
            await ReceiveStudents();
            await ReceiveGroups();
            await ReceiveTopGroups();
            await ReceiveTopStudents();
        }

        private double getAverageGroupScore(Groups groups)
        {
            var students = _studentsRepository.GetAll().Result.Where(student => student.GroupId == groups.Id).ToList();
            var countOfStudentsInGroup = students.Count;
            var summAverageStudentScore = students.Select(student => student.AverageScore).Sum();
            Console.WriteLine(summAverageStudentScore);
            return summAverageStudentScore/countOfStudentsInGroup;
        }

        public async Task ReceiveGroups()
        {
            var method = Method.ReceiveGroups;
            await Clients.All.SendAsync(method.ToString(), _groupsRepository.GetAll().Result);
        }

        public async Task ReceiveStudents()
        {
            var method = Method.ReceiveStudents;
            var students = _studentsRepository.GetAll().Result;
            students.ForEach(student => student.Group = _groupsRepository.GetById(student.GroupId).Result);
            await Clients.All.SendAsync(method.ToString(), students);
        }
        
        public async Task ReceiveTopGroups()
        {
            var method = Method.ReceiveTopGroups;
            await Clients.All.SendAsync(method.ToString(), _groupsRepository.GetTop().Result);
        }

        public async Task ReceiveTopStudents()
        {
            var method = Method.ReceiveTopStudents;
            await Clients.All.SendAsync(method.ToString(), _studentsRepository.GetTop().Result);
        }

        private enum Method
        {
            ReceiveGroups,
            ReceiveStudents,
            ReceiveTopGroups,
            ReceiveTopStudents
        }
    }
}