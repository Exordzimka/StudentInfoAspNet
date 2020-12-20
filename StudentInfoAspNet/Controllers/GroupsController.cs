using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAspNet.Models;
using StudentInfoAspNet.Repositories.Implementation;

namespace StudentInfoAspNet.Controllers
{
    public class GroupsController : Controller
    {
        private readonly GroupRepository _groupRepository = new GroupRepository();
        private readonly StudentRepository _studentsRepository = new StudentRepository();
        public IActionResult Index()
        {
            ViewBag.TopStudents = _studentsRepository.GetTop().Result;
            ViewBag.TopGroups = _groupRepository.GetTop().Result;
            ViewBag.Groups = _groupRepository.GetAll().Result;
            return View();
        }

        [HttpPost] 
        public void AddGroup([FromForm]string title, string curatorFamily, string titleDirection, double averageScore)
        {
            _groupRepository.Create(new Groups{CuratorFamily = curatorFamily, Title = title, 
                TitleDirection = titleDirection, AverageScore = averageScore});
            
        }

        public IList<Groups> GetGroups()
        {
            return _groupRepository.GetAll().Result;
        }

        public IList<Groups> GetTopGroups()
        {
            return _groupRepository.GetTop().Result;
        }
    }
}