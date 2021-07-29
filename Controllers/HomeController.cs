using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csi_media_test.Models;
using csi_media_test.Data;

namespace csi_media_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly csiDBContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, csiDBContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await GetNumberService();
            ViewData["numbers"] = data;
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
