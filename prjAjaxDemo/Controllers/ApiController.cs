using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjAjAx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjAx.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index(string name, string age)
        {
            System.Threading.Thread.Sleep(5000);
            if(string.IsNullOrEmpty(name))
            {
                name = "Ajax";
                age = "5";
            }
            return Content($"Hello { name }, You are { age } years old.", "text/plain", System.Text.Encoding.UTF8);//System.Text.Encoding.UTF8 避免傳中文為亂碼
        }
    }
}
