using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// DatabaseLink 的摘要说明
/// </summary>
public class DatabaseLink
{
    public DatabaseLink()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    //连接数据库
    public static MySqlConnection GetDataLink()
    {
        string str = "Server=127.0.0.1;User ID=root;Password=;Database=room_reservation;CharSet=utf8;";
        MySqlConnection con = new MySqlConnection(str);//实例化链接
        return con;
    }

    //获取信息并填充到数据集
    public static DataTable GetData(string sql)
    {
        MySqlConnection con = GetDataLink();
        con.Open();//开启连接
        MySqlCommand cmd = new MySqlCommand(sql, con);
        MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        ada.Fill(ds);//查询结果填充数据集
        con.Close();//关闭连接
        return ds;
    }

    //获取某个字段的值
    public static string GetSingleData(string sql)
    {
        MySqlConnection con = GetDataLink();
        con.Open();//开启连接
        MySqlCommand cmd = new MySqlCommand(sql, con);
        MySqlDataReader reader = cmd.ExecuteReader();
        string value;
        if (reader.Read())
            value = reader.GetString(0);
        else
            value = null;
        con.Close();//关闭连接
        return value;
    }

    //更改信息
    public static int UpdateData(string sql)
    {
        MySqlConnection con = GetDataLink();
        MySqlCommand cmd = new MySqlCommand(sql, con);
        con.Open();
        int num = cmd.ExecuteNonQuery();
        con.Close();
        return num;
    }
}
   