Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Configuration

Imports System.Web.Mail
Imports System.Web.Mail.SmtpMail

Imports System.Security.Principal

Partial Public Class score
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

    Public linkMail As String = ""

    Private strCon As String = ConfigurationManager.ConnectionStrings("TAFWEBConnectionString").ConnectionString





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dbconn.ConfirmBox(Me.btnResend, "ยืนยันการส่งแบบสอบถาม อีกครั้ง!! ")

        dbconn.ConfirmBox(Me.btnSave, "ยืนยันการบันทึกแบบสอบถาม!! ")

        If Not Page.IsPostBack Then

            'setSelect()

            list()
            listDetail()
            If Request("v") = "t" Then '********** buyer เรียกดูอย่างเดียว *********
                Panel1.Enabled = False
            End If

            'ckAuthenPass()

            'Response.Write(Server.HtmlEncode(User.Identity.Name))
            'Response.Write("<br/>")
            'Response.Write(Request.ServerVariables("AUTH_USER"))
            'Response.Write("<br/>")
            'Response.Write(HttpContext.Current.Request.LogonUserIdentity.Name) 'THAPP\Administrator
            'Response.Write("<br/>")
            'Response.Write(Environment.UserName) 'NETWORK SERVICE
            'Response.Write("<br/>")
            'Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name) 'NT AUTHORITY\NETWORK SERVICE 
            'Response.Write("<br/>")
            'Response.Write(System.Web.HttpContext.Current.User.Identity.Name)
            'Response.Write("<br/>")
            'Response.Write(User.Identity.Name)

            'Response.Write(Request.ServerVariables("LOGON_USER"))
            'Response.Write("<br/>")
            'Response.Write(Request.ServerVariables("REMOTE_USER"))



        End If

    End Sub


    Sub list()




      

        sql1 = "select * , 'score.aspx?p=' + CAST(ID AS VARCHAR) as link1 from score_head, status1"
        sql1 &= " where score_head.statusId = status1.statusId "
        sql1 &= " and id = " & Request("id")
        dt2.Clear()
        dt2 = dbconn2.GetDataTable(sql1)
        If dt2.Rows.Count > 0 Then

            txtUserReq.Text = IIf(IsDBNull(dt2.Rows(0).Item("reqUserName")), "-", dt2.Rows(0).Item("reqUserName"))
            Me.txtInt.Text = txtUserReq.Text.Trim
            'txtUserLogin.Text = IIf(IsDBNull(dt2.Rows(0).Item("reqUserNameLogin")), "-", dt2.Rows(0).Item("reqUserNameLogin"))
            txtBuyer.Text = IIf(IsDBNull(dt2.Rows(0).Item("buyerName")), "-", dt2.Rows(0).Item("buyerName"))

            lblPoNum.Text = dt2.Rows(0).Item("ponum")
            lblVender.Text = dt2.Rows(0).Item("VenderName")
            lblShotText.Text = dt2.Rows(0).Item("ShortText")
            lblDateSend.Text = IIf(IsDBNull(dt2.Rows(0).Item("dateSent")), "-", dt2.Rows(0).Item("dateSent"))
            lblDateAns.Text = IIf(IsDBNull(dt2.Rows(0).Item("dateModify")), "-", dt2.Rows(0).Item("dateModify"))

            lblTotal.Text = Format(dt2.Rows(0).Item("total") * 100 / 5, "###.##") & "%" ' แปลเป็น % เต็ม 5

            'lblCopyLink.Text = dt2.Rows(0).Item("link1")

            If Session("Member_User") <> Nothing Then

                'lblLink.Text = "http://thapp/score/score.aspx?id=" & Request("id")

                'linkMail = "ขอความกรุณาตอบแบบสอบถามความพึงพอใจ"
                'linkMail &= "http://thapp/score/score.aspx?id=" & Request("id")

                'Dim str As String = "<font size = 14 color = blue>ขอความกรุณาตอบแบบสอบถามความพึงพอใจ</font><br>" _
                '& "<font size = 10> PO เลขที่ : </font><font color=Magenta size=10>" & lblPoNum.Text.Trim & "</font><br>" _
                '& "<br><br><font size=10 color=red>ตอบแบบสอบถาม</font> <font size=10 color=blue><a href='http://thapp/score/score.aspx?id=" & Request("id") & "'>คลิกที่นี่</a></font>"
                'linkMail = str
                ''& "<font size = 10> Buyer:</font><font color=Magenta size=10> " & Session("Member_User") & " </font>" _


                'Dim str As String = "ขอความกรุณาตอบแบบสอบถามความพึงพอใจ " _
                '& " PO เลขที่ : " & lblPoNum.Text.Trim & "" _
                '& "   คลิกที่นี่  http://thapp/score/score.aspx?id=" & Request("id") & ""
                'linkMail = str

                PanelAdmin.Visible = True
                PanelAdmin.Enabled = True
                PanelBack.Visible = True


            Else
                PanelAdmin.Visible = False
                PanelBack.Visible = False
            End If

            '*********** Check Status ไม่ให้ save ซ้ำ *********************
            lblStatus.Text = dt2.Rows(0).Item("statusName")
            If dt2.Rows(0).Item("statusId") = 1 Then
                lblStatus.ForeColor = Color.Blue
                'If Request("v") = "t" Then '********** buyer เรียกดูอย่างเดียว *********
                '    Panel1.Enabled = False
                'Else
                Panel1.Enabled = True
                'End If

            Else
                lblStatus.ForeColor = Color.Black
                Panel1.Enabled = False

            End If
        End If

        'Me.GridView1.DataSource = dt2
        'Me.GridView1.DataBind()

    End Sub

    Sub listDetail()

        sql1 = "select *  from score_detail"
        sql1 &= " where idHead = " & Request("id")
        dt2.Clear()
        dt2 = dbconn2.GetDataTable(sql1)
        If dt2.Rows.Count > 0 Then
            For i As Integer = 0 To dt2.Rows.Count - 1

                Select Case dt2.Rows(i).Item("scoreIssue") '*** หัวข้อ
                    Case 1
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo1_5.Checked = True
                            Case 4
                                rdo1_4.Checked = True
                            Case 3
                                rdo1_3.Checked = True
                            Case 2
                                rdo1_2.Checked = True
                            Case 5
                                rdo1_5.Checked = True
                            Case 1
                                rdo1_1.Checked = True
                        End Select
                        txtComment1.Text = dt2.Rows(i).Item("comment")
                    Case 2
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo2_5.Checked = True
                            Case 4
                                rdo2_4.Checked = True
                            Case 3
                                rdo2_3.Checked = True
                            Case 2
                                rdo2_2.Checked = True
                            Case 5
                                rdo2_5.Checked = True
                            Case 1
                                rdo2_1.Checked = True
                        End Select
                        txtComment2.Text = dt2.Rows(i).Item("comment")
                    Case 3
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo3_5.Checked = True
                            Case 4
                                rdo3_4.Checked = True
                            Case 3
                                rdo3_3.Checked = True
                            Case 2
                                rdo3_2.Checked = True
                            Case 5
                                rdo3_5.Checked = True
                            Case 1
                                rdo3_1.Checked = True
                        End Select
                        txtComment3.Text = dt2.Rows(i).Item("comment")

                    Case 4
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo4_5.Checked = True
                            Case 4
                                rdo4_4.Checked = True
                            Case 3
                                rdo4_3.Checked = True
                            Case 2
                                rdo4_2.Checked = True
                            Case 5
                                rdo4_5.Checked = True
                            Case 1
                                rdo4_1.Checked = True
                        End Select
                        txtComment4.Text = dt2.Rows(i).Item("comment")
                    Case 5
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo5_5.Checked = True
                            Case 4
                                rdo5_4.Checked = True
                            Case 3
                                rdo5_3.Checked = True
                            Case 2
                                rdo5_2.Checked = True
                            Case 5
                                rdo5_5.Checked = True
                            Case 1
                                rdo5_1.Checked = True
                        End Select
                        txtComment5.Text = dt2.Rows(i).Item("comment")
                    Case 6
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo6_5.Checked = True
                            Case 4
                                rdo6_4.Checked = True
                            Case 3
                                rdo6_3.Checked = True
                            Case 2
                                rdo6_2.Checked = True
                            Case 5
                                rdo6_5.Checked = True
                            Case 1
                                rdo6_1.Checked = True
                        End Select
                        txtComment6.Text = dt2.Rows(i).Item("comment")
                    Case 7
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo7_5.Checked = True
                            Case 4
                                rdo7_4.Checked = True
                            Case 3
                                rdo7_3.Checked = True
                            Case 2
                                rdo7_2.Checked = True
                            Case 5
                                rdo7_5.Checked = True
                            Case 1
                                rdo7_1.Checked = True
                        End Select
                        txtComment7.Text = dt2.Rows(i).Item("comment")
                    Case 8
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo8_5.Checked = True
                            Case 4
                                rdo8_4.Checked = True
                            Case 3
                                rdo8_3.Checked = True
                            Case 2
                                rdo8_2.Checked = True
                            Case 5
                                rdo8_5.Checked = True
                            Case 1
                                rdo8_1.Checked = True
                        End Select
                        txtComment8.Text = dt2.Rows(i).Item("comment")
                    Case 9
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo9_5.Checked = True
                            Case 4
                                rdo9_4.Checked = True
                            Case 3
                                rdo9_3.Checked = True
                            Case 2
                                rdo9_2.Checked = True
                            Case 5
                                rdo9_5.Checked = True
                            Case 1
                                rdo9_1.Checked = True
                        End Select
                        txtComment9.Text = dt2.Rows(i).Item("comment")
                    Case 10
                        Select Case dt2.Rows(i).Item("result")
                            Case 5
                                rdo10_5.Checked = True
                            Case 4
                                rdo10_4.Checked = True
                            Case 3
                                rdo10_3.Checked = True
                            Case 2
                                rdo10_2.Checked = True
                            Case 5
                                rdo10_5.Checked = True
                            Case 1
                                rdo10_1.Checked = True
                        End Select
                        txtComment10.Text = dt2.Rows(i).Item("comment")
                End Select

            Next

            'If rdo4_1.Checked = True Then
            '    result4 = 1
            'ElseIf rdo4_2.Checked = True Then
            '    result4 = 2
            'ElseIf rdo4_3.Checked = True Then
            '    result4 = 3
            'ElseIf rdo4_4.Checked = True Then
            '    result4 = 4
            'ElseIf rdo4_5.Checked = True Then
            '    result4 = 5
            'Else
            '    dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
            '    Exit Sub
            'End If

        End If
    End Sub



    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        saveScore()
    End Sub

    Sub saveScore()

        'Dim ID As String
        'ID = dbconn2.GetID("score_detail", "id")

        Dim result1 As Integer = 0
        Dim result2 As Integer = 0
        Dim result3 As Integer = 0
        Dim result4 As Integer = 0
        Dim result5 As Integer = 0
        Dim result6 As Integer = 0
        Dim result7 As Integer = 0
        Dim result8 As Integer = 0
        Dim result9 As Integer = 0
        Dim result10 As Integer = 0
        '*****************************************


        Dim cnAdmin = New System.Data.SqlClient.SqlConnection
        cnAdmin.ConnectionString = ConfigurationManager.ConnectionStrings("TAFWEBConnectionString").ConnectionString
        cnAdmin.Open()



        Dim cmd = New SqlCommand(sql1, cnAdmin)
        cmd.Transaction = cnAdmin.BeginTransaction '##
        Try
            '***************  1 *************

            If rdo1_1.Checked = True Then
                result1 = 1
            ElseIf rdo1_2.Checked = True Then
                result1 = 2
            ElseIf rdo1_3.Checked = True Then
                result1 = 3
            ElseIf rdo1_4.Checked = True Then
                result1 = 4
            ElseIf rdo1_5.Checked = True Then
                result1 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 1 & ""  '**** หัวข้อที่
            sql1 &= "," & result1 & ""
            sql1 &= ",'" & txtComment1.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()

            '*********************************


            '*************** 2 ***************
            If rdo2_1.Checked = True Then
                result2 = 1
            ElseIf rdo2_2.Checked = True Then
                result2 = 2
            ElseIf rdo2_3.Checked = True Then
                result2 = 3
            ElseIf rdo2_4.Checked = True Then
                result2 = 4
            ElseIf rdo2_5.Checked = True Then
                result2 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 2 & ""  '**** หัวข้อที่
            sql1 &= "," & result2 & ""
            sql1 &= ",'" & txtComment2.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 3 ***************
            If rdo3_1.Checked = True Then
                result3 = 1
            ElseIf rdo3_2.Checked = True Then
                result3 = 2
            ElseIf rdo3_3.Checked = True Then
                result3 = 3
            ElseIf rdo3_4.Checked = True Then
                result3 = 4
            ElseIf rdo3_5.Checked = True Then
                result3 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 3 & ""  '**** หัวข้อที่
            sql1 &= "," & result3 & ""
            sql1 &= ",'" & txtComment3.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 4 ***************
            If rdo4_1.Checked = True Then
                result4 = 1
            ElseIf rdo4_2.Checked = True Then
                result4 = 2
            ElseIf rdo4_3.Checked = True Then
                result4 = 3
            ElseIf rdo4_4.Checked = True Then
                result4 = 4
            ElseIf rdo4_5.Checked = True Then
                result4 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 4 & ""  '**** หัวข้อที่
            sql1 &= "," & result4 & ""
            sql1 &= ",'" & txtComment4.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 5 ***************
            If rdo5_1.Checked = True Then
                result5 = 1
            ElseIf rdo5_2.Checked = True Then
                result5 = 2
            ElseIf rdo5_3.Checked = True Then
                result5 = 3
            ElseIf rdo5_4.Checked = True Then
                result5 = 4
            ElseIf rdo5_5.Checked = True Then
                result5 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 5 & ""  '**** หัวข้อที่
            sql1 &= "," & result5 & ""
            sql1 &= ",'" & txtComment5.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 6 ***************
            If rdo6_1.Checked = True Then
                result6 = 1
            ElseIf rdo6_2.Checked = True Then
                result6 = 2
            ElseIf rdo6_3.Checked = True Then
                result6 = 3
            ElseIf rdo6_4.Checked = True Then
                result6 = 4
            ElseIf rdo6_5.Checked = True Then
                result6 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 6 & ""  '**** หัวข้อที่
            sql1 &= "," & result6 & ""
            sql1 &= ",'" & txtComment6.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 7 ***************
            If rdo7_1.Checked = True Then
                result7 = 1
            ElseIf rdo7_2.Checked = True Then
                result7 = 2
            ElseIf rdo7_3.Checked = True Then
                result7 = 3
            ElseIf rdo7_4.Checked = True Then
                result7 = 4
            ElseIf rdo7_5.Checked = True Then
                result7 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 7 & ""  '**** หัวข้อที่
            sql1 &= "," & result7 & ""
            sql1 &= ",'" & txtComment7.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 8 ***************
            If rdo8_1.Checked = True Then
                result8 = 1
            ElseIf rdo8_2.Checked = True Then
                result8 = 2
            ElseIf rdo8_3.Checked = True Then
                result8 = 3
            ElseIf rdo8_4.Checked = True Then
                result8 = 4
            ElseIf rdo8_5.Checked = True Then
                result8 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 8 & ""  '**** หัวข้อที่
            sql1 &= "," & result8 & ""
            sql1 &= ",'" & txtComment8.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 9 ***************
            If rdo9_1.Checked = True Then
                result9 = 1
            ElseIf rdo9_2.Checked = True Then
                result9 = 2
            ElseIf rdo9_3.Checked = True Then
                result9 = 3
            ElseIf rdo9_4.Checked = True Then
                result9 = 4
            ElseIf rdo9_5.Checked = True Then
                result9 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 9 & ""  '**** หัวข้อที่
            sql1 &= "," & result9 & ""
            sql1 &= ",'" & txtComment9.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************
            '*************** 10 ***************
            If rdo10_1.Checked = True Then
                result10 = 1
            ElseIf rdo10_2.Checked = True Then
                result10 = 2
            ElseIf rdo10_3.Checked = True Then
                result10 = 3
            ElseIf rdo10_4.Checked = True Then
                result10 = 4
            ElseIf rdo10_5.Checked = True Then
                result10 = 5
            Else
                dbconn.MessageAlert(Me, "กรุณากรอกคะแนนให้ครบทุกช่อง!!")
                Exit Sub
            End If
            sql1 = "insert into score_detail(idHead,poNum,scoreIssue,result,comment) "
            sql1 &= " Values(" & Request("id").Trim
            sql1 &= "," & lblPoNum.Text.Trim & ""
            sql1 &= "," & 10 & ""  '**** หัวข้อที่
            sql1 &= "," & result10 & ""
            sql1 &= ",'" & txtComment10.Text.Trim & "'"
            sql1 &= " )"


            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************


            '----head  ***************
          
            sql1 = "update score_head set total = " & (result1 + result2 + result3 + result4 + result5 + result6 + result7 + result8 + result9 + result10) / 10
            'sql1 &= " , reqUserNameLogin = '" & Split(Server.HtmlEncode(User.Identity.Name), "\")(1) & "'"
            sql1 &= " , reqUserNameLogin = ''"
            sql1 &= " , dateModify = '" & Format(Now, "MM/dd/yyyy H:mm:ss") & "'"
            sql1 &= " , statusId = 2"
            sql1 &= " where id = " & Request("id").Trim

            cmd.CommandText = sql1
            cmd.ExecuteNonQuery()
            '*********************************



            cmd.Transaction.Commit()
            'dbconn.MessageAlert(Me, "บันทึก สำเร็จ !!")
            Me.Panel1.Visible = False
            Me.Panel2.Visible = True

        Catch ex As Exception
            cmd.Transaction.Rollback() '##
            dbconn.MessageAlert(Me, "เกิดข้อผิดพลาด  อาจมีการบันทึกซ้ำ !! " & vbCrLf & ex.Message & vbCrLf & Split(Server.HtmlEncode(User.Identity.Name), "\")(1))
            Exit Sub
        End Try

    End Sub




    Sub sendEmail(ByVal ID As String)

        '"<font color = red>แบบสอบถามความพึงพอใจ  จากระบบ Purchase Score!!</font><br>" _
        '   & "
        'System.Configuration.ConfigurationSettings.AppSettings("user_recive_mail")
        Try

            Dim str As String = "<font size = 14 color = blue>ขอความกรุณาตอบแบบสอบถามความพึงพอใจ</font><br>" _
            & "<font size = 10> PO เลขที่ : </font><font color=Magenta size=10>" & lblPoNum.Text.Trim & "</font><br>" _
            & "<font size = 10> ผู้ส่ง:</font><font color=Magenta size=10> " & Session("Member_User") & " </font>" _
            & "<br><br><font size=10 color=red>ตอบแบบสอบถาม</font> <font size=10 color=blue><a href='http://thapp/score/score.aspx?id=" & ID & "'>คลิกที่นี่</a></font>"
            sendmail("Purchase@thappline.co.th", lblEmail.Text.Trim & "@thappline.co.th", "แบบสอบถามความพึงพอใจ  จากระบบ Purchase Score!!", str)



            'dbconn.MessageAlert(Me, "ส่ง Email สำเร็จ!!")



        Catch ex As Exception
            'cmd.Transaction.Rollback()
            dbconn.MessageAlert(Me, "เกิดข้อผิดพลาด ระบบไม่สามารถส่ง E-mailได้ กรุณาโทรติดต่อผู้รับแจ้งโดยตรง!!" & vbCrLf & ex.Message)
            Exit Sub
        End Try


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
    '        ''เก็บ log การ login
    '        'Dim str_user As String = ""
    '        'Dim fileWriter As StreamWriter = File.AppendText(Server.MapPath(System.Configuration.ConfigurationSettings.AppSettings("log_path")) & "log.htm")
    '        'str_user = "<br><font color = blue>->login: " & Format(Now, "dd/MM/yyyy  h:mm:ss") & " , name: " & Session("Username1") & "</font>"
    '        'fileWriter.WriteLine(str_user)
    '        'fileWriter.Close()


    '        Dim cookie As New HttpCookie("user_detail")
    '        cookie.Expires = Now.AddMinutes(1)
    '        cookie.Values("id") = Session("id")
    '        cookie.Values("type") = Session("type")
    '        cookie.Values("Username") = Session("Username")
    '        Response.Cookies.Add(cookie)

    '        'Response.Redirect("score.aspx")
    '    End If

    '    dbconn.Sql.Close()
    'End Sub

   

    Protected Sub btnResend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnResend.Click
        sql1 = "select * from TLService.dbo.Employees"
        sql1 &= " where  TLService.dbo.Employees.Member_username = '" & LCase(txtInt.Text.Trim) & "'"


        dt2.Clear()
        dt2 = dbconn2.GetDataTable(sql1)
        If dt2.Rows.Count > 0 Then
            Me.lblEmail.Text = dt2.Rows(0).Item("Member_email")

            sendEmail(Request("id")) '**********

        Else
            'lblEmail.Text = "** ไม่พบ Email ของ User นี้ **"
            lblEmail.Text = ""

            dbconn.MessageAlert(Me, "ไม่พบ Email ของ " & txtInt.Text.Trim & " กรุณตรวจสอบ !!")

            Exit Sub
        End If







    End Sub
End Class