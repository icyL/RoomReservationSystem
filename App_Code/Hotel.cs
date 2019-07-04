using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class Hotel
    {
        //查询全部酒店信息,显示在酒店信息查询界面
        public DataTable searchHotelInfo()
        {
            string sql = "select * from HotelInfo order by Hid asc";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //根据酒店所在省市和酒店名称模糊查询
        public DataTable searchHotelByKey(string province/*酒店所在省市*/, string name/*酒店名称*/)
        {
            string sql = "select * from HotelInfo where Hprovince like '%" + province + "%' and Hname like '%" + name + "%'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //根据酒店编号查询酒店信息，显示在酒店客房信息管理页面
        public DataTable searchHotelById(string id/*酒店编号*/)
        {
            string sql = "select * from HotelInfo where Hid='"+id+"'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //查询酒店编号是否已存在
        public bool IdisExisted(string id/*酒店编号*/)
        {
            string sql = "select Hid from HotelInfo where Hid = '" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//该酒店客房编号已存在
                return true;
            }
            else
                return false;
        }

        //添加酒店信息
        public bool addHotelInfo(hotelInfo h/*酒店信息对象*/)
        {
            string sql = "insert into HotelInfo values('" + h.Hid + "','" + h.Hname + "','" + h.Hprovince + "','" + h.Haddress
                + "'," + h.Hprice + ",'" + h.Hcontact + "','" + h.Hintroduce + "','" + h.HimageUrl +  "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //修改酒店信息
        public bool updateHotelInfo(hotelInfo h, string id/*酒店编号*/)
        {
            string sql = "update HotelInfo set Hname='" + h.Hname + "',Hprovince='" + h.Hprovince + "',Haddress='" + h.Haddress
               + "',Hprice=" + h.Hprice + ",Hcontact='" + h.Hcontact + "',Hintroduce='" + h.Hintroduce + "',HimageUrl='" + h.HimageUrl
               + "'  where Hid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //删除酒店信息
        public bool deleteHotelInfo(string id/*酒店编号*/)
        {
            string sql = "delete from HotelInfo where Hid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}