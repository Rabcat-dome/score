Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration

Imports System.Web.Mail
Imports System.Web.Mail.SmtpMail

Partial Public Class scoreReq
    Inherits System.Web.UI.Page

    Dim dbconn As dbaseClass = New dbaseClass
    Dim dbconn2 As dbaseClass2 = New dbaseClass2
    Dim crypt1 As crypClass = New crypClass
    Dim crypt2 As crypClass = New crypClass
    Dim sql1 As String = ""
    Dim adapter1 As SqlDataAdapter
    Dim dataset1 As New DataSet
    Dim sql2 As String = ""
    Dim adapter2 As SqlDataAdapter
    Dim dataset2 As New DataSet

    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim str As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dbconn.ConfirmBox(Me.btnSend, "ยืนยันการส่งแบบสอบถาม!! ")

        If Session("Member_User") = Nothing Then '********  ต้อง login
            Response.Redirect("default.aspx")
        End If


        If Not Page.IsPostBack Then

            setSelect()
            'list()

        End If
    End Sub
    Sub setSelect()



        sql1 = "select *  from Predefine "
        sql1 &= " where  Predefine_Group = 'PO_Status'"
        Me.dplStatusItem.DataSource = dbconn.GetDataTable(sql1)
        Me.dplStatusItem.DataValueField = "Predefine_CD"
        Me.dplStatusItem.DataTextField = "Predefine_Desc"
        Me.dplStatusItem.DataBind()
        Me.dplStatusItem.Items.Insert(0, "--ALL--")




    End Sub

    Sub list()




        sql1 = "DECLARE	@return_value int "
        sql1 &= " EXEC @return_value = [dbo].[sp_PO_Export]"

        If txtPrNO.Text.Trim <> "" Then
            sql1 &= " @PO_No = " & Me.txtPrNO.Text.Trim & ","
        Else
            sql1 &= " @PO_No = NULL,"
        End If



       
        sql1 &= " @Hdr_Status = 99," ' Delivery Completed


        sql1 &= " @Det_Status = NULL,"





        sql1 &= " @PR_No = NULL,"
        sql1 &= " @Vendor_Name = NULL,"
        sql1 &= " @Tracking_No = NULL,"
        
       


        

        If txtRequest.Text.Trim <> "" Then
            sql1 &= " @Requisitioner = " & Me.txtRequest.Text.Trim & ","
        Else
            sql1 &= " @Requisitioner = NULL,"
        End If

        'If txtCreater.Text.Trim <> "" Then
        '    sql1 &= " @PR_Creator = " & Me.txtCreater.Text.Trim & ","
        'Else
        sql1 &= " @PR_Creator = NULL,"
        'End If


        If txtBuyer.Text.Trim <> "" Then
            sql1 &= " @Buyer = " & Me.txtBuyer.Text.Trim & ","
        Else
            sql1 &= " @Buyer = NULL,"
        End If

        sql1 &= " @Material_Group = NULL,"
        sql1 &= " @Material_CD = NULL,"
        sql1 &= " @Short_Text = NULL,"
      

        sql1 &= " @Issue_Date_From = NULL,"
        sql1 &= " @Issue_Date_To = NULL,"
        sql1 &= " @Delivery_Date_From = NULL,"
        sql1 &= " @Delivery_Date_To = NULL,"
        sql1 &= " @Posting_Date_From = NULL,"
        sql1 &= " @Posting_Date_To = NULL,"


        sql1 &= " @Section_CD = NULL,"
        sql1 &= " @Department_CD = NULL "
        sql1 &= " SELECT	'Return Value' = @return_value"




        dt1 = dbconn.GetDataTable(sql1)
        If dt1.Rows.Count > 0 Then




            'Me.GridView1.DataSource = dt1
            'Me.GridView1.DataSource = dt1.Select("", "PO_No desc")
            Dim dv As DataView
            dv = dt1.DefaultView


            Me.GridView1.DataSource = dv


            dv.Sort = "PO_No desc, Item_No asc"


            Me.GridView1.DataBind()

        End If
        'dt.DefaultView.Sort = dt.Columns[0].ColumnName + " asc";

    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        If txtPrNO.Text.Trim = "" And txtRequest.Text.Trim = "" And txtBuyer.Text.Trim = "" Then
            dbconn.MessageAlert(Me, "กรุณากรอกข้อมูลค้นหา อย่างน้อย 1 อย่าง !!")

        Else
            list()
        End If
        'txtCreater.Text.Trim = "" And

    End Sub

    Protected Sub btnSearchMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearchMail.Click
        serchEmail()
        serchEmail()
        serchEmail()
    End Sub

    Sub serchEmail()


        sql1 = "select * from TLService.dbo.Employees"
        sql1 &= " where  TLService.dbo.Employees.Member_username = '" & LCase(txtInt.Text.Trim) & "'"


        dt2.Clear()
        dt2 = dbconn2.GetDataTable(sql1)
        If dt2.Rows.Count > 0 Then
            Me.lblEmail.Text = dt2.Rows(0).Item("Member_email") & "@thappline.co.th"
            Me.btnSend.Enabled = True
            Me.btnSend.BackColor = Color.MediumBlue
        Else
            lblEmail.Text = "** ไม่พบ Email ของ User นี้ **"
            Me.btnSend.Enabled = False
            Me.btnSend.BackColor = Color.LightGray
        End If


    End Sub

    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        list()
    End Sub



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        selectRow()
        serchEmail()
    End Sub
    Sub selectRow()
        Me.txtInt.Text = GridView1.Rows(GridView1.SelectedIndex).Cells(9).Text.Trim   '  requester
        Me.lblPo.Text = GridView1.Rows(GridView1.SelectedIndex).Cells(1).Text.Trim

        Me.txtVenderName.Text = GridView1.Rows(GridView1.SelectedIndex).Cells(5).Text.Trim

    End Sub


    Sub saveList()
        'PO_No	Item_No	PO_Type	Issue_Date	Vendor_Name	Buyer	Short_Text	Plant	Requisitioner	Status_Name

        Dim PO_No As String
        Dim Issue_Date As Date
        Dim Vendor_Name As String
        Dim Buyer As String
        Dim Short_Text As String
        Dim reqUserName As String

        PO_No = GridView1.Rows(GridView1.SelectedIndex).Cells(1).Text.Trim
        Issue_Date = GridView1.Rows(GridView1.SelectedIndex).Cells(4).Text.Trim
        'Vendor_Name = GridView1.Rows(GridView1.SelectedIndex).Cells(5).Text.Trim
        Vendor_Name = Me.txtVenderName.Text.Trim
        Buyer = GridView1.Rows(GridView1.SelectedIndex).Cells(6).Text.Trim
        Short_Text = GridView1.Rows(GridView1.SelectedIndex).Cells(7).Text.Trim


        'reqUserName = GridView1.Rows(GridView1.SelectedIndex).Cells(9).Text.Trim   '  requester

        reqUserName = txtInt.Text.Trim



        '################################ check unuqe


        sql1 = "select * from score_head"
        sql1 &= " where  poNum = " & PO_No
        sql1 &= " and  VenderName = '" & Vendor_Name & "'"

        dt1.Clear()
        dt1 = dbconn2.GetDataTable(sql1)
        If dt1.Rows.Count > 0 Then
            dbconn.MessageAlert(Me, "PO : " & PO_No & " และ VenderName : " & Vendor_Name & vbCrLf & "เคยมีการส่งแบบสอบถามไปแล้ว กรุณาตรวจสอบที่หน้ารายการครับ !! ")
            Exit Sub
        End If


        '##############################




        Dim ID As String
        ID = dbconn2.GetID("score_head", "id")
        '*****************************************


        Dim cnAdmin = New System.Data.SqlClient.SqlConnection
        cnAdmin.ConnectionString = ConfigurationManager.ConnectionStrings("TAFWEBConnectionString").ConnectionString
        cnAdmin.Open()



        Dim cmd = New SqlCommand(sql1, cnAdmin)
        cmd.Transaction = cnAdmin.BeginTransaction '##
        Try

            sql1 = "insert into score_head(id,poNum,VenderName,ShortText,buyerName,reqUserId,reqUserName,senderUserId,senderUserName,StatusId,total,dateSent) " ',dateModify
            sql1 &= " Values(" & ID
            sql1 &= "," & PO_No & ""
            sql1 &= ",'" & Vendor_Name & "'"
            sql1 &= ",'" & Short_Text & "'"
            sql1 &= ",'" & UCase(Buyer) & "'"
            sql1 &= ",''" '" & reqUserId & "
            sql1 &= ",'" & UCase(reqUserName) & "'"
            sql1 &= ",''" '" & reqUserId & "
            sql1 &= ",'" & UCase(Session("Member_User")) & "'"
            sql1 &= ",1" ' waitting
            sql1 &= ",0" 'total
            sql1 &= ",'" & Format(Now, "MM/dd/yyyy H:mm:ss") & "'"
            sql1 &= " )"




            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()

            cmd.Transaction.Commit()



            sendEmail(ID) '**********


            Me.txtInt.Text = ""
            Me.lblPo.Text = ""
            Me.lblEmail.Text = ""
            Me.txtVenderName.Text = ""
            Me.GridView1.SelectedIndex = -1

        Catch ex As Exception
            cmd.Transaction.Rollback() '##
            dbconn.MessageAlert(Me, ex.Message)
            Exit Sub
        End Try







    End Sub


    Sub sendEmail(ByVal ID As String)

        '"<font color = red>แบบสอบถามความพึงพอใจ  จากระบบ Purchase Score!!</font><br>" _
        '   & "
        'System.Configuration.ConfigurationSettings.AppSettings("user_recive_mail")
        Try

            Dim str As String = "<font size = 10 color = blue>ขอความกรุณาตอบแบบสอบถามความพึงพอใจ</font><br>" _
            & "<font size = 8> PO เลขที่ : </font><font color=Magenta size=8>" & lblPo.Text.Trim & "</font><br>" _
            & "<font size = 8> ผู้ส่ง:</font><font color=Magenta size=10> " & Session("Member_User") & " </font>" _
            & "<br><br><font size=8 color=red>ตอบแบบสอบถาม</font> <font size=8 color=blue><a href='http://thapp/score/score.aspx?id=" & ID & "'>คลิกที่นี่</a></font>"
            sendmail("Purchase@thappline.co.th", lblEmail.Text.Trim, "แบบสอบถามความพึงพอใจ  จากระบบ Purchase Score!!", str)



            'dbconn.MessageAlert(Me, "ส่ง Email สำเร็จ!!")



        Catch ex As Exception
            'cmd.Transaction.Rollback()
            dbconn.MessageAlert(Me, "เกิดข้อผิดพลาด ระบบไม่สามารถส่ง E-mailได้ กรุณาโทรติดต่อผู้รับแจ้งโดยตรง!!" & vbCrLf & ex.Message)
            Exit Sub
        End Try


    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click

        serchEmail()


        saveList()



       
    End Sub

    Sub sendmail(ByVal emailForm As String, ByVal emailTo As String, ByVal title As String, ByVal str As String)
        Dim oMsg As New MailMessage
        Dim oMailSrv As SmtpMail

        oMsg.BodyFormat = MailFormat.Html
        oMsg.Priority = MailPriority.Normal
        oMsg.From = emailForm
        oMsg.To = emailTo
        oMsg.Subject = title
        oMsg.Body = str
        oMsg.BodyEncoding = System.Text.Encoding.UTF8
        oMailSrv.SmtpServer = Trim(System.Configuration.ConfigurationSettings.AppSettings("smtp"))


        Try
            oMailSrv.Send(oMsg)

            dbconn.MessageAlert(Me, "ระบบได้ส่งอีเมลล์" & emailTo & " เรียบร้อย !!")
        Catch ex As Exception
            dbconn.MessageAlert(Me, "ระบบไม่สามารถส่ง ไปยังอีเมลล์ " & emailTo & " ได้ " & vbCrLf & ex.Source)
        End Try
        '--------------------------------------------------------------------


    End Sub

End Class