<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMain.aspx.cs" Inherits="网上订房系统.UserMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <style type="text/css">
        *{
            margin:0;
            padding:0;
            box-sizing:border-box;
            text-decoration:none;
        }  
        #form1{
           width:100%;
           height:100%;
        }

     /*导航栏样式*/ 
        nav{
            width:100%;
            height:20%;
            line-height:72px;
            text-align:center;
            background-color:blue;
            font-size:x-large;
        }
        nav ul{
            list-style:none;   
            display:flex;
            justify-content:flex-end;
            align-items:center;     
        }
        nav ul li{
            margin-right:50px;
            font-size:x-large;    
            cursor:pointer;                      
        }       
        #HyperLink1,#HyperLink2,#HyperLink3,#HyperLink4{
            color:#fff; 
            font-size:x-large;
        }
      
        /*框架样式*/
        iframe{  
            vertical-align:top;                  
            width:100%;
            height:675px;
            background-image: url(images/userMainImg.png);
            background-size:cover;
            background-repeat:no-repeat;
            border:none;
            text-align:center; 
        }
     </style>
</head>
<body>
    <form id="form1" runat="server">
       <nav>
        <ul>
            <li>  
                <asp:HyperLink ID="HyperLink1" runat="server" target="Content" NavigateUrl="~/Login/User/OnlineBooking.aspx">在线订房</asp:HyperLink>
            </li>          
             <li> 
                <asp:HyperLink ID="HyperLink2" runat="server" target="Content" NavigateUrl="~/Login/User/PersonalOrders.aspx">我的订单</asp:HyperLink>
            </li>
             <li> 
                <asp:HyperLink ID="HyperLink3" runat="server" target="Content" NavigateUrl="~/Login/User/AccountSettings.aspx">账户设置</asp:HyperLink>
            </li>
             <li> 
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/LoginMain.aspx" onClick="return confirm('确定退出登录?');">退出登录</asp:HyperLink>
            </li>
        </ul>
     </nav>
       <iframe id="Content" name="Content" ></iframe>
    </form>
</body>
</html>
