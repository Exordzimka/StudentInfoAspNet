using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentInfoAspNet.Models;
using StudentInfoAspNet.Repositories.Implementation;

namespace StudentInfoAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupRepository _groupRepository = new GroupRepository();
        private readonly StudentRepository _studentsRepository = new StudentRepository();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.TopStudents = _studentsRepository.GetTop().Result;
            ViewBag.TopGroups = _groupRepository.GetTop().Result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}