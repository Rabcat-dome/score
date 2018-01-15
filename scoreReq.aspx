<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="scoreReq.aspx.vb" Inherits="adminService.scoreReq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PURCHASE SCORE</title>
    <style type="text/css">

        .style5
        {
            font-weight: normal;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style2
        {
            font-size: small;
        }
        .style4
        {
            font-size: small;
            font-weight: normal;
        }
        
        .style6
        {
            font-size: small;
            font-weight: bold;
        }
        .style8
        {
            color: #0066FF;
        }
        .style9
        {
            font-weight: bold;
        }
        .style10
        {
            font-size: large;
            font-weight: normal;
            text-decoration: underline;
        }
        
        
      
INPUT {
	    border: 1px solid #eae8e8;
            padding: 0.32em 0.15em;
            BACKGROUND: #f2f2f2;     -moz-border-radius: 0.4em;     -khtml-border-radius: 0.4em;     font-size:13px;    border-radius: .5em;    color:#333333;    box-shadow: 0 0 3px #eae8e8;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            line-height: normal;
            font-family: Tahoma;
            text-align: center;
            margin-top: 0px;
        } 
        
        .style11
        {
            text-decoration: underline;
        }
        .style1
        {
            font-size: small;
        }
        .style13
        {
            color: #666666;
        }
                
        .style14
        {
            width: 100%;
        }
        .style15
        {
            width: 247px;
            text-align: left;
        }
        .style16
        {
            width: 273px;
            text-align: right;
        }
        .style17
        {
            width: 273px;
            text-align: right;
            height: 36px;
        }
        .style18
        {
            width: 247px;
            height: 36px;
            text-align: left;
        }
        .style19
        {
            height: 36px;
        }
                
        .style20
        {
            color: #000000;
            font-weight: bold;
            font-size: medium;
        }
        .style21
        {
            color: #0000FF;
        }
                
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
            <span class="style4">
            <asp:DropDownList ID="dplStatusItem" runat="server" BackColor="#FFFFCC" 
                CssClass="style2" Height="22px" Width="128px" Visible="False">
            </asp:DropDownList>
            </span>
    
        <br />
        <span class="style9"><span class="style11">PURCHASE SCORE</span><br />
        </span><span class="style20">Send E-mail to Requisitioner<br />
        </span><br />
                <span class="style21"><a href="scoreList.aspx">เรียกดูแบบสำรวจความพึงพอใจทั้งหมด</a></span><br />
        <br />
        <center>
        <asp:Panel ID="Panel1" runat="server" BackColor="#F9F9F9" Width="1141px">
            
                <ContentTemplate>
                    <b>
                    <br />
                    Search :</b>&nbsp;&nbsp; <span class="style5"><span class="style2"><i>PO No.</i> </span>
                    </span>
                    <asp:TextBox ID="txtPrNO" runat="server" BackColor="#FFFFCC" CssClass="style2"></asp:TextBox>
                    &nbsp; <span class="style5"><span class="style2"><i>Requisitioner</i> </span></span>
                    <asp:TextBox ID="txtRequest" runat="server" BackColor="#FFFFCC" 
                        CssClass="style2"></asp:TextBox>
                    &nbsp;&nbsp; <span class="style4"><i>Buyer</i> </span>
                    <asp:TextBox ID="txtBuyer" runat="server" BackColor="#FFFFCC" CssClass="style2"></asp:TextBox>
                    &nbsp;<span class="style4">&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" 
                        BackColor="#0066FF" CssClass="style2" ForeColor="White" Height="27px" 
                        Text="Search" Width="119px" />
                    <br />
                    &nbsp;<asp:Panel ID="Panel2" runat="server" CssClass="style8" Width="925px">
                        <span class="style4">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" PageSize="20" style="text-align: center" Width="918px">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="PO_No" HeaderText="PO_No" />
                                <asp:BoundField DataField="Item_No" HeaderText="Item_No" />
                                <asp:BoundField DataField="PO_Type" HeaderText="PO_Type" />
                                <asp:BoundField DataField="Issue_Date" HeaderText="Issue_Date" />
                                <asp:BoundField DataField="Vendor_Name" HeaderText="Vendor_Name" />
                                <asp:BoundField DataField="Buyer" HeaderText="Buyer" />
                                <asp:BoundField DataField="Short_Text" HeaderText="Short_Text" />
                                <asp:BoundField DataField="Plant" HeaderText="Plant" />
                                <asp:BoundField DataField="Requisitioner" HeaderText="Requisitioner" />
                                <asp:BoundField DataField="Status_Name" HeaderText="Status_Name" />
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        </span>
                        <asp:Image ID="Image1" runat="server" Height="22px" 
                            ImageUrl="~/images/Info-icon.png" Width="26px" />
                        <span class="style4"><span class="style8">คลิกเพื่อเลือกรายการจากตาราง !</span></span><br />
                    </asp:Panel>
                    </span>
                </ContentTemplate>
            
            <span class="style4">
            <br />
            <asp:Panel ID="Panel3" runat="server" BackColor="#E1FFFF" Width="612px">
                <span class="style6"><span class="style4"><span class="style9">
                <span class="style10">Select E-mail </span></span></span>
                <br />
                </span>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <span class="style4">PO No.
                        <asp:Label ID="lblPo" runat="server" ForeColor="Red" 
                            style="font-weight: 700; font-size: large" Text="--Please Select--"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;<br />
                        Short Text.&nbsp;<asp:TextBox ID="txtVenderName" runat="server" Width="344px"></asp:TextBox>
&nbsp;<table class="style14">
                            <tr>
                                <td class="style16">
                                    &nbsp;</td>
                                <td class="style15">
                                    &nbsp;</td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style16">
                                    <span class="style4">user :&nbsp;&nbsp; </span>
                                </td>
                                <td class="style15">
                                    <span class="style4">
                                    <asp:TextBox ID="txtInt" runat="server" AutoPostBack="True" BackColor="#FFFFCC" 
                                        BorderColor="#999999" BorderWidth="1px" Width="48px"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="btnSearchMail" runat="server" BackColor="#CC0066" 
                                        ForeColor="White" Height="26px" Text="Search New E-mail" Width="125px" />
                                    </span>
                                </td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style17">
                                    <span class="style4">E-mail :&nbsp;&nbsp; </span>
                                </td>
                                <td class="style18">
                                    <span class="style4">
                                    <asp:Label ID="lblEmail" runat="server" ForeColor="Red" 
                                        style="text-align: left; font-weight: 700; font-size: large;"></asp:Label>
                                    </span>
                                </td>
                                <td class="style19" style="text-align: left">
                                </td>
                            </tr>
                        </table>
                        </span>
                    
                    <br />
                    
                    </ContentTemplate>
                                       
                </asp:UpdatePanel>
                
                
            </asp:Panel>
                <br />
                <asp:Button ID="btnSend" runat="server" BackColor="#999999" CssClass="style2" 
                    Enabled="False" ForeColor="White" Height="27px" Text="Send" Width="119px" />
            <br />
            </span>
            <br />
                <br />
                <span class="style1"><span class="style13">**ติดต่อผู้พัฒนาระบบ วีระวัฒน์ 
                วิไลศิริ (WRW) แผนก IS โทร.1256**</span></span><br />
                <br />
        </asp:Panel>
        </center>
        
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
