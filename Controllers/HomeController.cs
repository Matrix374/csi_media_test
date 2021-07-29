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

        public async Task<String> GetNumberService(){
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Number/GetNumbers/");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Debug.WriteLine(responseBody);
                    return responseBody;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(String.Format("Message :{0}", e.Message));
            }

            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string GetNumbers(int? id = 2)
        {
            //GetDataFromDatabase
            var data = _dbContext.SortedNumModel.Find(id);
            return JsonSerializer.Serialize(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
