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
                //_constr.Members.Add(mem);
                //_constr.SaveChanges();
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

        public IActionResult CheckName(string name, int age)
        {
            Member mem = _constr.Members.FirstOrDefault(p => p.Name == name || p.Age == age);
            if(mem != null)
            {
                return Content("有找到這個人~", "text/plain", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("沒有找到這個人~", "text/plain", System.Text.Encoding.UTF8);
            }
            
        }
    }
}
