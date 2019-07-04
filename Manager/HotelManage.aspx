<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelManage.aspx.cs" Inherits="网上订房系统.HotelManage" %>

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
        }
         body{
             overflow-y:auto;
             background-color: #dce6ec;
        }
        #form1 {
            width: 100%;
            height:100%;
            text-align: center;
            overflow: auto;
        }

        .left{
            width: 40%;
            float: left;
        }
         .right {
            width: 60%;
            float: left;
            padding-right:20px;
        }

        .hotelInfo, .roomInfo {
            width: 90%;
            text-align: left;
            margin: 5px auto;
            padding: 5px 30px 5px 20px;
            background-color: #cccccc;
            border-radius: 10px;
        }

        table tr td {
            width: 100px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="left">
            <table class="hotelInfo">
                <tr>
                    <th colspan="4" style=" text-align: center;">添加酒店信息</th>
                </tr>
                 <tr>
                    <td>酒店编号：</td>
                    <td colspan="2">
                        <asp:TextBox ID="HotelId" runat="server" Height="30px" Width="95%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*" ControlToValidate="HotelId" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>酒店名称：</td>
                    <td colspan="2">
                         <asp:TextBox ID="HotelName" runat="server" Height="30px" Width="95%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="*" ControlToValidate="HotelName" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td>所处省市：</td>
                    <td colspan="2">
                         <asp:TextBox ID="Province" runat="server" Height="30px" Width="95%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="*" ControlToValidate="Province" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td>详细地址：</td>
                    <td colspan="2">
                        <asp:TextBox ID="Address" runat="server" Height="30px" Width="95%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="*" ControlToValidate="Address" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>价位：</td>
                    <td colspan="2">
                        ￥<asp:TextBox ID="HotelPrice" runat="server" Height="30px" Width="89%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="*" ControlToValidate="HotelPrice" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>联系方式：</td>
                    <td colspan="2">
                         <asp:TextBox ID="Contact" runat="server" Height="30px" Width="95%"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ErrorMessage="*" ControlToValidate="Contact" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td>介绍：</td>
                    <td colspan="2">
                        <asp:TextBox ID="Introduce" runat="server" Height="30px" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>图片：</td>
                    <td colspan="2">
                        <input id="HotelImgUpload" runat="server" type="file" style="height: 30px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="HotelAddButton" runat="server" Text="添加" Height="30px" Width="80px" OnClick="HotelAdd_Click" /></td>
                    <td>
                       <asp:Button ID="HotelResetButton" runat="server" Text="重置" Height="30px" Width="80px" OnClick="HotelReset_Click" />
                    </td>
                </tr>
            </table>
            <table id="RoomTable" runat="server"  class="roomInfo">
                <tr>
                    <th colspan="3" style=" text-align: center;">添加客房信息</th>
                </tr>
                <tr>
                    <td>客房编号：</td>
                    <td colspan="2">
                        <asp:Label ID="RoomIdBefore" runat="server" Text="20190630001" style="font-weight:300;"></asp:Label>
                        <asp:TextBox ID="RoomIdAfter" runat="server" Height="30px" Width="63%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>客房类型：</td>
                    <td colspan="2">
                        <asp:TextBox ID="TypeName" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>客房总量：</td>
                    <td colspan="2">
                        <asp:TextBox ID="AllNumber" runat="server" Height="30px" Width="100%" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>每晚价格：</td>
                    <td colspan="2">
                        <asp:TextBox ID="SinglePrice" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>备注：</td>
                    <td colspan="2">
                        <asp:TextBox ID="Remark" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>图片：</td>
                    <td colspan="2">
                        <input id="RoomImgUpload" runat="server" type="file" style="height: 30px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="RoomAddButton" runat="server" Text="添加" Height="30px" Width="80px" OnClick="RoomAdd_Click" /></td>
                    <td>
                        <input id="Reset2" type="reset" value="重置" style="height: 30px; width: 80px;" /></td>
                </tr>
            </table>
        </div>
        <div class="right">
             <br />
              <asp:GridView ID="HotelGridView" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" 
                  BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="Hid"  Width="100%" >
                <Columns>
                    <asp:BoundField HeaderText="酒店编号" DataField="Hid" />
                    <asp:ImageField DataImageUrlField="HimageUrl" HeaderText="酒店图片" DataImageUrlFormatString="./images/{0}">
                        <ControlStyle Width="200px" Height="100px"></ControlStyle>
                    </asp:ImageField>
                    <asp:BoundField HeaderText="酒店名称" DataField="Hname" ControlStyle-Width="100%" ></asp:BoundField>
                    <asp:BoundField HeaderText="所处省市" DataField="Hprovince" ControlStyle-Width="100%" ></asp:BoundField>
                    <asp:BoundField HeaderText="详细位置" DataField="Haddress" ControlStyle-Width="100%" ></asp:BoundField>
                    <asp:BoundField HeaderText="价位" DataField="Hprice" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="联系方式" DataField="Hcontact" ControlStyle-Width="100%"></asp:BoundField>                   
                    <asp:BoundField HeaderText="简介" DataField="Hintroduce" ControlStyle-Width="100%"></asp:BoundField>
                 </Columns>
            
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />                                    
            </asp:GridView>
            <br />
            <br />
              <asp:GridView ID="RoomGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                  BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="Rid"  Width="100%"  >
                <Columns>
                    <asp:BoundField HeaderText="客房编号" DataField="Rid" />
                    <asp:ImageField DataImageUrlField="RimageUrl" HeaderText="客房图片" DataImageUrlFormatString="./images/{0}">
                        <ControlStyle Width="200px" Height="100px"></ControlStyle>
                    </asp:ImageField>
                    <asp:BoundField HeaderText="客房类型" DataField="Ttype" ControlStyle-Width="100%" ></asp:BoundField>
                    <asp:BoundField HeaderText="每晚价格" DataField="Rprice" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="客房总数" DataField="Rnumber" ControlStyle-Width="100%"></asp:BoundField>                   
                    <asp:BoundField HeaderText="备注" DataField="Rremark" ControlStyle-Width="100%"></asp:BoundField>
                 </Columns>
            
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />                       
            </asp:GridView>
        </div>
    </form>
</body>
</html>
