using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLayer.DataEntity
{
    public class TransactionRecords
    {
        public TransactionRecords()
        {
            Flag = 0;
            countNo = 1;
        }

        public int Flag { get; set; }
        public string deviceId { get; set; }
        public string channelId { get; set; }

        //购买数量 目前缺省为1 int
        public int countNo { get; set; }

        //购买金额 decimal(7,2)
        public double payFee { get; set; }

        //支付类型 nvarchar(50)
        public string payType { get; set; }

        //支付流水号（UWP生成） varchar(30)
        public string payBatchNo { get; set; }

        //交易时间 （UWP本地生成）datetime
        public DateTime transactionTime { get; set; }
    }
}
