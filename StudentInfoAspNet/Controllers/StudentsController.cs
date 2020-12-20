using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAspNet.Models;
using StudentInfoAspNet.Repositories.Implementation;
using Microsoft.AspNetCore.SignalR;

namespace StudentInfoAspNet.Controllers
{
    public class StudentsController : Controller
    {
        private readonly GroupRepository _groupRepository = new GroupRepository();
        private readonly StudentRepository _studentsRepository = new StudentRepository();

        public IActionResult Index()
        {
            ViewBag.TopStudents = _studentsRepository.GetTop().Result;
            ViewBag.TopGroups = _groupRepository.GetTop().Result;
            ViewBag.Students = _studentsRepository.GetAll();
            return View();
        }

        [HttpPost]
        public void AddStudent([FromForm] string name, string secondName, string lastName, int groupId)
        {
            
        }
        
        public IList<Students> GetStudents()
        {
            return _studentsRepository.GetAll().Result;
        }

        public IList<Students> GetTopStudents()
        {
            return _studentsRepository.GetTop().Result;
        }
    }
}