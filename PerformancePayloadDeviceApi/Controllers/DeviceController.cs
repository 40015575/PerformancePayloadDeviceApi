using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PerformancePayloadDeviceApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PerformancePayloadDeviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DeviceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetAsync()
        {
            MongoClient db = new MongoClient(_configuration.GetConnectionString("MongoDBConnection"));

            var a = db.GetDatabase("config").GetCollection<Device>("device").AsQueryable();
            return new JsonResult(a);
        }
        [HttpGet("dev")]
        public ActionResult GetDevice(int Dev)
        {
           
            MongoClient db = new MongoClient(_configuration.GetConnectionString("MongoDBConnection"));
            var result = db.GetDatabase("config").GetCollection<Device>("device").AsQueryable();

            var Dev1=Dev.ToString();


            if (!string.IsNullOrEmpty(Dev1))
            {
                result = result.Where(m => m.MyId.Equals(Dev));
                return new JsonResult(result);
            }
            else
                return NotFound();

            


        }
        
    }
}
