using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class hotelRoom
    {
        public string Rid { get; set; }//酒店客房编号
        public string Hid { get; set; }//酒店编号
        public string Tid{ get; set; }//客房类型编号
        public int Rnumber { get; set; }//客房数量
        public double Rprice { get; set; }//每晚价格
        public string Rremark { get; set; }//酒店客房备注
        public int RvacantNum { get; set; }//可预约的空房数量
        public string RimageUrl { get; set; }//酒店客房本地图片地址
    }
}