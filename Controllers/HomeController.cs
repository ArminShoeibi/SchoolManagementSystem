using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolMgmtContext _db;

        public HomeController(SchoolMgmtContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
