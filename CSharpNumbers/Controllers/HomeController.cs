using CSharpNumbers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpNumbers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(NumRes nums)
        {
            List<string> numItems = new List<string>();
            //var numItems2 = new List<string>();

            for (int i = nums.StartValue; i <= nums.EndValue; i++)
            {
                numItems.Add(i.ToString());
            }

            nums.Results = numItems;

            return View(nums);

        }
        
        // get action
        public IActionResult App()
        {
            NumRes nums = new NumRes();
            nums.StartValue = 1;
            nums.EndValue = 100;
            return View(nums);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
