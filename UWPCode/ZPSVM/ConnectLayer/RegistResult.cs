using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer
{
    public class RegistResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string DeviceId { get; set; }
        public string DeviceKey { get; set; }
    }
}
