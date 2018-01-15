<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="scoreList.aspx.vb" Inherits="adminService.scorelist" %>

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
        
        .style8
        {
            color: #0066FF;
        }
        .style9
        {
            font-weight: bold;
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
            color: #33CC33;
        }
                
        .style15
        {
            font-size: small;
            color: #0066FF;
        }
        .style16
        {
            font-size: small;
            color: #0066FF;
            font-weight: bold;
        }
                        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <a href = scoreReq.aspx ><span class="style16">กลับหน้าหลัก</span></a><br 
            class="style15" />
    
        <br />
        <span class="style9"><span class="style11">PURCHASE SCORE</span><br />
        <br />
        <span class="style14">รายการทั้งหมด</span></span><br />
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
                    <asp:TextBox ID="txtBuyer" runat="server" BackColor="#FFFFCC" 
                        CssClass="style2"></asp:TextBox>
                    &nbsp;<span class="style4">&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" 
                        BackColor="#0066FF" CssClass="style2" ForeColor="White" Height="27px" 
                        Text="Search" Width="119px" />
                    <br />
                    &nbsp;<asp:Panel ID="Panel2" runat="server" CssClass="style8" Width="1108px">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" PageSize="50" style="text-align: center" Width="1100px">
                            <RowStyle BackColor="#EFF3FB" />
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="ID" />
                                <asp:BoundField DataField="poNum" HeaderText="PO" >
                                </asp:BoundField>
                                <asp:BoundField DataField="ShortText" HeaderText="ShortText" />
                                <asp:BoundField DataField="VenderName" HeaderText="VenderName" />
                                <asp:BoundField DataField="buyerName" HeaderText="buyer" />
                                <asp:BoundField DataField="reqUserName" HeaderText="requisitioner" />
                                <asp:BoundField DataField="senderUserName" HeaderText="Sender" />
                                <asp:BoundField DataField="StatusName" HeaderText="Status" />
                                <asp:BoundField DataField="total" HeaderText="score"  
                                    DataFormatString="{0:###.##}"  >
                                    <ItemStyle ForeColor="#33CC33" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dateSent" HeaderText="Sent Date" 
                                    DataFormatString="{0:dd/MM/yyyy}"  ControlStyle-Width="100px" >
                                   
                                    <controlstyle width="100px" />
                                </asp:BoundField>
                                   
                                <asp:BoundField DataField="dateModify" HeaderText="Modify Date" 
                                    DataFormatString="{0:dd/MM/yyyy}"  ControlStyle-Width="100px"  >
                                    
                                    <controlstyle width="100px" />
                                </asp:BoundField>
                                    
                                <asp:HyperLinkField DataNavigateUrlFields="link1" Text="View" >
                                    <ItemStyle Width="100px" />
                                </asp:HyperLinkField>
                            </Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                    </asp:Panel>
                    </span>
                </ContentTemplate>
            
            <span class="style4">
            <br />
            <br />
            </span>
            <br />
            <br />
        </asp:Panel>
        </center>
        
        <br />
                            <span class="style1"><span class="style13">**ติดต่อผู้พัฒนาระบบ วีระวัฒน์ 
                            วิไลศิริ (WRW) แผนก IS โทร.1256**</span></span><br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
