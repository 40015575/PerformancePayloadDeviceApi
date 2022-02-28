using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PerformancePayloadDeviceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformancePayloadDeviceApi.Services
{
    public class DeviceService
    {
        private readonly IConfiguration _configuration;
        public DeviceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
     
        public List<Device> deviceById(int Id)
        {
            MongoClient db = new MongoClient(_configuration.GetConnectionString("MongoDBConnection"));

            var a = db.GetDatabase("config").GetCollection<Device>("device").AsQueryable().Where(m => m.MyId.Equals(Id)).ToList<Device>();

            return a;
        }
        public List<Device> GetAllDevices()
        {
        MongoClient db = new MongoClient(_configuration.GetConnectionString("MongoDBConnection"));

        var b = db.GetDatabase("config").GetCollection<Device>("device").AsQueryable().ToList<Device>();


            return b;
        }
}
}
