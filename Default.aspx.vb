Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Web.Mail
Imports System.Web.Mail.SmtpMail
Imports System.IO
Imports System.DirectoryServices
Imports System.Web.Security
Imports System.Security.Principal
Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim dbconn As dbaseClass = New dbaseClass
    Dim crypt1 As crypClass = New crypClass
    Dim crypt2 As crypClass = New crypClass
    Dim sql1 As String = ""
    Dim adapter1 As SqlDataAdapter
    Dim dataset1 As New DataSet
    Dim sql2 As String = ""
    Dim adapter2 As SqlDataAdapter
    Dim dataset2 As New DataSet

    Private strCon As String = ConfigurationManager.ConnectionStrings("TAFWEBConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request("action") = "logout" Then

            Session.Remove("Member_seq")
            Session.Remove("admin")
            Session.RemoveAll()
            Session.Clear()
            Session.Abandon()

        End If


        dbconn.SetFocus(Me, txtUser)
        'ckAuthenPass()

    End Sub
    Function ck_config(ByVal seq As String) As Boolean
        'sql1 = "select * from  member   "
        'sql1 &= " where memberuser = '" & seq & "'"
        'sql1 &= " and memEvaYear = " & Now.Year
        'dt1 = dbconn.GetDataTable(sql1)
        'If dt1.Rows.Count < 1 Then
        '    dbconn.MessageAlert(Me, "ท่านไม่มีสิทธิ์ใช้งานในระบบ !!  กรุณาติดต่อ wrw โทร.1256")
        '    Return False
        'End If


        Return True
    End Function
    'Sub ckAuthenPass() 'ถ้าอยู่ใน AD ให้โดดไปเลย
    '    If dbconn.Sql.State.Open Then dbconn.Sql.Close()
    '    dbconn.Sql.Open()

    '    sql1 = "Select * From tafweb..Member "
    '    sql1 &= " Where Member_User='" & Split(Server.HtmlEncode(User.Identity.Name), "\")(1) & "'"
    '    sql1 &= " and Member_flag = 1"

    '    'adapter1 = New SqlDataAdapter(sql1, dbconn.strCon)
    '    adapter1 = New SqlDataAdapter(sql1, strCon) '********* เป็น private strCon
    '    adapter1.Fill(dataset1, "Member")


    '    If dataset1.Tables("Member").Rows.Count <> 0 Then
    '        Session("ID") = Trim(dataset1.Tables("Member").Rows("0").Item("Member_ID"))
    '        Session("Username") = dataset1.Tables("Member").Rows("0").Item("Member_Name") & " " & dataset1.Tables("Member").Rows("0").Item("Member_Sname")
    '        Session("Username1") = dataset1.Tables("Member").Rows("0").Item("Member_Name") & " " & dataset1.Tables("Member").Rows("0").Item("Member_Sname") & " (" & dataset1.Tables("Member").Rows("0").Item("Member_User") & ")" & " , " & dataset1.Tables("Member").Rows("0").Item("Member_PosDesc")
    '        Session("Division_ID") = dataset1.Tables("Member").Rows("0").Item("Division_ID")
    '        Session("department_ID") = dataset1.Tables("Member").Rows("0").Item("department_ID")
    '        Session("Member_User") = dataset1.Tables("Member").Rows("0").Item("Member_User")
    '        'เก็บ log การ login
    '        Dim str_user As String = ""
    '        Dim fileWriter As StreamWriter = File.AppendText(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings("log_path")) & "log.htm")
    '        str_user = "<br><font color = blue>->login: " & Format(Now, "dd/MM/yyyy  h:mm:ss") & " , name: " & Session("Username1") & "</font>"
    '        fileWriter.WriteLine(str_user)
    '        fileWriter.Close()


    '        Dim cookie As New HttpCookie("user_detail")
    '        cookie.Expires = Now.AddMinutes(1)
    '        cookie.Values("id") = Session("id")
    '        cookie.Values("type") = Session("type")
    '        cookie.Values("Username") = Session("Username")
    '        Response.Cookies.Add(cookie)

    '        Response.Redirect("scoreReq.aspx")
    '    End If

    '    dbconn.Sql.Close()
    'End Sub
    Private Sub button_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_Login.Click


        If txtUser.Text = "" Or txtPwd.Text = "" Then
            dbconn.MessageAlert(Me, "กรุณากรอก รหัสผู้ใช้/รหัสผ่าน ให้ครบด้วยครับ!!" & vbCrLf & "หมายเหตุ.. ให้ใช้ User และ Password ที่ท่านใช้ล็อกอินเข้าเครื่องของท่านในทุกๆเช้าครับ!!")
            Exit Sub
        ElseIf txtUser.Text.Trim.Length <> 3 Then
            dbconn.MessageAlert(Me, "รหัสผู้ใช้ คือ Initial ของท่านเองจำนวน 3 ตัวนะครับ!!" & vbCrLf & "เป็น Initial เดียวกันกับที่ท่านใช้ล็อกอินเข้าเครื่องของท่านในทุกๆเช้าครับ!!")
            Exit Sub
        ElseIf txtPwd.Text.Trim.Length < 8 Then
            dbconn.MessageAlert(Me, "รหัสผ่านต้องมี 8 ตัวขึ้นไปนะครับ!!" & vbCrLf & "เป็น Password เดียวกันกับที่ท่านใช้ล็อกอินเข้าเครื่องของท่านในทุกๆเช้าครับ!!")
            Exit Sub
        End If





        If dbconn.Sql.State.Open Then dbconn.Sql.Close()
        dbconn.Sql.Open()
        crypt1.enMessage = txtPwd.Text
        sql1 = "Select * From TLService.dbo.Employees,TLService.dbo.Sections "
        sql1 &= "Where Member_Username ='" & UCase(dbconn.check_text(txtUser.Text)) & "'"
        sql1 &= "And Member_Username in (" & System.Configuration.ConfigurationSettings.AppSettings("user_initial_list") & ")"
        sql1 &= " and Member_Status = 1 and TLService.dbo.Employees.SectionID = TLService.dbo.Sections.Sec_ID"

        'adapter1 = New SqlDataAdapter(sql1, dbconn.strCon)
        adapter1 = New SqlDataAdapter(sql1, strCon) '********* เป็น private strCon

        adapter1.Fill(dataset1, "Employees")

        If dataset1.Tables("Employees").Rows.Count <> 0 Then


            Dim c2008 As New ClassTotal2008
            If c2008.AuthenticateUser("LDAP://thappline.co.th", Me.txtUser.Text.Trim, Me.txtPwd.Text.Trim, Me) Then

                Session("ID") = Trim(dataset1.Tables("Employees").Rows("0").Item("Member_ID"))
                Session("Member_seq") = Trim(dataset1.Tables("Employees").Rows("0").Item("Member_Seq"))
                Session("Username") = dataset1.Tables("Employees").Rows("0").Item("Member_Name") & " " & dataset1.Tables("Employees").Rows("0").Item("Member_Sname")
                Session("Username1") = dataset1.Tables("Employees").Rows("0").Item("Member_Name") & " " & dataset1.Tables("Employees").Rows("0").Item("Member_Sname") & " (" & dataset1.Tables("Employees").Rows("0").Item("Member_Username") & ")" & " , " & dataset1.Tables("Employees").Rows("0").Item("Member_Pos_Desc")
                Session("Division_ID") = dataset1.Tables("Employees").Rows("0").Item("DivisionID")
                Session("department_ID") = dataset1.Tables("Employees").Rows("0").Item("SectionID")
                Session("Member_User") = dataset1.Tables("Employees").Rows("0").Item("Member_Username")

                ''************** check admin ***************
                'sql1 = "Select * From admin "
                'sql1 &= "Where Member_User='" & UCase(dbconn.check_text(txtUser.Text)) & "'"
                'dt1 = dbconn.GetDataTable(sql1)
                'If dt1.Rows.Count > 0 Then
                '    Session("Admin") = dt1.Rows("0").Item("Member_User")
                'End If
                ''*****************************************

                'เก็บ log การ login
                Dim str_user As String = ""
                Dim fileWriter As StreamWriter = File.AppendText(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings("log_path")) & "log.htm")
                str_user = "<br><font color = blue>->login: " & Format(Now, "dd/MM/yyyy  h:mm:ss") & " , name: " & Session("Username1") & "</font>"
                fileWriter.WriteLine(str_user)
                fileWriter.Close()


                Dim cookie As New HttpCookie("user_detail")
                cookie.Expires = Now.AddMinutes(1)
                cookie.Values("id") = Session("id")
                cookie.Values("type") = Session("type")
                cookie.Values("Username") = Session("Username")
                Response.Cookies.Add(cookie)
                ''Response.Redirect("index.aspx?approve=yes")

                If ck_config(Session("Member_User")) Then
                    Response.Redirect("scoreReq.aspx")
                End If

            Else
                'เก็บ log การ login ผิดพลาด
                Dim str_user As String = ""
                Dim fileWriter As StreamWriter = File.AppendText(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings("log_path")) & "log.htm")
                str_user = "<br><font color = red >->login failue(AD): " & Format(Now, "dd/MM/yyyy  h:mm:ss") & ", user: " & Me.txtUser.Text & " , pass: " & Me.txtPwd.Text & "</font>"
                fileWriter.WriteLine(str_user)
                fileWriter.Close()
                Exit Sub
            End If

        ElseIf txtUser.Text = "" Or txtPwd.Text = "" Then
            dbconn.MessageAlert(Me, "กรุณากรอก รหัสผู้ใช้/รหัสผ่าน ให้ครบด้วยครับ!!" & vbCrLf & "หมายเหตุ.. ให้ใช้ User และ Password ที่ท่านใช้ล็อกอินเข้าเครื่องของท่านในทุกๆเช้าครับ!!")
        Else
            dbconn.MessageAlert(Me, "ท่านไม่มีรายชื่อในระบบ  กรุณาติดต่อแผนก IS (wrw โทร. 1256)ครับ!!")

            'เก็บ log การ login ผิดพลาด
            Dim str_user As String = ""
            Dim fileWriter As StreamWriter = File.AppendText(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings("log_path")) & "log.htm")
            str_user = "<br><font color = red >->login failue(ISservice): " & Format(Now, "dd/MM/yyyy  h:mm:ss") & ", user: " & Me.txtUser.Text & " , pass: " & Me.txtPwd.Text & "</font>"
            fileWriter.WriteLine(str_user)
            fileWriter.Close()
        End If
            dbconn.Sql.Close()


    End Sub

    
End Class