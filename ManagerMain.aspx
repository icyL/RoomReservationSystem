<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerMain.aspx.cs" Inherits="网上订房系统.ManagerMain" %>

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
             height:750px;
        }
         /*左侧导航栏样式*/ 
        .leftBar{
            width:15%;
            height:100%;
            float:left;
            text-align:center;
            background-color: blue;
            font-size:x-large;
        }
         .leftBar ul{
            list-style:none;   
            display:flex;
            flex-direction:column;
        }
         .leftBar ul li{
            font-size:x-large;    
            cursor:pointer;  
            margin-top:100px;                    
        }
        #HyperLink1,#HyperLink2,#HyperLink3,#HyperLink4{
            color:#fff; 
            font-size:x-large;
        }

       /*右侧内容样式*/          
        iframe{          
            width: 85%;
            height:100%;
            float:left;
            text-align:center; 
            border:none;
            background-image: url(images/managerMainImg.png);
            background-size:cover;
            background-repeat:no-repeat;
        }
      </style>
</head>
<body>    
    <form id="form1" runat="server">
    <!--左侧内容-->
       <nav class="leftBar">
        <ul>         
            <li>  
                <asp:HyperLink ID="HyperLink1" runat="server" target="Content" NavigateUrl="~/Manager/HotelInfo.aspx">酒店信息查询</asp:HyperLink>
            </li>
             <li>  
                <asp:HyperLink ID="HyperLink2" runat="server" target="Content" NavigateUrl="~/Manager/HotelManage.aspx">酒店信息管理</asp:HyperLink>
            </li>
             <li>  
                <asp:HyperLink ID="HyperLink3" runat="server" target="Content" NavigateUrl="~/Manager/RoomType.aspx">客房类型管理</asp:HyperLink>
            </li>
               <li> 
                <asp:HyperLink ID="HyperLink4" runat="server" target="Content" NavigateUrl="~/Manager/CustomerOrders.aspx">客户订单管理</asp:HyperLink>
            </li>                     
        </ul>
     </nav>
    <!--右侧内容-->       
         <iframe id="Content" name="Content" ></iframe>
  </form>
</body>
</html>


