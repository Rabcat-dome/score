<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="score.aspx.vb" Inherits="adminService.score" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PURCHASE SCORE</title>
    <style type="text/css">

        #div_main_width{
clear:both;
display:block;
position: absolute;
width: 995px;
left: 50%; margin-left: -497.5px;
height:1205px;
border: 0px solid #66CC99;
margin-top:0px;
-webkit-border-top-left-radius:0px;
-moz-border-radius-topleft:0px;
border-top-left-radius:0px;
-webkit-border-top-right-radius:0px;
-moz-border-radius-topright:0px;
border-top-right-radius:0px;
-webkit-border-bottom-left-radius:0px;
-moz-border-radius-bottomleft:0px;
border-bottom-left-radius:0px;
-webkit-border-bottom-right-radius:0px;
-moz-border-radius-bottomright:0px;
border-bottom-right-radius:0px;
margin-bottom:0px;
box-shadow: 0 0 15px #b2b2b2;
            top: 53px;
            margin-right: auto;
        }
.body1{ 
background-color:#ffffff;
background-repeat:no-repeat;
background-position:inherit;
background-attachment:fixed;
}
.main_text{
color:#4c4c4c;
font-family:Tahoma;
font-size:12px;
}
.BlockHeader_db_on_246 {
box-shadow: 0 0 3px #cccccc; background-image:url('images/shadow_both-2.png'); 
background-repeat:no-repeat;background-color:#;margin-right:3px;margin-top:10px;margin-left:3px;
}
.body2_module{ 
display:block;
height:100%;
overflow:hidden;
border-radius: 10px;
border-radius: 10px;
padding: 0px;
margin-bottom:5px;margin-left:5px;margin-top:3px;  
}

