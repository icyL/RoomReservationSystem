using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 网上订房系统.App_Code;

namespace 网上订房系统
{
    public partial class HotelManage : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();
        Room room = new Room();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
                RoomTable.Attributes.CssStyle.Add("display", "none");//设置客房添加表不可见
        }

        protected void HotelAdd_Click(object sender, EventArgs e)
        {
            hotelInfo h = new hotelInfo();//酒店信息对象
            h.Hid = HotelId.Text.Trim();//酒店编号
            h.Hname = HotelName.Text.Trim();//酒店名称
            h.Hprovince = Province.Text.Trim();//所处省市
            h.Haddress = Address.Text.Trim();//详细地址
            h.Hprice = Double.Parse(HotelPrice.Text.Trim());//人均价位
            h.Hcontact = Contact.Text.Trim();//酒店联系方式
            h.Hintroduce = Introduce.Text.Trim();//相关介绍
            h.HimageUrl = HotelImgUpload.Value.Trim();//上传的酒店图片url名称

            if (hotel.IdisExisted(h.Hid))//要添加的酒店编号存在
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('要添加的酒店编号已存在，请重新输入一个编号！');</script>");
            else
            {
                    hotel.addHotelInfo(h);//添加酒店信息
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功！');</script>");

                    //显示添加成功的酒店信息
                    DataTable table = hotel.searchHotelById(h.Hid);
                    this.HotelGridView.DataSource = table;
                    this.HotelGridView.DataBind();//数据绑定

                   RoomTable.Attributes.CssStyle.Remove("display");//设置客房添加表可见，可以开始添加酒店的客房
                   RoomIdBefore.Text = HotelId.Text.Trim();//酒店客房编号前缀
                   RoomIdAfter.Focus();
            }
        }
        protected void HotelReset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());//刷新页面
        }

        protected void RoomAdd_Click(object sender, EventArgs e)
        {
            if (RoomIdAfter.Text == "")
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入一个该酒店的客房编号！！');</script>");               
            else
            {
                hotelRoom hr = new hotelRoom();//酒店客房信息对象
                hr.Rid = RoomIdBefore.Text.Trim()+RoomIdAfter.Text.Trim();//酒店客房编号
                hr.Hid = HotelId.Text.Trim();//酒店编号  
                string typeName = TypeName.Text.Trim();//客房类型              

                if (room.IdisExisted(hr.Rid))//要添加的酒店客房编号存在            
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('要添加的客房编号已存在，请重新输入一个编号！');</script>");
                else if(typeName=="")//客房类型未填
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入客房类型！');</script>");
                else if (AllNumber.Text == "" || Int32.Parse(AllNumber.Text.Trim()) <= 0)//客房总量为空或填写的客房总量小等于0时
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入大于0的客房总量！');</script>");
                else if (SinglePrice.Text == "" || Double.Parse(SinglePrice.Text.Trim()) <= 0)//每晚价格为空或填写的价格小等于0时
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入该客房住一晚的价格，价格需大于0！');</script>");
                else
                {                               
                    if (room.TypeisExisted(typeName))//要添加的客房类型已存在
                    {
                        hr.Tid = room.searchRoomTypeId(typeName);//根据客房类型名称查询到的客房类型编号
                        hr.Rnumber = Int32.Parse(AllNumber.Text.Trim());//客房总量
                        hr.Rprice = Double.Parse(SinglePrice.Text.Trim());//每晚价格
                        hr.Rremark = Remark.Text.Trim();//备注
                        hr.RvacantNum = hr.Rnumber;//当前可预约空房数为客房总量
                        hr.RimageUrl = RoomImgUpload.Value.Trim();//上传的客房图片url名称

                        room.addHotelRoomInfo(hr);//添加酒店客房信息
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功！');</script>");

                        RoomTable.Attributes.CssStyle.Remove("display");//设置客房添加表可见
                                                                        //显示添加成功的酒店客房信息
                        DataTable table = room.searchHotelRoomById(hr.Hid);//根据酒店编号查询客房信息
                        this.RoomGridView.DataSource = table;
                        this.RoomGridView.DataBind();//数据绑定

                        //清空文本框
                        RoomIdAfter.Text = "";
                        TypeName.Text = "";
                        AllNumber.Text = "";
                        SinglePrice.Text = "";
                        Remark.Text = "";
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('要添加的客房类型不存在，请先去客房类型管理界面进行添加！');</script>");
                }
            }          
        }      
    }
}