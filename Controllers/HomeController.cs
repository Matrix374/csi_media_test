using System;
using System.Text.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using csi_media_test.Logic;
using csi_media_test.Models;
using csi_media_test.Data;

namespace csi_media_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly csiDBContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        public NumberLogic _numberLogic = new NumberLogic();

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

        public async Task<IActionResult> RetrieveAllNumbers()
        {
            var data = await GetNumberService();
            ViewData["numbers"] = data;
            return View("NumbersJSON");
        }

        public async Task<IActionResult> RetrieveNumber(int id)
        {
            var data = await GetNumberService(id);
            ViewData["numbers"] = data;
            return View("NumbersJSON");
        }

        public async Task<String> GetNumberService(){
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Number/GetAllNumbers/");
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

        public async Task<String> GetNumberService(int id){
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://localhost:5001/Number/GetNumbers/" + id);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> OnPost(){
            int numbers = Convert.ToInt32(Request.Form["number_input"]);
            string sortType = Request.Form["sort_type_input"];
            int[] sortedNum;
            ViewData["Success"] = false;

            if(sortType == "Ascending")
            {
                sortedNum = _numberLogic.SortNumbersAscending(numbers);
            } else if(sortType == "Descending")
            {
                sortedNum = _numberLogic.SortNumbersDescending(numbers);
            } else{
                sortedNum = null;
                throw new Exception("No SortType");
            }

            SortedNumModel data = new SortedNumModel{
                Number = sortedNum,
                SortType = sortType
            };

            try
            {
                var content = JsonSerializer.Serialize(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var client = new HttpClient())
                {
                    HttpResponseMessage result = await client.PostAsync("https://localhost:5001/Number/PostNumbers/", byteContent);
                    result.EnsureSuccessStatusCode();

                    ViewData["Success"] = true;
                }
            } catch (HttpRequestException e) 
            {
                Console.WriteLine(String.Format("Message :{0}", e.Message));
            }
            
            return View("Index");
        }
        }
    }
}
