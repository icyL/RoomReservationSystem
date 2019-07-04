using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 网上订房系统.App_Code
{
    public class Type
    {
        //查询是否添加过客房类型编号
        public bool IdisAdded(string id/*客房类型编号*/)
        {
            string sql = "select Tid from RoomType where Tid='" + id + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//已存在
                return true;
            }
            else
                return false;
        }

        //查询是否添加过客房类型
        public bool TypeisAdded(string type/*客房类型名*/)
        {
            string sql = "select Ttype from RoomType where Ttype='" + type + "'";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            if (table.Rows.Count > 0)
            {//已存在
                return true;
            }
            else
                return false;
        }


        //根据类型编号查询客房类型
        public string searchRoomType(string id/*客房类型编号*/)
        {
            string sql = "select Ttype from RoomType where Tid='" + id + "'";
            string type = DatabaseLink.GetSingleData(sql);//将查询结果存于table表中
            return type;
        }


        //查询全部客房类型,显示在客房类型管理界面
        public DataTable searchRoomType()
        {
            string sql = "select * from RoomType order by Tid asc";
            DataTable table = DatabaseLink.GetData(sql);//将查询结果存于table表中
            return table;
        }

        //添加客房类型
        public bool addRoomType(roomType t/*客房类型对象*/)
        {
            string sql = "insert into RoomType values('" + t.Tid + "','" + t.Ttype + "'," + t.TbedNum + ",'" +t.TairConditioning 
                + "','" + t.Ttelevision + "','" + t.ThairDrier + "','" + t.Tlandline + "','" + t.Twifi + "','" + t.Tremark + "')";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }       

        //修改客房类型信息
        public bool updateRoomType(roomType t, string id/*客房类型编号*/)
        {
            string sql = "update RoomType set Ttype='" + t.Ttype + "',TbedNum=" + t.TbedNum + ",TairConditioning='" + t.TairConditioning 
                + "',Ttelevision='" + t.Ttelevision+ "',ThairDrier='" + t.ThairDrier + "',Tlandline='" + t.Tlandline + "',Twifi='" + t.Twifi
                + "',Tremark='" + t.Tremark + "' where Tid='" + id + "'";
            int num = DatabaseLink.UpdateData(sql);
            if (num > 0)
                return true;
            else
                return false;
        }

        //删除客房类型信息
        public bool deleteRoomType(string id/*客房类型编号*/)
        {
            string sql = "delete from RoomType where Tid='" + id + "'";
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