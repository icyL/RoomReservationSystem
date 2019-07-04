<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMain.aspx.cs" Inherits="网上订房系统.LoginMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            text-decoration: none;
            list-style:none;
        }

        /*导航栏样式*/
        nav {
            width: 100%;
            height: 72px;
            line-height: 72px;
            background-color: blue;
            font-size: x-large;
        }

        #Label3 {
            float: left;
            margin-left: 200px;
            font-size: 50px;
            font-weight: bolder;
            color: #fff;
        }
       
        nav ul li{
            float:right;
            margin-right:50px;
            cursor:pointer;
        }

        /*主体样式*/
        #container {
            width: 100%;
            height: 680px;
            background-image: url(images/loginImg.png);
            background-repeat: no-repeat;
            background-size: cover;
        }
        /*登录表单样式*/
        #form1 {
            width: 550px;
            height: 230px;
            padding: 20px;
            border: 2px solid blue;
            border-radius: 10px;
            background-color: #dce6ec;
            position: fixed;
            top: 200px;
            right: 80px;
            display: block;
        }

        table {
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
    <!--导航栏部分-->
    <nav>
        <asp:Label ID="Label3" runat="server" Text="欢迎使用&nbsp;&nbsp;网&nbsp;上&nbsp;订&nbsp;房&nbsp;系&nbsp;统"></asp:Label>      
        <ul>
             <li> 
                <asp:HyperLink ID="HyperLink2" runat="server" BackColor="Blue" ForeColor="Black" NavigateUrl="~/Login/RegisterMain.aspx">注册</asp:HyperLink>
            </li>
            <li  onclick="showORhid() ">登录</li>           
        </ul>
    </nav>

    <!--主体部分-->
    <div id="container">
        <!--登录表单-->
        <form id="form1" runat="server">
            <table>
                <tr>
                    <th colspan="4">
                        <asp:Label ID="Label5" runat="server" Text="---用户登录---" Font-Size="X-Large"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="手机号:" Font-Size="X-Large" ></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="Account" runat="server" Height="30px" Width="100%"></asp:TextBox>
                    </td>
                    <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="手机号不能为空！" ControlToValidate="Account" ForeColor="Red">
                         </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密码:" Font-Size="X-Large"></asp:Label></td>
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
                    <td colspan="2">
                        <asp:Button ID="LoginButton" runat="server" Text="登录" Font-Size="X-Large" Width="100px" OnClick="Login_Click" /></td>
                    <td colspan="2">
                        <input id="ResetButton" type="reset" runat="server" value="重置" style="font-size:x-large;width:100px;height:38px;"/>
                    </td>
                </tr>
                <tr>
                    <td  colspan="4"> 
                        <asp:HyperLink ID="HyperLink1" runat="server" BackColor=" #dce6ec" ForeColor="blue" Font-Size="X-Large" NavigateUrl="~/Login/RegisterMain.aspx">未注册？点这里</asp:HyperLink>
                    </td>
                </tr>
                  <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </form>
    </div>

    <script type="text/javascript">
        var form = document.getElementById("form1");
        var flag = true;//是否显示登录表单的标识
        function showORhid() {
            flag = !flag;
            form.style.display = flag ? "block" : "none";
        }
    </script>
</body>
</html>


