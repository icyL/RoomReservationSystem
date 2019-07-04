<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomReservation.aspx.cs" Inherits="网上订房系统.RoomReservation" %>

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
             background-color: #fff;
        }
        #form1{
             width:100%;
             height:100%;
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
         #BackLink{
            float:right;
            margin-right:50px;
            color:blue;
        }

         /*主体内容样式*/
         .Content{
             width:100%;
             height:100%;
             margin-top:70px;
             text-align:center;
             overflow:auto;
             padding:20px;
         }
         /*主体上边内容样式*/
          #Image1{
              display:inline-block;
          }
          .introduce{
              vertical-align:top;
              height:200px;
              line-height: 30px;
              font-size:20px;
              display:inline-block;
              text-align:left;
              padding:20px;
          }
         /*主体左边内容样式*/
          .left{
              float:left;
              width:70%;
              height:100%;
              padding:20px;
          }      
          /*主体右边内容样式*/
        .right{           
             float:left;
             width:30%;
             height:100%;
             padding:20px;
             position:fixed;
             right:30px;
             top:300px;
        }
        table {   
           text-align: center;  
           margin:0 auto;     
        }

      </style>
</head>
<body>    
    <form id="form1" runat="server">
    <!--顶部标签栏-->
          <nav class="topBar">         
             <asp:Label ID="Label0" runat="server" Text="---酒店客房信息---"></asp:Label>
             <asp:HyperLink ID="BackLink" runat="server" NavigateUrl="~/Login/User/OnlineBooking.aspx">返回</asp:HyperLink>
         </nav>  
        <!--下方内容-->
        <div class="Content">
          <asp:Image ID="HotelImg" runat="server" ImageUrl="~/images/xxxx.jpg" Width="400px" Height="200px"  />
          <div class="introduce">          
                    名称：<asp:Label ID="Name" runat="server" Text="xx酒店" Font-Size="20px"></asp:Label><br />
                    省市：<asp:Label ID="Province" runat="server" Text="xx省xx市" Font-Size="20px"></asp:Label><br />
                    价位：￥<asp:Label ID="Price" runat="server" Text="xxx" Font-Size="20px"></asp:Label><br />
                    详细地址：<asp:Label ID="Address" runat="server" Text="xx区xxx路xxxx街道" Font-Size="20px"></asp:Label><br />
                    介绍：<asp:Label ID="Introduce" runat="server" Text="xxxxxxxxxxx" Font-Size="20px"></asp:Label><br />
                    联系方式：<asp:Label ID="Contact" runat="server" Text="18888888888" Font-Size="20px"></asp:Label>
           </div>
            <br /><br /><hr />
            <div class="left">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="当前无酒店客房信息！"  OnRowCreated="Merge_Header" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black"
                DataKeyNames="Rid"  Width="100%"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" >
                   <Columns>
                        <asp:BoundField HeaderText="客房编号" DataField="Rid"> 
                            <HeaderStyle CssClass="display:none;" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="RimageUrl" HeaderText="客房图片" DataImageUrlFormatString="./images/{0}">
                            <ControlStyle Width="200px" Height="100px"></ControlStyle>
                        </asp:ImageField>                      
                        <asp:BoundField HeaderText="客房类型" DataField="Ttype" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField HeaderText="床位数量" DataField="TbedNum" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField DataField="TairConditioning" HeaderText="空调" ControlStyle-Width="100%"></asp:BoundField>
                        <asp:BoundField DataField="Ttelevision" HeaderText="电视机" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField DataField="ThairDrier" HeaderText="电吹风" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField DataField="Tlandline" HeaderText="电话" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField DataField="Twifi" HeaderText="WIFI" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:BoundField HeaderText="每晚价格/￥" DataField="Rprice" ControlStyle-Width="100%"></asp:BoundField>             
                        <asp:BoundField HeaderText="备注" DataField="Rremark" ControlStyle-Width="100%"></asp:BoundField>
                        <asp:BoundField HeaderText="可预约数量" DataField="RvacantNum" ControlStyle-Width="100%" ></asp:BoundField>
                        <asp:CommandField HeaderText="操作" ShowSelectButton="True">
                            <ItemStyle BorderStyle="None" ForeColor="Blue" />
                        </asp:CommandField>
                    </Columns>

                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="BLACK" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#808080" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </div>
            <div class="right">
               <table>
                   <tr>
                       <th colspan="2">填写客房预订订单</th>
                   </tr>
                <tr>
                    <td>  姓名：</td>
                    <td>  <asp:TextBox ID="UserName" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>  联系方式：</td>
                    <td>  <asp:TextBox ID="Telephone" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>  身份证号：</td>
                    <td>  <asp:TextBox ID="CardId" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>  客房类型：</td>
                    <td>  <asp:TextBox ID="RoomType" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td>  预订数量：</td>
                    <td> <asp:TextBox ID="OrderNumber" runat="server" Height="30px" Width="100%" TextMode="Number" OnTextChanged="Calculate" AutoPostBack="True">1</asp:TextBox></td>
                </tr>
                 <tr>
                    <td>  入住日期：</td>
                    <td> <asp:TextBox ID="CheckInDate" runat="server" Height="30px" Width="100%" TextMode="Date"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>  入住时长：</td>
                    <td>  <asp:TextBox ID="StayDuration" runat="server" Height="30px" Width="80%" TextMode="Number" OnTextChanged="Calculate" AutoPostBack="True">1</asp:TextBox>晚</td>
                </tr>
                <tr>
                    <td> 预订金额：</td>
                    <td><asp:TextBox ID="Monetary" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td> 预订日期：</td>
                    <td><asp:TextBox ID="OrderDate" runat="server" Height="30px" Width="100%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"> <asp:Button ID="SubmitButton" runat="server" Text="提交订单" Width="100px" OnClick="Submit_Click"/></td>
                </tr>
              </table>
            </div>
          </div>       
  </form>
</body>
</html>


