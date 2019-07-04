using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class orderInfo
    {
        public string Oid { get; set; }//订单号
        public DateTime OorderDate { get; set; }//提交日期
        public string Uid { get; set; }//客户身份证号，外键
        public string Hid { get; set; }//酒店编号，外键
        public string Tid { get; set; }//客房类型编号，外键
        public int Onumber{ get; set; }//预订数量
        public DateTime OcheckInDate { get; set; }//入住日期
        public int OstayDuration { get; set; }//入住时长
        public double Oprice { get; set; }//应付金额
    }
}