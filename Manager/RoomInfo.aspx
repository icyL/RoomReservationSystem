<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomInfo.aspx.cs" Inherits="网上订房系统.RoomInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            text-decoration: none;
        }
         body{
             overflow-y:auto;
             background-color: #fff;
        }
        #form1 {
            width: 100%;
            height:100%;
        }

        /*顶部样式*/
        .topBar {
            width: 100%;
            height: 70px;
            line-height: 70px;
            position: fixed;
            top: 0;
            left: 0;
            text-align: center;
            background-color: #cccccc;
            font-size: x-large;
        }

        #Label0 {
            font-size: 30px;
            font-weight: bolder;
            color: #000;
        }
        #BackLink{
            float:right;
            margin-right:50px;
            color:blue;
        }

        /*主体内容样式*/
        .Content {
            width: 100%;
            height: 100%;
            margin-top: 70px;
            text-align: center;
            overflow: auto;
            padding: 20px;
        }
        /*主体上面左边内容样式*/
        .image{
            width:50%;
            height: 250px;
            float:left;
            text-align: right;
        }
         /*主体上面右边内容样式*/
        .introduce {
            width:50%;
            float:left;
            vertical-align: top;
            height: 250px;
            line-height: 25px;
            font-size: 20px;
            display: inline-block;
            text-align: left;
            padding-left:20px;
        }
        #UpdateButton,#SaveButton{
            margin-top:5px;
        }

        /*主体下面左边内容样式*/
        .left {
            float: left;
            width: 70%;
            height: 100%;
            padding: 20px 20px 20px 10px;
        }
        /*主体下面右边内容样式*/
        .right {
            float: left;
            width: 30%;
            height: 100%;
            padding: 20px 10px 20px 20px;
            position: fixed;
            right: 30px;
            top: 350px;
        }

        table {
            text-align: center;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!--顶部标签栏-->
        <nav class="topBar">
            <asp:Label ID="Label0" runat="server" Text="---酒店客房信息管理---"></asp:Label>
            <asp:HyperLink ID="BackLink" runat="server" NavigateUrl="~/Manager/HotelInfo.aspx">返回</asp:HyperLink>
        </nav>
        <!--下方内容-->
        <div class="Content">
             <div class="image">
                 <asp:Image ID="HotelImg" runat="server" ImageUrl="~/images/xxxx.png" Width="400px" Height="200px" /><br />  
                 <asp:Label ID="ImgUrlLabel" runat="server" Visible="False"></asp:Label>
                 上传酒店图片:&nbsp;&nbsp;<input id="HotelImgUpload" runat="server" type="file" style="height: 30px;margin-top:5px;" /> 
             </div>              
            <div class="introduce">      
                编号：<asp:TextBox ID="HotelId" runat="server" Height="30px" BorderStyle="None" Font-Size="20px">xxxxxxx</asp:TextBox>    
                <br />
                名称：<asp:TextBox ID="Name" runat="server" Height="30px" Font-Size="20px">xx酒店</asp:TextBox>
                <br />
                省市：<asp:TextBox ID="Province" runat="server" Height="30px" Font-Size="20px">xx省xx市</asp:TextBox>
                <br />
                价位：￥<asp:TextBox ID="Price" runat="server" Height="30px"  Font-Size="20px" >xxx</asp:TextBox>
                <br />
                详细地址：<asp:TextBox ID="Address" runat="server" Height="30px" Font-Size="20px">xx区xx路xxxx街道</asp:TextBox>
                <br />
                联系方式：<asp:TextBox ID="Contact" runat="server" Height="30px" Font-Size="20px">18888888888</asp:TextBox>
                <br />
                简介：<asp:TextBox ID="Introduce" runat="server" Height="30px" Font-Size="20px">xxxxxxxxxxxxxxxx</asp:TextBox>
                <br />
                <asp:Button ID="UpdateButton" runat="server" Text="修改" Height="30px" Width="80px" OnClick="Update_Click" />
                <asp:Button ID="SaveButton" runat="server" Text="保存" Height="30px" Width="80px" OnClick="Save_Click" />   
            </div>
            <br />
            <br />
            <hr />
            <div class="left">
                   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="当前无酒店客房信息！"  OnRowCreated="Merge_Header" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"
                DataKeyNames="Rid"  Width="100%" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                    <asp:BoundField HeaderText="客房编号" DataField="Rid" ReadOnly="True" SortExpression="Rid"/>
                    <asp:ImageField DataImageUrlField="RimageUrl" HeaderText="客房图片" DataImageUrlFormatString="./images/{0}">
                        <ControlStyle Width="200px" Height="100px"></ControlStyle>
                    </asp:ImageField>
                    <asp:BoundField HeaderText="类型编号" DataField="RtypeId" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField HeaderText="客房类型" DataField="Ttype" ControlStyle-Width="100%" ></asp:BoundField>
                    <asp:BoundField HeaderText="床位数量" DataField="TbedNum" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="TairConditioning" HeaderText="空调" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="Ttelevision" HeaderText="电视机" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="ThairDrier" HeaderText="电吹风" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="Tlandline" HeaderText="电话" ControlStyle-Width="100%" ReadOnly="true"></asp:BoundField>
                    <asp:BoundField DataField="Twifi" HeaderText="WIFI" ControlStyle-Width="100%" ReadOnly="true"> </asp:BoundField>
                    <asp:BoundField HeaderText="每晚价格" DataField="Rprice" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="客房总数" DataField="Rnumber" ControlStyle-Width="100%"></asp:BoundField>                   
                    <asp:BoundField HeaderText="备注" DataField="Rremark" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="空房数量" DataField="RvacantNum" ControlStyle-Width="100%" ></asp:BoundField>
                    
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" ButtonType="Button" >             
                        <ItemStyle ForeColor="Blue"/>
                    </asp:CommandField>
                     <asp:TemplateField ShowHeader="False" HeaderText="操作">
                        <ItemTemplate>
                            <asp:Button ID="DeleteButton" runat="server"  CommandName="Delete" CausesValidation="False"
                                Text="删除" OnClientClick="javascript:return confirm('真的要删除吗？');">
                            </asp:Button>
                        </ItemTemplate>
                         <ItemStyle ForeColor="Blue" />
                    </asp:TemplateField>    
                                  
                </Columns>
            
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                       
            </asp:GridView>
            </div>
            <div class="right">
                <table>
                    <tr>
                        <th colspan="2">添加客房信息</th>
                    </tr>
                    <tr>
                        <td>客房编号：</td>
                        <td>
                            <asp:Label ID="RoomIdBefore" runat="server" Text="20190630001" style="font-weight:300;"></asp:Label>
                            <asp:TextBox ID="RoomIdAfter" runat="server" Height="30px" Width="60%" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>客房类型：</td>
                        <td>
                            <asp:TextBox ID="Type" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>客房总量：</td>
                        <td>
                            <asp:TextBox ID="AllNumber" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>每晚价格：</td>
                        <td>
                            <asp:TextBox ID="SinglePrice" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>备注：</td>
                        <td>
                           <textarea id="Remark" runat="server" cols="23" rows="2" style="font-size:20px;" ></textarea></td>
                    </tr>
                    <tr>
                        <td>图片：</td>
                        <td colspan="3">
                            <input id="RoomImgUpload" runat="server" type="file" style="height: 30px; width: 100%;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="AddButton" runat="server" Text="添加" Height="30px" Width="80px" OnClick="Add_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="Reset1" runat="server" type="reset" value="重置" style="height: 30px; width: 80px;" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="RoomImgLabel" runat="server" Text="修改客房图片:" style="float:left;font-weight:bold;display:none;"></asp:Label>
                <br />
                <input id="UpdateRoomImg" runat="server" type="file" style="height: 30px;margin-top:5px;float:left;" disabled="disabled" />            
            </div>
        </div>
    </form>
</body>
</html>


