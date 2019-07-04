<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomType.aspx.cs" Inherits="网上订房系统.RoomType" %>

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
            height: 100%;
            text-align: center;
            padding: 100px 0;

        }
        table tr td{
            height:50px;
        }

        /*主体左边内容样式*/
        .left {
            float: left;
            width: 65%;
            height: 100%;
            padding: 0 20px;
        }
         .left table {
             width:100%;
             text-align: center;
             margin: 0 auto;
        }
         .left table tr td:nth-child(9){
             width:200px;
         }
           .left table tr td:nth-child(10), .left table tr td:nth-child(11){
             width:80px;
         }

        /*主体右边内容样式*/
        .right {
            float: left;
            width: 35%;
            height: 100%;
            padding-right:20px;
        }
         .right table {
             text-align: center;
             margin: 0 auto;
             padding:10px;
             background-color:#ccc;
             border-radius:10px;
        }
         .right table tr td:first-child{
             display:block;
             width:80px;
             line-height:50px;
         }

        #CheckBox2, #CheckBox3, #CheckBox4, #CheckBox5{
           margin-left:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="left">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="当前无客房类型信息！"  OnRowCreated="Merge_Header" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"
                DataKeyNames="Tid"  Width="100%" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                    <asp:BoundField HeaderText="编号" DataField="Tid" ReadOnly="True" />
                    <asp:BoundField HeaderText="类型" DataField="Ttype" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="床位数" DataField="TbedNum" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="空调" DataField="TairConditioning" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField DataField="Ttelevision" HeaderText="电视机" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField DataField="ThairDrier" HeaderText="电吹风" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField DataField="Tlandline" HeaderText="电话" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField DataField="Twifi" HeaderText="WIFI" ControlStyle-Width="100%"></asp:BoundField>
                    <asp:BoundField HeaderText="备注" DataField="Tremark" ControlStyle-Width="100%"></asp:BoundField>
                    
                    <asp:CommandField ShowEditButton="True" HeaderText="操作" ButtonType="Button" >             
                        <ItemStyle ForeColor="Blue"/>
                    </asp:CommandField>
                     <asp:TemplateField ShowHeader="False" HeaderText="操作">
                        <ItemTemplate>
                            <asp:Button ID="DeleteButton" runat="server"  CommandName="Delete" CausesValidation="False"
                                Text="删除" OnClientClick="javascript:return confirm('删除会影响酒店客房信息和客户订单信息，您确认删除吗？');">
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
                    <th colspan="4">添加客房类型</th>
                </tr>
                <tr>
                    <td>类型编号：</td>
                    <td colspan="2">
                        <asp:TextBox ID="TypeId" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>客房类型：</td>
                    <td colspan="2">
                        <asp:TextBox ID="TypeName" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>床位数：</td>
                    <td colspan="2">
                        <asp:TextBox ID="BedNumber" runat="server" Height="30px" Width="100%" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>房间配置：</td>
                    <td colspan="2">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="空调" />
                        <asp:CheckBox ID="CheckBox2" runat="server" Text=" 电视" />
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="电吹风" />
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="电话" />
                        <asp:CheckBox ID="CheckBox5" runat="server" Text="WIFI" />
                    </td>
                </tr>
                <tr>
                    <td>备注：</td>
                    <td colspan="2">
                        <textarea id="Remark" runat="server" cols="50" rows="5"></textarea>
                      </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="AddButton" runat="server" Text="添加" Height="30px" Width="80px" OnClick="Add_Click"/></td>
                    <td><input id="Reset1" type="reset" value="重置" style="height:30px;width:80px;"/></td>                   
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
