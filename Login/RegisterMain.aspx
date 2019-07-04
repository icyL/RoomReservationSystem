<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterMain.aspx.cs" Inherits="网上订房系统.RegisterMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            text-decoration:none;
        }

        body {
            width: 100%;
            height: 650px;
            background-image: url(images/registerImg.jpg);
            background-repeat: no-repeat;
            background-size: cover;
        }

        #form1 {
            width: 640px;
            height: 300px;
            padding: 10px;
            border: 2px solid blue;
            border-radius: 10px;
            background-color: #dce6ec;
            margin: 50px auto;
        }

        table {
            text-align: center;
            margin: 0 auto;
        }

            table tr td {
                width: 150px;
                height: 60px;
                padding-left:5px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="手机号码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="Telephone" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="手机号不能为空！" ControlToValidate="Telephone" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="<br/>手机号码有误！" ValidationExpression="^1[3|4|5|8][0-9]\d{4,8}$"
                        ControlToValidate="Telephone" ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="密&nbsp;&nbsp;&nbsp;码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="密码不能为空！" ControlToValidate="Password" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="确认密码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="VerifyPassword" runat="server" TextMode="Password" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="请确认密码!" ControlToValidate="VerifyPassword" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="<br/>密码输入不一致！"
                        ControlToCompare="Password" ControlToValidate="VerifyPassword" ForeColor="Red">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="身份证号:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="CardId" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="身份证号不能为空！" ControlToValidate="CardId" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ErrorMessage="<br/>身份证号有误！" ValidationExpression=" /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/"
                        ControlToValidate="CardId" ForeColor="Red">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="RegisterButton" runat="server" Text="注册" Font-Size="X-Large" OnClick="Register_Click" /></td>
                <td><asp:HyperLink ID="HyperLink1" runat="server" BackColor=" #dce6ec" ForeColor="blue" Font-Size="X-Large" NavigateUrl="~/LoginMain.aspx">返回</asp:HyperLink></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>


