using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class OnlineBooking : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder(); //创建一个实例
            DataTable table = hotel.searchHotelInfo();//查询到的内容
            if (table != null && table.Rows.Count > 0) //判断是否有数据
            {
                str.Append("<ul>");
                for (int i = 0; i < table.Rows.Count; i++) //将数据库表中的数据循环赋给str
                {
                    //将数据库表中值赋给新的变量
                    string id = table.Rows[i]["Hid"].ToString();//酒店编号，需要传值到客户填写订单页面
                    string name = table.Rows[i]["Hname"].ToString();//酒店名称
                    string province = table.Rows[i]["Hprovince"].ToString();//所处省市
                    string price = table.Rows[i]["Hprice"].ToString();//价位
                    string imageUrl = table.Rows[i]["HimageUrl"].ToString();//酒店本地图片地址，需要传值到客户填写订单页面

                    str.Append("<li>"); //li标签
                    str.Append("<a href='./RoomReservation.aspx?HotelId=" + id + "&HotelImgUrl=" + imageUrl + "'>"); //a标签,顺便将酒店编号进行带参传值到要跳转的页面
                    str.Append("<img id='image" + i + "' runat = 'server' alt='' src='../../images/" + imageUrl + "' />"); //img标签
                    str.Append("<label id='label" + i + "' runat = 'server'>");//lable标签
                    str.Append(name + "&nbsp;&nbsp;价位:" + price + "<br/>" + province);//酒店简介
                    str.Append("</label > ");
                    str.Append("</a>");
                    str.Append("</li>");//可进行拼接
                }
                str.Append("</ul>");
                this.HotelsShow.Text = str.ToString(); //最终将str内容赋给前台的标签显示
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string byprovince = SearchByProvince.Value.Trim();//酒店所在省市关键词
            string byname = SearchByName.Value.Trim();//酒店名称关键词
            if (byprovince != "" || byname != "")
            {
                StringBuilder str = new StringBuilder(); //创建一个实例
                DataTable dt = hotel.searchHotelByKey(byprovince, byname);//根据酒店所在省市和名称模糊查询获取到的酒店信息
                if (dt != null && dt.Rows.Count > 0) //判断是否有数据
                {
                    str.Append("<ul>");
                    for (int i = 0; i < dt.Rows.Count; i++) //将数据库表中的数据循环赋给str
                    {
                        //将数据库表中值赋给新的变量
                        string id = dt.Rows[i]["Hid"].ToString();//酒店编号，需要传值到客户填写订单页面
                        string name = dt.Rows[i]["Hname"].ToString();//酒店名称
                        string province = dt.Rows[i]["Hprovince"].ToString();//所处省市
                        string price = dt.Rows[i]["Hprice"].ToString();//价位
                        string imageUrl = dt.Rows[i]["HimageUrl"].ToString();//酒店本地图片地址，需要传值到客户填写订单页面

                        str.Append("<li>"); //li标签
                        str.Append("<a href='./RoomReservation.aspx?HotelId=" + id + "&HotelImgUrl=" + imageUrl + "'>");  //a标签
                        str.Append("<img id='image" + i + "' runat = 'server' alt='' src='../../images/" + imageUrl + "' />"); //img标签
                        str.Append("<label id='label" + i + "' runat = 'server'>");//lable标签
                        str.Append(name + "&nbsp;&nbsp;价位:" + price + "<br/>" + province);//酒店简介
                        str.Append("</label > ");
                        str.Append("</a>");
                        str.Append("</li>");//可进行拼接
                    }
                    str.Append("</ul>");
                    this.HotelsShow.Text = str.ToString(); //最终将str内容赋给前台的标签显示
                }
                else
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('没有找到您要查询的酒店！');</script>");
            }
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入关键词！');</script>");
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            SearchByProvince.Value = "";
            SearchByName.Value = "";
        }
    }
}