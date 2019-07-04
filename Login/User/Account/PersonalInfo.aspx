<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="网上订房系统.PersonalInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            box-sizing:border-box;
        }

        #form1 {
            width: 100%;
            height: 675px;
            text-align: center;
            padding-top:130px;  
        }

        table {
            width:500px;
            padding: 20px 20px 20px 0;   
            border: 2px solid blue;
            border-radius: 10px;
            background-color: #dce6ec;
            text-align: center;
            margin: 0 auto;
        }
        table tr td {
            width: 150px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <th colspan="4">
                    <asp:Label ID="Label0" runat="server" Text="---个人信息---" Font-Size="X-Large"></asp:Label>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="姓名:" Font-Size="X-Large"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="UserName" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="性别:" Font-Size="X-Large"></asp:Label>
                </td>
                <td><asp:RadioButton ID="Sex1" runat="server" GroupName="sex" Text="男" Font-Size="X-Large"/></td>
                <td><asp:RadioButton ID="Sex2" runat="server" GroupName="sex" Text="女" Font-Size="X-Large"/></td>
                <td></td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="出生日期:" Font-Size="X-Large"></asp:Label>
                </td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Size="X-Large" Width="80%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>年 </td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Font-Size="X-Large" Width="80%" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>月 </td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Font-Size="X-Large" Width="80%"></asp:DropDownList>日 </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="电子邮箱:" Font-Size="X-Large"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="Email" runat="server" Height="30px" Width="100%" TextMode="Email"></asp:TextBox>
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ErrorMessage="邮箱格式不符！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="Email" ForeColor="Red">
                        </asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="身份证号:" Font-Size="X-Large"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="CardId" runat="server" Height="30px" Width="100%" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Button ID="UpdateButton" runat="server" Text="修改" Font-Size="X-Large" Width="100px" OnClick="Update_Click" /> 
                    <asp:Button ID="SaveButton" runat="server" Text="保存" Font-Size="X-Large" Width="100px"  OnClick="Save_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
