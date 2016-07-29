using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer.DataEntity
{
    public class VMStatusRecords
    {
        public VMStatusRecords()
        {
            Flag = 2;
            healthFlag = "HEALTH";
        }
        public int Flag { get; set; }

        //自贩机ID varchar(30)
        public string deviceId { get; set; }
        //环境温度 varchar(30)
        public string temperature { get; set; }
        //电压差 （UWP 生成）float
        public double voltDrop { get; set; }
        //功耗 （UWP生成）float
        public double powerDraw { get; set; }
        //负载 （UWP生成）float
        public double dutyCycle { get; set; }
        //健康状态 （正常，异常）nvarchar(50)
        public string healthFlag { get; set; }
        //提交时间 （UWP本地生成）datetime
        public DateTime addDate { get; set; }

    }
}
