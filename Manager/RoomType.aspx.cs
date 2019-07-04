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
    public partial class RoomType : System.Web.UI.Page
    {
        App_Code.Type type = new App_Code.Type();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitGridView();
            }
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
                tcHeader[0].Text = "编号";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[1].RowSpan = 2;
                tcHeader[1].Text = "类型";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[2].RowSpan = 2;
                tcHeader[2].Text = "床位数";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[3].ColumnSpan = 5;
                tcHeader[3].Text = "客房配置";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[4].RowSpan = 2;
                tcHeader[4].Text = "备注";

                tcHeader.Add(new TableHeaderCell());
                tcHeader[5].RowSpan = 2;
                tcHeader[5].ColumnSpan = 2;
                tcHeader[5].Text = "操作</th></tr><tr>";


                tcHeader.Add(new TableHeaderCell());
                tcHeader[6].Text = "空调";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[7].Text = "电视机";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[8].Text = "电吹风";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[9].Text = "电话";
                tcHeader.Add(new TableHeaderCell());
                tcHeader[10].Text = "WIFI";

                //背表头颜色
                for (int i = 0; i < 11; i++)
                {
                    tcHeader[i].BackColor = System.Drawing.Color.Blue;
                    tcHeader[i].ForeColor= System.Drawing.Color.White;
                }
            }
        }

        //显示客房类型信息表
        protected void InitGridView()
        {
            DataTable table = type.searchRoomType();
            this.GridView1.DataSource = table;
            this.GridView1.DataBind();//数据绑定
        }

        //删除某行数据
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Keys[0].ToString();//删除的行id
            if (type.deleteRoomType(id))  //如果删除成功                         
                InitGridView(); //重新加载数据
        }

        //编辑某行数据
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            InitGridView();//重新加载数据          
        }

        //更新编辑的数据行
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            roomType t = new roomType();//客房类型对象
            GridViewRow row = this.GridView1.Rows[e.RowIndex];
            t.Tid = e.Keys[0].ToString().Trim();//编号

            string oldType = type.searchRoomType(t.Tid);//修改前的客房类型名称
            bool flag = false;//标志要修改成的客房类型在不在

            t.Ttype = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
            t.TbedNum = Int32.Parse(((TextBox)this.GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString());
            t.TairConditioning = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
            t.Ttelevision= ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString();
            t.ThairDrier = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString();
            t.Tlandline = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[6].Controls[0]).Text.ToString();
            t.Twifi = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[7].Controls[0]).Text.ToString();
            t.Tremark = ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[8].Controls[0]).Text.ToString();

            for(int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString() == GridView1.Rows[i].Cells[1].Text && i!=e.RowIndex)//要修改成的客房类型已存在
                {
                    flag = true;//要修改的客房类型存在
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('该客房类型已存在，请直接在它的数据行修改！');</script>");
                    ((TextBox)this.GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text = oldType;//还原原先客房类型
                }
            }
            if (!flag)//要修改的客房类型不存在
            {
                if (type.updateRoomType(t, t.Tid)) //执行修改的方法成功
                {
                    this.GridView1.EditIndex = -1;   //取消编辑状态
                    InitGridView();     //重新加载一次数据
                }
            }                           

        }

        //取消编辑
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;//取消编辑状态
            InitGridView();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string id = TypeId.Text.Trim();//客房类型编号     
            if(id=="")//客房类型编号为空时
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入客房类型编号！');</script>");
            else if(BedNumber.Text=="")//床位数为空时
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('请输入床位数！');</script>");
            else
            {
                string name = TypeName.Text.Trim();//客房类型
                int bedNum = Int32.Parse(BedNumber.Text.Trim());//床位数
                string remark = Remark.Value;//备注信息

                string[] condition = new string[5]; ;//房间配置的有无
                int i = 0;
                //遍历所有控件
                foreach (Control ct in form1.Controls)
                {
                    //如果为复选框
                    if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                    {
                        CheckBox cb = (CheckBox)ct;
                        if (cb.Checked == true)
                            condition[i] = "有";
                        else
                            condition[i] = "无";
                        i++;
                    }
                }

                if (bedNum<0)//床位数小于0时
                    Response.Write("<script>alert('请输入不小于0的床位数！');</script>");
                else
                {
                    roomType t = new roomType();//客房类型对象
                    //客房类型编号
                    t.Tid = id;
                    //客房类型名称
                    t.Ttype = name;
                    //客房床位数
                    t.TbedNum = bedNum;
                    //空调有无
                    t.TairConditioning = condition[0];
                    //电视机有无
                    t.Ttelevision = condition[1];
                    //电吹风有无
                    t.ThairDrier = condition[2];
                    //座机电话有无
                    t.Tlandline = condition[3];
                    //无线网络有无
                    t.Twifi = condition[4];
                    //备注
                    t.Tremark = remark;

                    if (type.IdisAdded(id))//如果客房类型编号已存在
                        //type.updateRoomType(t, id);//修改记录
                         Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('该客房类型已存在！');</script>");
                    else if (type.TypeisAdded(name))//如果客房类型名已存在
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('该客房类型已存在！');</script>");
                    else
                    {
                        type.addRoomType(t);//向客房类型信息表插入一条新记录
                        //Response.Write("<script>alert('添加成功！');</script>");
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('添加成功！');</script>");

                        //清空文本框
                        TypeId.Text = "";
                        TypeName.Text = "";
                        BedNumber.Text = "";
                        Remark.Value = "";
                        //遍历所有控件
                        foreach (Control ct in form1.Controls)
                        {
                            //如果为复选框
                            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
                            {
                                CheckBox cb = (CheckBox)ct;
                                cb.Checked = false;//取消选中
                            }
                        }

                        InitGridView();//重新加载表格数据
                    }
                }            
            }
        }
    }
}