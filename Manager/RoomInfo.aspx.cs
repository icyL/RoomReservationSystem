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
    public partial class RoomInfo : System.Web.UI.Page
    {
        Hotel hotel = new Hotel();
        Room room = new Room();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request["HotelId"];//接收来自酒店信息页面a链接传递过来的酒店编号           
                DataTable table = hotel.searchHotelById(id);
                HotelId.Text = id;
                Name.Text = table.Rows[0]["Hname"].ToString();
                Province.Text = table.Rows[0]["Hprovince"].ToString();
                Price.Text = table.Rows[0]["Hprice"].ToString();
                Address.Text = table.Rows[0]["Haddress"].ToString();
                Contact.Text = table.Rows[0]["Hcontact"].ToString();
                Introduce.Text = table.Rows[0]["Hintroduce"].ToString();
                HotelImg.ImageUrl= "~/images/" + Request["HotelImgUrl"];//接收来自酒店信息页面a链接传递过来的酒店图片url 
                ImgUrlLabel.Text = Request["HotelImgUrl"];//接收传递过来的酒店图片url显示在label上 

                InitGridView();//酒店客房信息表数据加载
            }

                styleSetting(true);//样式设置            
                RoomIdBefore.Text = HotelId.Text.Trim();//酒店客房编号前缀
        }

        //合并表头
        protected void Merge_Header(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                TableCellCollection tcHeader = e.Row.Cells;
                //清除自动生成的表头
                tcHeader.Clear();

                tcHeader.Add(new TableHeaderCell());
                tcHeader[0].RowSpan = 2;
                tcHeader[0].Text = "客房编号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].RowSpan = 2;
                tcHeader[1].Text = "客房图片";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].RowSpan = 2;
                tcHeader[2].Text = "类型编号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].RowSpan = 2;
                tcHeader[3].Text = "客房类型";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].RowSpan = 2;
                tcHeader[4].Text = "床位数量";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].ColumnSpan = 5;
                tcHeader[5].Text = "客房配置";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].RowSpan = 2;
                tcHeader[6].Text = "每晚价格";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].RowSpan = 2;
                tcHeader[7].Text = "客房总量";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].RowSpan = 2;
                tcHeader[8].Text = "备注";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].RowSpan = 2;
                tcHeader[9].Text = "空房数量";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].RowSpan = 2;
                tcHeader[10].ColumnSpan = 2;
                tcHeader[10].Text = "操作</th></tr><tr>";


                tcHeader.Add(new TableHeaderCell());
                tcHeader[11].Text = "空调";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[12].Text = "电视机";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[13].Text = "电吹风";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[14].Text = "电话";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[15].Text = "WIFI";

                //背表头颜色
                for (int i = 0; i < 16; i++)
                {
                    tcHeader[i].BackColor = System.Drawing.Color.Blue;
                    tcHeader[i].ForeColor = System.Drawing.Color.White;
                }
            }
        }

        //边框和可见及可用样式设置
        protected void styleSetting(bool fORt)
        {
            UpdateButton.Visible = fORt;//修改按钮
            SaveButton.Visible = !fORt;//保存按钮
            //只读属性
            Name.ReadOnly = fORt;
            Province.ReadOnly = fORt;
            Price.ReadOnly = fORt;
            Address.ReadOnly = fORt;
            Contact.ReadOnly = fORt;
            Introduce.ReadOnly = fORt;
            if (fORt)
            {
                HotelImgUpload.Attributes.Add("disabled", "disabled");//禁用file文本框  
                //设置文本框的边框不可见
                Name.Attributes.CssStyle.Add("border", "none");
                Province.Attributes.CssStyle.Add("border", "none");
                Price.Attributes.CssStyle.Add("border", "none");
                Address.Attributes.CssStyle.Add("border", "none");
                Contact.Attributes.CssStyle.Add("border", "none");
                Introduce.Attributes.CssStyle.Add("border", "none");
            }
            else
            {
                HotelImgUpload.Attributes.Remove("disabled");//设置file文本框可用
                //设置文本框边框可见
                Name.Attributes.CssStyle.Add("border", "1px solid #000");
                Province.Attributes.CssStyle.Add("border", "1px solid #000");
                Price.Attributes.CssStyle.Add("border", "1px solid #000");
                Address.Attributes.CssStyle.Add("border", "1px solid #000");
                Contact.Attributes.CssStyle.Add("border", "1px solid #000");
                Introduce.Attributes.CssStyle.Add("border", "1px solid #000");            
            }
        }

        //显示酒店客房信息表,酒店客房信息和客房类型两表连接查询
        protected void InitGridView()
        {
            string id = Request["HotelId"];//接收来自酒店信息页面a链接传递过来的酒店编号    
            DataTable table = room.searchHotelRoomById(id);
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();//数据绑定
        }

        //删除某行数据
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Keys[0].ToString();//删除的行id
            if (room.deleteHotelRoomInfo(id))  //如果删除成功                         
                InitGridView(); //重新加载数据
        }

        //编辑某行数据
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            RoomImgLabel.Style.Remove("display");//标签可见
            UpdateRoomImg.Attributes.Remove("disabled");//文件上传控件可用
            InitGridView();//重新加载数据
        }

        //更新编辑的数据行
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            hotelRoom hr = new hotelRoom();//酒店客房信息对象
            roomType t = new roomType();//客房类型对象

            GridViewRow row = this.GridView1.Rows[e.RowIndex];
            hr.Rid = e.Keys[0].ToString().Trim();//酒店客房编号 
            hr.Hid = HotelId.Text.Trim();//酒店编号
                 
            if (UpdateRoomImg.Value == "")//如果没有更改酒店客房图片
                hr.RimageUrl = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();//原先的客房图片
            else            
                hr.RimageUrl = UpdateRoomImg.Value.Trim();//上传的本地图片url
                  
            string oldType = room.searchHotelRoomType(hr.Rid);//修改前的该酒店的客房类型名称
            bool flag = false;//标志要修改成的客房类型是否存在
            string type = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();//客房类型 
                
            if (!room.TypeisExisted(type))//如果要修改成的客房类型不存在
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('该客房类型不存在，请先去客房类型管理页面添加！');</script>");
                ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text = oldType;//还原原先客房类型
            }
            else//如果要修改成的客房类型存在
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    //要修改成的酒店的该客房类型已存在
                    if (((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString() == GridView1.Rows[i].Cells[3].Text && i != e.RowIndex)
                    {
                        flag = true;//要修改的客房类型存在
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('该客房类型已存在，请直接在它的数据行修改！');</script>");
                       ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text = oldType;//还原原先客房类型
                    }
                }
                if (!flag)//要修改成的酒店的该客房类型不存在
                {
                    hr.Tid = room.searchRoomTypeId(type);//根据客房类型查到的客房类型编号
                    hr.Rprice = Double.Parse(((TextBox)row.Cells[10].Controls[0]).Text.ToString());//每晚价格   
                    hr.Rnumber = Int32.Parse(((TextBox)row.Cells[11].Controls[0]).Text.ToString());//总数量        
                    hr.Rremark = ((TextBox)row.Cells[12].Controls[0]).Text.ToString();//酒店客房备注
                    hr.RvacantNum = Int32.Parse(((TextBox)row.Cells[13].Controls[0]).Text.ToString());//当前空房数

                    if (room.updateHotelRoomInfo(hr, hr.Rid)) //执行修改的方法成功
                    {
                        this.GridView1.EditIndex = -1;   //取消编辑状态
                        RoomImgLabel.Style.Add("display", "none");//标签不可见
                        UpdateRoomImg.Attributes.Add("disabled", "disabled");//文件上传控件禁用
                        InitGridView();     //重新加载一次数据
                    }
                }
            }                        
        }

        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;//取消编辑状态
            RoomImgLabel.Style.Add("display", "none");//标签不可见
            UpdateRoomImg.Attributes.Add("disabled", "disabled");//文件上传控件禁用
            InitGridView();
        }


        protected void Update_Click(object sender, EventArgs e)
        {
            styleSetting(false);//设置样式          
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            hotelInfo h = new hotelInfo();//酒店信息对象
            h.Hid= HotelId.Text.Trim();//酒店编号 
            h.Hname = Name.Text.Trim();//酒店名称
            h.Hprovince = Province.Text.Trim();//酒店所在省市
            h.Hprice = Double.Parse(Price.Text.Trim());//酒店价位
            h.Haddress = Address.Text.Trim();//详细地址
            h.Hcontact = Contact.Text.Trim();//联系方式
            h.Hintroduce = Introduce.Text;//相关介绍

            if (HotelImgUpload.Value == "")//如果没有更改酒店图片
                h.HimageUrl = ImgUrlLabel.Text.Trim();//当前的酒店图片名称
            else
            {
                h.HimageUrl = HotelImgUpload.Value.Trim();//上传的本地图片url
                ImgUrlLabel.Text = h.HimageUrl;//选择的图片的url
            }                        
            hotel.updateHotelInfo(h,h.Hid);//修改酒店信息

            styleSetting(true);//设置样式    
            HotelImg.ImageUrl = "~/images/" + h.HimageUrl;//选择的图片的url

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('修改成功！');</script>");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (RoomIdAfter.Text == "")//酒店客房编号未填
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入一个该酒店的客房编号！！');</script>");
            else
            {
                hotelRoom hr = new hotelRoom();//酒店客房信息对象
                hr.Rid = RoomIdBefore.Text.Trim() + RoomIdAfter.Text.Trim();//酒店客房编号
                hr.Hid = Request["HotelId"];//接收来自酒店信息页面a链接传递过来的酒店编号 
                string type = Type.Text.Trim();//客房类型
              
                if (room.IdisExisted(hr.Rid))//要添加的酒店客房编号存在           
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('要添加的客房编号已存在，请重新输入一个编号！');</script>");
                else if (type == "")//客房类型未填
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入客房类型！');</script>");
                else if (AllNumber.Text == ""|| Int32.Parse(AllNumber.Text.Trim())<=0)//客房总量为空或填写的客房总量小等于0时
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入大于0的客房总量！');</script>");
                else if (SinglePrice.Text == ""|| Double.Parse(SinglePrice.Text.Trim()) <=0)//每晚价格为空或填写的价格小等于0时
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入该客房住一晚的价格，价格需大于0！');</script>");
                else
                {
                    if (room.TypeisExisted(type))//要添加的客房类型已存在
                    {                        
                        hr.Tid = room.searchRoomTypeId(type);//根据客房类型名称查询到的客房类型编号
                        hr.Rnumber = Int32.Parse(AllNumber.Text.Trim());//客房总量
                        hr.Rprice = Double.Parse(SinglePrice.Text.Trim());//每晚价格
                        hr.Rremark = Remark.Value.Trim();//备注
                        hr.RvacantNum = hr.Rnumber;//当前可预约空房数为客房总量
                        hr.RimageUrl = RoomImgUpload.Value.Trim();//上传的客房图片url名称

                        room.addHotelRoomInfo(hr);//添加酒店客房信息
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功！');</script>");

                        InitGridView();//重新加载表格数据
                        //清空文本框
                        RoomIdAfter.Text = "";
                        Type.Text = "";
                        AllNumber.Text = "";
                        SinglePrice.Text = "";
                        Remark.Value = "";
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('要添加的客房类型不存在，请先去客房类型管理界面进行添加！');</script>");
                }
            }
        }
    }
}