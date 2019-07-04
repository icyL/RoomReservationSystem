using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class hotelInfo
    {
        public string Hid { get; set; }//酒店编号
        public string Hname { get; set; }//酒店名称
        public string Hprovince { get; set; }//所处省市
        public string Haddress { get; set; }//详细地址
        public double Hprice { get; set; }//价位
        public string Hcontact { get; set; }//酒店联系方式
        public string Hintroduce { get; set; }//相关介绍
        public string HimageUrl { get; set; }//酒店图片本地地址

    }
}