input { margin: 0px 3px 3px 3px;  
float: left; }
INPUT {
	    border: 1px solid #eae8e8;
           /* padding: 0.32em 0.15em;*/
            BACKGROUND: #f2f2f2;     -moz-border-radius: 0.4em;     -khtml-border-radius: 0.4em;     font-size:medium;    
border-radius: .5em;    color:#333333;    box-shadow: 0 0 3px #eae8e8;
            font-style: normal;
            font-variant: normal;
            font-weight: normal;
            line-height: normal;
            font-family: Tahoma;
            text-align: left;
        } 
 .clear {
	clear:both;
}
select { margin: 3px;  }
 
 select {
	BORDER-BOTTOM: #eae8e8 1px solid; BORDER-LEFT: #eae8e8 1px solid; PADDING-BOTTOM: 0.32em; PADDING-LEFT: 0.15em;  PADDING-RIGHT: 0.15em; FONT: normal 0.95em Tahoma; BACKGROUND: #f2f2f2; BORDER-TOP: #eae8e8 1px solid; BORDER-RIGHT: #eae8e8 1px solid; PADDING-TOP: 0.32em; -moz-border-radius: 0.4em; -khtml-border-radius: 0.4em; cursor:pointer;font-size:13px;border-radius: .5em;color:#333333;box-shadow: 0 0 3px #eae8e8;
}
 .radio{
	BORDER-BOTTOM: medium none; BORDER-LEFT: medium none; PADDING-BOTTOM: 0em; PADDING-LEFT: 0em; WIDTH: auto; PADDING-RIGHT: 0em; BORDER-TOP: medium none; BORDER-RIGHT: medium none; PADDING-TOP: 0em;
}
 textarea { margin: 3px;  float: left; }
 textarea {
	BORDER-BOTTOM: #eae8e8 1px solid; BORDER-LEFT: #eae8e8 1px solid; PADDING-BOTTOM: 0.32em; PADDING-LEFT: 0.15em;  PADDING-RIGHT: 0.15em; FONT: normal 0.95em Tahoma; BACKGROUND: #f2f2f2; BORDER-TOP: #eae8e8 1px solid; BORDER-RIGHT: #eae8e8 1px solid; PADDING-TOP: 0.32em; -moz-border-radius: 0.4em; -khtml-border-radius: 0.4em;font-size:13px;border-radius: .5em;color:#333333;box-shadow: 0 0 3px #eae8e8;
}
 a:link{ 
font-family:Tahoma;
font-size:12px;
color:#0072bc;
text-decoration:none;
font-weight:bold;
}
a{
font-family:Tahoma;
font-size:medium;
color:#0072bc;
text-decoration:none;
}
.small {
	font-size: 13px;font-weight:bold;
	padding: 0.42em 0.5em 0.42em; margin:3px;
}
.green {
color: #ffffff;
border: solid 1px #6cb2f7;box-shadow: 0 0 3px #6cb2f7;
background: #007fff;
background: -webkit-gradient(linear, left top, left bottom, from(#007fff), to(#6cb2f7));
background: -moz-linear-gradient(top,  #007fff,  #6cb2f7);
filter:  progid:DXImageTransform.Microsoft.gradient(startColorstr='#007fff', endColorstr='#6cb2f7');
}
span.info {
display:block;
margin-top:-5px;
padding:10px 10px 10px 45px; 
background:#D8E5F8 url('images/Info-icon.png') no-repeat 5px 50%;
border-bottom:3px solid #629DE3;
border-top:3px solid #629DE3;
color:#0055BB; float:right;
}
.column {
	float: left;
}
.leftback {
	float:left;
	overflow:hidden;
	position:relative;
}

.contentback {
	float:left;
	overflow:hidden;
	position:relative;
}
#div_main_bottom_link{
margin:0 auto;
display:block;
width: 995px;
height:auto; float:left;
overflow-x: hidden;
}

a.bottom:link{ 
font-family:Arial, Helvetica, sans-serif;
font-size:11px;
color:#666666;
text-decoration:none;
font-weight:inherit;
padding: 2px;
}
.footer1{
font-family:Tahoma, comic Sans MS, Arial, Helvetica;
font-size:13px;
background-repeat:no-repeat;
background-position:inherit;
display: table-cell; vertical-align:bottom;
height:65px;
text-align:center;
width: inherit;
}
        .style1
        {
            clear: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="PanelBack" runat="server" style="text-align: center" 
            Visible="False">
            <a href = scoreList.aspx >กลับหน้าหลัก</a>
        </asp:Panel>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" style="text-align: center" 
            Height="1200px" Width="1030px">
            <div class="body_border" sizcache07886327874903103="6" 
    sizset="0">
                <div id="div_main_width" class="body1 main_text" 
        sizcache07886327874903103="6" sizset="0">
                    <div id="div_main_right_no_left" 
            sizcache07886327874903103="6" sizset="0">
                        <div class="body2_module   BlockHeader_db_on_246" 
                sizcache07886327874903103="1" sizset="29">
                            <div sizcache07886327874903103="1" sizset="29" 
                    style="PADDING-BOTTOM: 5px; PADDING-TOP: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px">
                                <div class="BlockHeader_db_in_246 border-radius" 
                        sizcache07886327874903103="1" sizset="29">
                                    <div id="imagesdiv" 
                            style="PADDING-BOTTOM: 3px; PADDING-TOP: 3px; PADDING-LEFT: 3px; PADDING-RIGHT: 3px">
                                        <table border="0" cellpadding="1" cellspacing="0" 
                                width="100%">
                                            <tr>
                                                <td>
                                                    <div style="TEXT-ALIGN: center">
                                                        <strong>
                                                        <span 
                                                style="FONT-SIZE: 16px">แบบสำรวจความพึงพอใจแผนกจัดซื้อ<br />
                                                        </span></strong>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <asp:Image ID="Image1" runat="server" Height="17px" 
                                            ImageUrl="~/images/Info-icon.png" Width="23px" />
                                        <strong>&nbsp;วัตถุประสงค์: </strong>
                                        แบบสอบถามนี้มีวัตถุประสงค์เพื่อสำรวจความพึงพอใจของผู้รับบริการที่มีต่อการให้บริการ<br />
                                        และนำผลการประเมินไปพัฒนาปรับปรุงแก้ไขงานให้มีคุณภาพอย่างต่อเนื่อง
                                        <br />
                                        <br />
                                        <b><span class="style5">สถานะ : </span><span class="style4">
                                        <span class="style5">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                        &nbsp;<br />
                                        </span></span></b>
                                    </div>
                                    <div 
                            style="padding: 5px; text-align: left;">
                                        <b>PO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</b>
                                        <asp:Label ID="lblPoNum" runat="server" style="font-weight: 700"></asp:Label>
                                        <b><span class="style4">
                                        <br />
                                        </span><span class="style11">
                                        <br />
                                        Vender&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                                        <asp:Label ID="lblVender" runat="server"></asp:Label>
                                        <br />
                                        <br />
                                        Short Text&nbsp;&nbsp;&nbsp;&nbsp; :
                                        <asp:Label ID="lblShotText" runat="server"></asp:Label>
                                        <br />
                                        <br />
                                        date sent&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
                                        <asp:Label ID="lblDateSend" runat="server"></asp:Label>
                                        <br />
                                        <br />
                                        date Modify&nbsp;&nbsp;&nbsp; :
                                        <asp:Label ID="lblDateAns" runat="server"></asp:Label>
                                        </span><span class="style4">
                                        <br />
                                        <br />
                                        <table align="center" class="style6">
                                            <tr>
                                                <td class="style9">
                                                    &nbsp;</td>
                                                <td class="style7">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style8">
                                                    <div style="text-align: left">
                                                        <strong>ผู้ขอ (Mail to)</strong></div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <div style="text-align: left">
                                                        <strong>Buyer</strong></div>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style9">
                                                    &nbsp;</td>
                                                <td class="style7">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style8">
                                                    <strong>
                                                    <asp:TextBox ID="txtUserReq" runat="server" Enabled="False" Font-Size="Large" 
                                                        Width="121px"></asp:TextBox>
                                                    </strong>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtBuyer" runat="server" Enabled="False" Font-Size="Large" 
                                                        Width="121px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                        </span></b><div class="clear">
                                        </div>
                                    </div>
                                    <div 
                            style="PADDING-BOTTOM: 5px; PADDING-TOP: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px">
                                        &nbsp;</div>
                                    <span style="MARGIN: 5px" class="style3"><strong><u><span class="style3">ระดับการประเมิน</span></u><span 
                                        class="style3"> : </span> </strong><span class="style3">5=ดีมาก&nbsp;&nbsp; 
                                    4=ดี&nbsp;&nbsp;3=มาตรฐาน&nbsp;&nbsp;2=ต่ำกว่ามาตรฐาน&nbsp;&nbsp;1=ต่ำกว่ามาตรฐานมาก</span><span 
                                        class="style2">&nbsp;&nbsp; </span> </span>
                                    &nbsp;<table bgcolor="#cccccc" cellpadding="3" cellspacing="1" 
                            width="100%" style="height: 668px">
                                        <tr bgcolor="#f0f0f0">
                                            <td align="center" colspan="2" height="35">
                                                <strong>หัวข้อ</strong></td>
                                            <td align="center" width="10%">
                                                <strong>5</strong></td>
                                            <td align="center" width="10%">
                                                <strong>4</strong></td>
                                            <td align="center" width="10%">
                                                <strong>3</strong></td>
                                            <td align="center" width="10%">
                                                <strong>2</strong></td>
                                            <td align="center" width="10%">
                                                <strong>1</strong></td>
                                            <td align="center" width="10%">
                                                <strong>ข้อเสนอแนะอื่นๆ</strong></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left" colspan="8" height="30">
                                                <b>คุณภาพการให้บริการของเจ้าหน้าที่จัดซื้อฯ</b></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                1</td>
                                            <td width="45%" style="text-align: left">
                                                ความรู้ ความเข้าใจ ในสินค้า/บริการ</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo1_5" runat="server" GroupName="1" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo1_4" runat="server" GroupName="1" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo1_3" runat="server" GroupName="1" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo1_2" runat="server" GroupName="1" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo1_1" runat="server" GroupName="1" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                2</td>
                                            <td width="45%" style="text-align: left">
                                                ความช่วยเหลือในการแก้ไขปัญหา รวมถึงการให้ข้อมูลที่ถูกต้องครบถ้วน</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo2_5" runat="server" GroupName="2" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo2_4" runat="server" GroupName="2" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo2_3" runat="server" GroupName="2" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo2_2" runat="server" GroupName="2" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo2_1" runat="server" GroupName="2" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff"  style=" height:30px " >
                                            <td align="center" width="3%">
                                                3&nbsp;</td>
                                            <td width="45%" style="text-align: left">
                                                อัธยาศัยและความเอาใจใส่ในการให้บริการ</td>
                                            <td align="center" width="10%" class="style2">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo3_5" runat="server" GroupName="3" 
                                                            style="font-size: small" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%" class="style2">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo3_4" runat="server" GroupName="3" 
                                                            style="font-size: small" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%" class="style2">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo3_3" runat="server" GroupName="3" 
                                                            style="font-size: small" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%" class="style2">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                        <asp:RadioButton ID="rdo3_2" runat="server" GroupName="3" 
                                                            style="font-size: small" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td align="center" width="10%" class="style2">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo3_1" runat="server" GroupName="3" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%" class="style2">
                                                <asp:TextBox ID="txtComment3" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" height="30" style="background-color: #FFFFFF" width="3%" 
                                                class="style5">
                                                4</td>
                                            <td class="style5" style="text-align: left; background-color: #FFFFFF;" 
                                                width="45%">
                                                ระยะเวลาในการให้บริการ</td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo4_5" runat="server" GroupName="4" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo4_4" runat="server" GroupName="4" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo4_3" runat="server" GroupName="4" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo4_2" runat="server" GroupName="4" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo4_1" runat="server" GroupName="4" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%"; style="background-color: #FFFFFF;">
                                                <asp:TextBox ID="txtComment4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="left" colspan="8" height="30">
                                                <b>คุณภาพของสินค้า/บริการ</b></td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                5</td>
                                            <td width="45%" style="text-align: left">
                                                ความถูกต้องของใบสั่งซื้อ/สัญญา</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo5_5" runat="server" GroupName="5" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo5_4" runat="server" GroupName="5" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo5_3" runat="server" GroupName="5" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo5_2" runat="server" GroupName="5" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo5_1" runat="server" GroupName="5" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment5" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                6</td>
                                            <td width="45%" style="text-align: left">
                                                ระยะเวลาในการออกใบสั่งซื้อ/สัญญา</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo6_5" runat="server" GroupName="6" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo6_4" runat="server" GroupName="6" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo6_3" runat="server" GroupName="6" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo6_2" runat="server" GroupName="6" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo6_1" runat="server" GroupName="6" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment6" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                7</td>
                                            <td width="45%" style="text-align: left">
                                                ระยะเวลาการได้รับสินค้า/บริการตามกำหนด</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo7_5" runat="server" GroupName="7" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo7_4" runat="server" GroupName="7" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo7_3" runat="server" GroupName="7" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo7_2" runat="server" GroupName="7" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo7_1" runat="server" GroupName="7" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment7" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                8</td>
                                            <td width="45%" style="text-align: left">
                                                ความถูกต้องของสินค้า/บริการที่ได้รับ</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo8_5" runat="server" GroupName="8" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo8_4" runat="server" GroupName="8" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo8_3" runat="server" GroupName="8" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo8_2" runat="server" GroupName="8" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo8_1" runat="server" GroupName="8" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment8" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                9</td>
                                            <td width="45%" style="text-align: left">
                                                ความเหมาะสมของราคาสินค้า/บริการที่ได้รับ</td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo9_5" runat="server" GroupName="9" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo9_4" runat="server" GroupName="9" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo9_3" runat="server" GroupName="9" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo9_2" runat="server" GroupName="9" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo9_1" runat="server" GroupName="9" />
                                                </div>
                                            </td>
                                            <td align="center" width="10%">
                                                <asp:TextBox ID="txtComment9" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style5" height="30" width="3%"  
                                                style="background-color: #FFFFFF;">
                                                10</td>
                                            <td class="style5" style="text-align: left; background-color: #FFFFFF;" 
                                                width="45%; background-color: #FFFFFF;">
                                                ความพึงพอใจโดยรวมต่อสินค้า/บริการที่ได้รับ</td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo10_5" runat="server" GroupName="10" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo10_4" runat="server" GroupName="10" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo10_3" runat="server" GroupName="10" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo10_2" runat="server" GroupName="10" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <div style="WIDTH: 20px; TEXT-ALIGN: center">
                                                    <asp:RadioButton ID="rdo10_1" runat="server" GroupName="10" 
                                                        style="font-size: small" />
                                                </div>
                                            </td>
                                            <td align="center" class="style2" width="10%" style="background-color: #FFFFFF;">
                                                <asp:TextBox ID="txtComment10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                &nbsp;</td>
                                            <td style="text-align: left" width="45%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                <b>Total</b></td>
                                            <td align="center" style="text-align: center" width="10%">
                                                <asp:Label ID="lblTotal" runat="server" 
                                                    style="font-weight: 700; font-size: medium; text-align: center"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#ffffff">
                                            <td align="center" height="30" width="3%">
                                                &nbsp;</td>
                                            <td width="45%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                <asp:Button ID="btnSave" runat="server" BackColor="#3399FF" ForeColor="White" 
                                                    Text="บันทึกข้อมูล" Width="80px" />
                                            </td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                            <td align="center" width="10%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <br />
                                    
                                    
                                    <b><span class="style2">
                                    “แผนกจัดซื้อและสัญญาขอขอบคุณทุกความร่วมมือสำหรับการตอบแบบสอบถามในครั้งนี้ We 
                                    value your comments”</span></b>
                                    
                                    <div class="clear">
                                        <br />
                                        <span class="style1"><span class="style13">
                                        <br />
                                        **ติดต่อผู้พัฒนาระบบ วีระวัฒน์ 
                                        วิไลศิริ (WRW) แผนก IS โทร.1256**<br />
                                        </span></span></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="column">
                        <div class="leftback column">
                            <div id="div_main_left">
                                <style type="text/css">


ul#menu li {
margin-top: 0px; width:225px;}
</style>
                            </div>
                        </div>
                        <div id="div_main_right">
                        </div>
                    </div>
                    <div id="div_main_right_no_left0">
                    </div>
                    <div style="CLEAR: both">
                    </div>
                </div>
            </div>
            <br class="style1" />
        </asp:Panel>
    
    </div>
    <br />
                                        <span class="style1"><span class="style13">
                                        <center>
                                        <asp:Panel ID="PanelAdmin" runat="server" 
                                            
        style="font-size: medium; background-color: #FFFF00; text-align: center;" Visible="False" 
                                            Width="976px">
                                            <span class="style5">สำหรับ Admin :&nbsp;สามารถส่ง Email ใหม่ / เปลี่ยนผู้รับได้&nbsp;
                                            </span>
                                            <b><span class="style4">
                                            <asp:Label ID="lblEmail" runat="server" ForeColor="Red" 
                                                style="text-align: left; font-weight: 700; font-size: large;" 
                                                Visible="False"></asp:Label>
                                            <table align="center" class="style6">
                                                <tr>
                                                    <td class="style9">
                                                        &nbsp;</td>
                                                    <td class="style7">
                                                        &nbsp;</td>
                                                    <b><span class="style4">
                                                    <td class="style8">
                                                        <div style="text-align: left">
                                                            <strong>ผู้ขอ</strong></div>
                                                    </td>
                                                    </span></b>
                                                    <td class="style8">
                                                        <strong>
                                                        <asp:TextBox ID="txtInt" runat="server" Font-Size="Large" 
                                                            Width="48px"></asp:TextBox>
                                                        </strong>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnResend" runat="server" BackColor="Lime" 
                                                            Text="Resend Mail" />
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            </span></b>
                                        </asp:Panel>
                                        </center>
                                        </span></span>
    <asp:Panel ID="Panel2" runat="server" style="text-align: center" 
        Visible="False">
        <br />
        <br />
        <br />
        <br />
        <br />
        <span class="style3">บันทึกสำเร็จ!!&nbsp;&nbsp;&nbsp; ขอบคุณที่ท่านสละเวลาตอบแบบสอบถาม</span><br 
            class="style2" />
        <br />
        <a href="javascript: window.close()">ปิดหน้านี้</a><br />
        <br />
        <br />
        <br />
    </asp:Panel>
    </form>
</body>
</html>
