using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class roomType
    {
        public string Tid { get; set; }//房间类型编号
        public string Ttype { get; set; }//房间类型名称
        public int TbedNum { get; set; }//床位数
        public string TairConditioning { get; set; }//空调有无
        public string Ttelevision { get; set; }//电视机有无
        public string ThairDrier { get; set; }//吹风机有无
        public string Tlandline { get; set; }//座机电话有无
        public string Twifi{ get; set; }//无线网络有无
        public string Tremark { get; set; }//备注
    }
}