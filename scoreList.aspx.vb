Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration

Imports System.Web.Mail
Imports System.Web.Mail.SmtpMail

Partial Public Class scoreList
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

        'dbconn.ConfirmBox(Me.btnSend, "ยืนยันการส่งแบบสอบถาม!! ")
        If Session("Member_User") = Nothing Then '********  ต้อง login
            Response.Redirect("default.aspx")
        End If


        If Not Page.IsPostBack Then

            'setSelect()
            list()

        End If
    End Sub
    'Sub setSelect()



    '    sql1 = "select *  from Predefine "
    '    sql1 &= " where  Predefine_Group = 'PO_Status'"
    '    Me.dplStatusItem.DataSource = dbconn.GetDataTable(sql1)
    '    Me.dplStatusItem.DataValueField = "Predefine_CD"
    '    Me.dplStatusItem.DataTextField = "Predefine_Desc"
    '    Me.dplStatusItem.DataBind()
    '    Me.dplStatusItem.Items.Insert(0, "--ALL--")




    'End Sub

    Sub list()




        'sql1 = "select "
        'sql1 &= " EXEC @return_value = [dbo].[sp_PO_Export]"
        'dt1 = dbconn.GetDataTable(sql1)

        'sql1 = "select * , ((total * 100) / 5) as total  , 'score.aspx?id=' + CAST(ID AS VARCHAR) + '&v=t' as link1 from score_head, status1"
        'sql1 = "select * , total * 20 as total  , 'score.aspx?id=' + CAST(ID AS VARCHAR) + '&v=t' as link1 from score_head, status1"
        ' sql1 &= " where score_head.statusId = status1.statusId "


        sql1 = "select *   , 'score.aspx?id=' + CAST(ID AS VARCHAR) + '&v=t' as link1 from score_head, status1"
        sql1 &= " where score_head.statusId = status1.statusId "




        If txtPrNO.Text.Trim <> "" Then
            sql1 &= " and  poNum like '%" & Me.txtPrNO.Text.Trim & "%'"
            'sql1 &= " and CONVERT(varchar(30), poNum) like '%" & Me.txtPrNO.Text.Trim & "%'"
        End If

        If txtRequest.Text.Trim <> "" Then
            sql1 &= " and reqUserName like '%" & Me.txtRequest.Text.Trim & "%'"
        End If

        If txtBuyer.Text.Trim <> "" Then
            sql1 &= " and buyerName like '%" & Me.txtBuyer.Text.Trim & "%'"
        End If




        sql1 &= " order by id desc "
        'sql1 &= " where  TAFWEB..member.Member_user = '" & LCase(txtInt.Text.Trim) & "'"


        dt2.Clear()
        dt2 = dbconn2.GetDataTable(sql1)

        Me.GridView1.DataSource = dt2
        Me.GridView1.DataBind()

    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        'If txtPrNO.Text.Trim = "" And txtRequest.Text.Trim = "" And txtBuyer.Text.Trim = "" Then
        '    dbconn.MessageAlert(Me, "กรุณากรอกข้อมูลค้นหา อย่างน้อย 1 อย่าง !!")

        'Else
        list()
        'End If


    End Sub

  

    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        list()
    End Sub




    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class