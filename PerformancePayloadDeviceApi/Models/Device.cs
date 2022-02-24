using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace PerformancePayloadDeviceApi.Models
{

    public class Device
    {
        [JsonIgnore]
        public ObjectId Id { get; set; }
        public int MyId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DeviceProperty { get; set; }
        public string Desc { get; set; }
    }

   
}
