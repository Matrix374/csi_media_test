using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using csi_media_test.Models;
using csi_media_test.Data;
using csi_media_test.Logic;

namespace csi_media_test.Controllers
{
    public class NumberController : Controller
    {
        private readonly csiDBContext _dbContext;
        private readonly ILogger<NumberController> _logger;
        private DatabaseService _databaseService = new DatabaseService();

        public NumberController(ILogger<NumberController> logger, csiDBContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        public string GetNumbers(int? id)
        {
            var data = _dbContext.SortedNumModel.Find(id);
            //Not Implemented: Convert DBO_SortedNumModel to SortedNumModel
            return JsonSerializer.Serialize(data);
        }

        [HttpGet]
        public string GetAllNumbers()
        {
            DbSet<DBO_SortedNumModel> data = _dbContext.Set<DBO_SortedNumModel>();
            //Not Implemented: Convert DBO_SortedNumModel to SortedNumModel
            List<SortedNumModel> dataset = new List<SortedNumModel>();
            foreach(var dbo in data)
            {
                SortedNumModel temp = _databaseService.ConvertToSortedNum(dbo);
                dataset.Add(temp);
            }

            var array = dataset.ToArray();
            //SortedNumModel data = _databaseService.ConvertToSortedNum(temp);
            return JsonSerializer.Serialize(array);
        }

        [HttpPost]
        public IActionResult PostNumbers([FromBody] SortedNumModel data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            //Convert SortedNumModel to DBO_SortedNumModel
            DBO_SortedNumModel db_data = _databaseService.ConvertToDBO(data);
            //save SortedNum to database
            try
            {
                Debug.WriteLine(db_data);
                Debug.WriteLine(JsonSerializer.Serialize(db_data));
                _dbContext.SortedNumModel.Add(db_data);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok();
        }
    }
}
