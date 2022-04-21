using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjAjaxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjAx.Controllers
{
    public class ApiController : Controller
    {
         private readonly DemoContext _constr;

        public ApiController(DemoContext constr)
        {
            _constr = constr;
        }

        public IActionResult Index(string Name, int Age)
        {
            //System.Threading.Thread.Sleep(5000);

            var data = _constr.Members.FirstOrDefault(m => m.Name == Name && m.Age == Age);
            if (data != null)
            {
                Member mem = new Member();
                mem.Name = Name;
                mem.Age = Age;
                _constr.Members.Add(mem);
                _constr.SaveChanges();
                return Content($"Hello { Name }, You are { Age } years old.", "text/plain", System.Text.Encoding.UTF8);
            }
            else
            {
                return View();
            }

            //if (string.IsNullOrEmpty(Name))
            //{
            //    Name = "Ajax";
            //    Age = 5;
            //}
            //return Content($"Hello { Name }, You are { Age } years old.", "text/plain", System.Text.Encoding.UTF8);
        }
    }
}
