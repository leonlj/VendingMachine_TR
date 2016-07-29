using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer.DataEntity
{
    public class Channelinfo
    {
        public string deviceId { get; set; }
        public string channelId { get; set; }
        public string skuId { get; set; }
        public string skuName { get; set; }
        public string productImageUrl { get; set; }
        public string listPrice { get; set; }
        public string discountPrice { get; set; } 
    }
}
