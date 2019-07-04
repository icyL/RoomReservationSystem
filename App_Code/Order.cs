using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class Order
    {
        //查询全部订单,显示在客户订单管理界面，多表连接查询
        public DataTable searchUserOrderInfo()
        {
            string sql = "select UserOrderInfo.*, HotelInfo.* , Ttype, Uname, Laccount from " +
                "UserOrderInfo, HotelInfo , RoomType , UserInfo , LoginInfo where UserOrderInfo.OhotelId = HotelInfo.Hid" +
                " and UserOrderInfo.OtypeId = RoomType.Tid and UserOrderInfo.OcardId = UserInfo.Uid and "+
                " UserOrderInfo.OcardId = LoginInfo.Lid order by Oid asc";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //查询个人订单,显示在我的订单页面
        public DataTable searchPersonalOrderInfo(string id/*用户身份证号*/)
        {
            string sql = "select UserOrderInfo.*, HotelInfo.* , RoomType.* from " +
                "UserOrderInfo, HotelInfo , RoomType  where UserOrderInfo.OhotelId = HotelInfo.Hid" +
                " and UserOrderInfo.OtypeId = RoomType.Tid and UserOrderInfo.OcardId = '"+id+ "' order by Oid asc";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }
      

        //根据客户身份证号查询订单，显示在客户订单管理页面
        public DataTable searchUserOrderInfo(string id/*身份证号码*/)
        {
            string sql = "select UserOrderInfo.*, HotelInfo.* , Ttype, Uname, Laccount from " +
                "UserOrderInfo, HotelInfo , RoomType , UserInfo , LoginInfo where UserOrderInfo.OhotelId = HotelInfo.Hid" +
                " and UserOrderInfo.OtypeId = RoomType.Tid and UserOrderInfo.OcardId = UserInfo.Uid and " +
                " UserOrderInfo.OcardId = LoginInfo.Lid and OcardId ='" + id + "'";
            DataTable ds = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return ds;
        }

        //根据身份证号查询客户姓名，显示在要填写的订单上
        public string searchUserName(string id/*身份证号码*/)
        {
            string sql = "select Uname from UserInfo where Uid='" + id + "'";
            string username = DatabaseLink.GetSingleData(sql);//将查询结果存于table表中
            return username;
        }

        //根据身份证号查询客户手机号码，显示在订单上
        public string searchTelephone(string id/*身份证号码*/)
        {
            string sql = "select Laccount from LoginInfo where Lid='" + id + "'";
            string telephone = DatabaseLink.GetSingleData(sql);//将查询结果存于table表中
            return telephone;
        }

        //添加个人订单
        public bool addOrderInfo(orderInfo d/*个人订单对象*/)
        {
            string sql = "insert into UserOrderInfo values('" + d.Oid + "','" + d.OorderDate + "'," + d.Uid + ",'" + d.Hid + "','"
                + d.Tid + "','" + d.Onumber + "','" + d.OcheckInDate + "','" + d.OstayDuration + "','" + d.Oprice + "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
}