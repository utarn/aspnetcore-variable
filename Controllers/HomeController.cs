using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetcore_variable.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace aspnetcore_variable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MySettings _mySettings;
        public HomeController(ILogger<HomeController> logger,
                            // Method 1
                            //   IConfiguration configuration
                            // Method 2
                            // IOptions<MySettings> mySettings
                            // Method 3
                            MySettings mySettings
                              )
        {
            _logger = logger;
            // Method 1
            // _mySettings = new MySettings();
            // // configuration.GetSection("MyGlobal:MySettings")
            // configuration.GetSection("MySettings").Bind(_mySettings);
            // Method 2
            // _mySettings = mySettings.Value;
            // Method 3
            _mySettings = mySettings;
        }

        public IActionResult Index()
        {
            ViewData["Value"] = _mySettings.Value;
            ViewData["Secret"] = _mySettings.Secret;
            return View();
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
