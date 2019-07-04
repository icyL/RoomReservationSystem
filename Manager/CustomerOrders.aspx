<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerOrders.aspx.cs" Inherits="网上订房系统.CustomerOrders" %>

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
            text-decoration: none;
        }
        body{
             overflow-y:auto;
             background-color: #dce6ec;
        }
      #form1 {
            width:100%;
            height:100%;
            text-align: center;
            padding: 20px;   
        }  
        nav{
            position:fixed;
            top:20px;
            left:25%;
        }

        table {   
           width:1200px;    
           text-align: center;
           margin: 0 auto;         
        }
        table tr th {
            width: 100px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
             <asp:Label ID="Label10" runat="server" Text="关键词：" Font-Size="X-Large"></asp:Label>
             <input id="SearchByCardId" runat="server" type="text" style="font-size:x-large;" placeholder="客户身份证号"/>
             &nbsp;&nbsp;
             <asp:Button ID="SearchButton" runat="server" Text="搜索" Font-Size="X-Large"  Width="100px" OnClick="Search_Click"/>  
             &nbsp;&nbsp;
             <asp:Button ID="ResetButton" runat="server" Text="重置" Font-Size="X-Large"  Width="100px" OnClick="Reset_Click"/> 
        </nav>
        <br /><br /><br />
       <asp:Label ID="Label12" runat="server" Text="客户订单信息" Font-Size="X-Large"></asp:Label>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="找不到当前客户订单信息！" Width="100%"
            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" >
            <Columns>
                <asp:BoundField DataField="Oid" HeaderText="订单编号" />
                <asp:BoundField DataField="OorderDate" HeaderText="预订日期" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Uname" HeaderText="客户姓名" />
                <asp:BoundField DataField="Laccount" HeaderText="手机号码" />
                <asp:BoundField DataField="OcardId" HeaderText="身份证号" />
                <asp:BoundField DataField="Hname" HeaderText="酒店名称" />
                <asp:BoundField DataField="Haddress" HeaderText="酒店地址" />
                <asp:BoundField DataField="Hcontact" HeaderText="酒店联系方式" />
                <asp:BoundField DataField="Ttype" HeaderText="客房类型" />
                <asp:BoundField DataField="Onumber" HeaderText="预订数量" />
                <asp:BoundField DataField="OcheckInDate" HeaderText="入住日期" DataFormatString="{0:d}" />
                <asp:BoundField DataField="OstayDuration" HeaderText="入住时长" />
                <asp:BoundField DataField="Oprice" HeaderText="预付价格" /> 

            </Columns>

            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />

        </asp:GridView>
    </form>
</body>
</html>




