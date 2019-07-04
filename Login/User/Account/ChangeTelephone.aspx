<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeTelephone.aspx.cs" Inherits="网上订房系统.ChangeTelephone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        #form1 {
            width: 100%;
            height: 675px;
            text-align: center;
            padding-top:130px; 
        }

        table {
            width: 600px;
            height:250px;
            border: 2px solid blue;
            border-radius: 10px;
            background-color: #dce6ec;
            text-align: center;
            margin:0 auto;
        }

            table tr td {
                width: 150px;
                height: 50px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table>
            <tr>
                <th colspan="4">
                    <asp:Label ID="Label0" runat="server" Text="---换绑手机---" Font-Size="X-Large"></asp:Label>
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="现手机号码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="OldTelephone" runat="server" Height="30px" Width="100%" ReadOnly="true"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="新手机号码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="NewTelephone" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="请输入新手机号！" ControlToValidate="NewTelephone" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="<br/>手机号码有误！" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$"
                        ControlToValidate="NewTelephone" ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Button ID="SaveButton" runat="server" Text="保存" Font-Size="X-Large" Width="100px" OnClick="Save_Click"/>
                </td>
                <td></td>
            </tr>
        </table>
      </div>
    </form>
</body>
</html>