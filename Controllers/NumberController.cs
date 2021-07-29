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
    public class NumberController : Controller
    {
        private readonly csiDBContext _dbContext;
        private readonly ILogger<NumberController> _logger;

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
    }
}
