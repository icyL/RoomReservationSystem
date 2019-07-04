<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPassword.aspx.cs" Inherits="网上订房系统.ModifyPassword" %>

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
             <asp:Label ID="OldPassword" runat="server" Text="现密码" Font-Size="X-Large" Visible="false"></asp:Label>          
        <table>
             <tr>
                <th colspan="4">
                    <asp:Label ID="Label6" runat="server" Text="---修改密码---" Font-Size="X-Large"></asp:Label>
                </th>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="输入现密码:" Font-Size="X-Large" ></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="请输入现密码！" ControlToValidate="CurrentPassword" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="输入新密码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="请输入新密码！" ControlToValidate="NewPassword" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="确认新密码:" Font-Size="X-Large"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="VerifyNewPassword" runat="server" TextMode="Password" Height="30px" Width="100%"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="请确认密码!" ControlToValidate="VerifyNewPassword" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="<br/>密码输入不一致！"
                         ControlToValidate="VerifyNewPassword" ControlToCompare="NewPassword" ForeColor="Red">
                    </asp:CompareValidator>
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