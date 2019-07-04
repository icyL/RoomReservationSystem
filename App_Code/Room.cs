using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class Room
    {
        //根据酒店编号查询酒店客房信息，酒店客房信息表和客房类型表连接查询，显示在酒店信息管理页面
        public DataTable searchHotelRoomById(string id/*酒店编号*/)
        {
            string sql = "select HotelRoomInfo.* , RoomType.*  from HotelRoomInfo ,RoomType where HotelRoomInfo.RtypeId = RoomType.Tid and RhotelId='" + id + "' order by Rid asc ";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //查询酒店客房类型
        public string searchHotelRoomType(string id/*酒店客房编号*/)
        {
            string sql = "select Ttype from RoomType , HotelRoomInfo  where HotelRoomInfo.RtypeId = RoomType.Tid and Rid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            string type = table.Rows[0][0].ToString();//取table表中的查询结果  
            return type;
        }

        //查询酒店客房编号是否已存在
        public bool IdisExisted(string id/*客房编号*/)
        {
            string sql = "select Rid from HotelRoomInfo where Rid = '" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//该酒店客房编号已存在
                return true;
            }
            else
                return false;
        }

        //查询是否有要添加的客房类型
        public bool TypeisExisted(string type/*客房类型*/)
        {
            string sql = "select Ttype from RoomType where Ttype = '" + type + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//该客房类型已存在
                return true;
            }
            else
                return false;
        }

        //根据客房类型查询客房类型编号
        public string searchRoomTypeId(string type)
        {
            string sql_0 = "select Tid from RoomType where Ttype='" + type + "'";
            DataTable table = DatabaseLink.GetData(sql_0);//将查询结果存于table表中
            string id = table.Rows[0][0].ToString();//取table表中的查询结果
            return id;//返回客房类型编号         
        }


        //添加酒店客房信息
        public bool addHotelRoomInfo(hotelRoom hr/*酒店客房信息对象*/)
        {
            string sql = "insert into HotelRoomInfo values('" + hr.Rid + "','" + hr.Hid + "','" + hr.Tid + "'," + hr.Rnumber
                + "," + hr.Rprice + ",'" + hr.Rremark + "',"+ hr.RvacantNum + ",'" + hr.RimageUrl + "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0) 
                return true;
            else
                return false;
        }

        //修改酒店客房信息
        public bool updateHotelRoomInfo(hotelRoom hr, string id/*酒店客房编号*/)
        {
            string sql = "update HotelRoomInfo set RhotelId='" + hr.Hid + "',RtypeId='" + hr.Tid + "',Rnumber=" + hr.Rnumber+ ",Rprice=" + hr.Rprice 
                + ",Rremark='" + hr.Rremark + "',RvacantNum=" + hr.RvacantNum + ",RimageUrl='" + hr.RimageUrl + "'  where Rid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //删除酒店客房信息
        public bool deleteHotelRoomInfo(string id/*酒店客房编号*/)
        {
            string sql = "delete from HotelRoomInfo where Rid='" + id + "'";
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

        //修改空房数量
        public bool updateVacantNum(int vacantNum/*当前空房数量*/, string id/*酒店客房编号*/)
        {
            string sql = "update HotelRoomInfo set RvacantNum=" + vacantNum + "  where Rid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
}