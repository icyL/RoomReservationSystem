<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelInfo.aspx.cs" Inherits="网上订房系统.HotelInfo" %>

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
        body{
            overflow-y:auto;
            background-color:#fff;
        } 
        #form1{
             width:100%;
             height:100%;  
             text-align:center;         
        }

        /*顶部样式*/ 
        .topBar{
            width:100%;
            height:70px;
            line-height: 70px;
            position:fixed;
            top:0;
            left:0;
            text-align:center;
            background-color:#cccccc ;
            font-size: x-large;
        }
        #Label0{
            font-size: 30px;
            font-weight: bolder;
            color: #000;
        }       

         /*主体内容样式*/
         .Content{
             width:100%;
             height:100%;
             text-align:center;
             margin-top:100px;
             overflow:auto;
             padding:20px;
         }

       .Content ul{
            width:100%;
            margin-top:5px;
            list-style:none;    
        }
         .Content ul li{       
            width:25%;
            height:300px;
            float:left;
            text-align:center;
            padding:20px;
            font-size:medium;    
            cursor:pointer;                     
        }
         img{
             width:100%;
             height:220px;
         }
         /*后台动态添加的删除按钮*/
         input:last-child{
             width:50px;
             height:25px;
             float:right;
         }
      </style>
</head>
<body>    
    <form id="form1" runat="server">
    <!--顶部标签栏-->
          <nav class="topBar">         
            <asp:Label ID="Label0" runat="server" Text="---酒店信息---"></asp:Label><br />
            <asp:Label ID="LabelKey" runat="server" Text="关键词：" Font-Size="X-Large"></asp:Label>
            <input id="SearchByProvince" runat="server" type="text" style="font-size:x-large;" placeholder="酒店所在省市"/>
            &nbsp;&nbsp;
            <input id="SearchByName" runat="server" type="text" style="font-size:x-large;" placeholder="酒店名称"/>
            &nbsp;&nbsp;
            <asp:Button ID="SearchButton" runat="server" Text="搜索" Font-Size="X-Large"  Width="100px" OnClick="Search_Click"/>  
            &nbsp;&nbsp;
            <asp:Button ID="ResetButton" runat="server" Text="重置" Font-Size="X-Large"  Width="100px" OnClick="Reset_Click"/>
            &nbsp;&nbsp;   
            <asp:Button ID="DeleteButton" runat="server" Text="删除" Font-Size="X-Large"  Width="100px" OnClick="Delete_Click" style="display:none;"/> 
          </nav>        
        <!--下方内容-->
        <div class="Content">        
            <asp:Label ID="HotelsShow" runat="server" Text="当前无酒店信息! "></asp:Label>        
        </div>             
  </form>
</body>
</html>



