using Microsoft.AspNetCore.Mvc;
using prjAjaxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjaxDemo.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly DemoContext _constr;

        public HomeworkController(DemoContext constr)
        {
            _constr = constr;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Member(string name)
        {
            var datas = _constr.Members.Where(m => m.Name == name).FirstOrDefault();
            if (datas != null)
            {

                return RedirectToAction("Member", "Homework");
            }
            else
            {
                return RedirectToAction("Home", "Homework");
            }
        }
    }
}
