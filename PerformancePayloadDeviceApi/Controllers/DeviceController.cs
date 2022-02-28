using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PerformancePayloadDeviceApi.Models;
using PerformancePayloadDeviceApi.Services;
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
            DeviceService ds = new DeviceService(_configuration);
            var b=ds.GetAllDevices();
            return new JsonResult(b);
        }
        [HttpGet("dev")]
        public ActionResult GetDevice(int Dev)
        {
            DeviceService ds = new DeviceService(_configuration);
            var result=ds.deviceById(Dev);
            return new JsonResult(result);
           
        }
        
    }
}
