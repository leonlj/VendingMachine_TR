using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer.DataEntity
{
    [KnownType(typeof(AddProductsRecords))]
    public class AddProductsRecords
    {
        public AddProductsRecords()
        {
            Flag = 1;
        }
        public int Flag { get; set; }


        //自贩机Id varchar(30)
        public string deviceId { get; set; }

        //货道号 （1-24） varchar(30)
        public string channelId { get; set; }

        // 补货数量  int
        public int addProductNo { get; set; }

        //补货时间 （UWP本地生成）datetime
        public DateTime addTime { get; set; }
    }
}
