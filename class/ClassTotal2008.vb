Imports System.DirectoryServices
Public Class ClassTotal2008

    Sub gridCreated_OverColor_Request(ByRef e As System.Web.UI.WebControls.GridViewRowEventArgs) 'Grid_RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then

            'LinkButton l1 = (LinkButton)e.Row.FindControl("LinkButton1");  ' หา LinkButton ที่อยู่ใน Itemtemplate         
            'l1.Attributes.Add("onmouseover", "window.status='';this.style.color='OrangeRed'; return true") 'mouse view ๆ
            'l1.Attributes.Add("onmouseout", "window.status='';this.style.color='Gray'; return true") 'mouse out

            e.Row.Attributes.Add("onmouseover", "style.backgroundColor='#FFCCFF'")  'mouse view ๆ

            If (e.Row.RowIndex Mod 2 <> 0) Then

                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#FFFFFF'")  ' หาสีที่ใกล้เ
            Else

                e.Row.Attributes.Add("onmouseout", "style.backgroundColor='#EFF3FB'")  ' 

            End If

        End If
    End Sub
    Sub gridFillColor_Request(ByRef e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim txtUnit As TextBox = CType(e.Row.FindControl("txtGrdUnit"), TextBox)
            txtUnit.Text = e.Row.Cells(3).Text


            e.Row.Cells(4).ToolTip = "กรุณา กรอกจำนวณที่ต้องการเบิก (เบิกได้ไม่เกินจำนวณคงเหลือ )!!"
            e.Row.Cells(6).ToolTip = "หากมีรายละเอียดเพิ่มเติมเกี่ยวกับรายการนี้  สามารถกรอกข้อความสั้นๆได้ไม่เกิน 100 ตัวอักษร !!"
        End If
    End Sub
    Sub gridFillColor_List(ByRef e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then   '***** ใส่เพื่อแก้ runtime error //// และเรียกใช้ตอน grid_RowDataBound ได้ตอน
            If e.Row.Cells(4).Text.Trim = "รออนุมัติ" Then '**รออนุมัติ
                e.Row.Cells(4).ForeColor = Drawing.Color.Blue
            ElseIf e.Row.Cells(4).Text.Trim = "อนุมัติ" Then '**อนุมัติ
                e.Row.Cells(4).ForeColor = Drawing.Color.Green
            ElseIf e.Row.Cells(4).Text.Trim = "ปิดงาน" Then '**ปิดงาน
                e.Row.Cells(4).ForeColor = Drawing.Color.Black
            ElseIf e.Row.Cells(4).Text.Trim = "ไม่อนุมัติ" Then '**ไม่อนุมัติ
                e.Row.Cells(4).ForeColor = Drawing.Color.Red
            ElseIf e.Row.Cells(4).Text.Trim = "Adminไม่อนุมัติ" Then '**Adminไม่อนุมัติ
                e.Row.Cells(4).ForeColor = Drawing.Color.Red
            Else
                e.Row.Cells(4).ForeColor = Drawing.Color.Black
            End If

            '*new 
            Try
                If DateDiff(DateInterval.Day, CDate(Replace(Replace(e.Row.Cells(1).Text.Trim, "[", ""), "]", "")).Date, Now.Date) = 0 Then
                    e.Row.Cells(3).Text &= "<img alt='รายการใหม่วันนี้'  src='images/new.gif'>"
                End If
            Catch ex As Exception

            End Try

        End If




    End Sub
    'Sub gridFillColor(ByRef grid As GridView)
    '    For i As Integer = 0 To grid.Rows.Count - 1
    '        Try
    '            If grid.Rows(i).Cells(7).Text = "รอความเห็นจากผู้บังคับบัญชา" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Blue
    '            ElseIf grid.Rows(i).Cells(7).Text = "รออนุมัติจาก DEPT./SECT. HEAD" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Orange
    '            ElseIf grid.Rows(i).Cells(7).Text = "อนุมัติแล้ว" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Green
    '            ElseIf grid.Rows(i).Cells(7).Text = "HRตรวจสอบแล้ว" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Black
    '            ElseIf grid.Rows(i).Cells(7).Text = "ไม่อนุมัติ" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(7).Text = "ยกเลิกโดยผู้ขอ" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(7).Text = "ยกเลิกโดย HR" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(7).Text = "รอความเห็นจากผู้บังคับบัญชาลำดับที่2" Then
    '                grid.Rows(i).Cells(7).ForeColor = Drawing.Color.Blue
    '            End If
    '        Catch ex As Exception

    '        End Try



    '        Try
    '            *****5****** ของ gridSaveTime
    '            If grid.Rows(i).Cells(4).Text = "รอความเห็นจากผู้บังคับบัญชา" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Blue
    '            ElseIf grid.Rows(i).Cells(4).Text = "รออนุมัติจาก DEPT./SECT. HEAD" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Orange
    '            ElseIf grid.Rows(i).Cells(4).Text = "อนุมัติแล้ว" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Green
    '            ElseIf grid.Rows(i).Cells(4).Text = "HRตรวจสอบแล้ว" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Black
    '            ElseIf grid.Rows(i).Cells(4).Text = "ไม่อนุมัติ" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(4).Text = "ยกเลิกโดยผู้ขอ" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(4).Text = "ยกเลิกโดย HR" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Red
    '            ElseIf grid.Rows(i).Cells(4).Text = "รอความเห็นจากผู้บังคับบัญชาลำดับที่2" Then
    '                grid.Rows(i).Cells(4).ForeColor = Drawing.Color.Blue
    '            End If
    '        Catch ex As Exception

    '        End Try

    '    Next


    'End Sub

    Function AuthenticateUser(ByVal path As String, ByVal user As String, ByVal pass As String, ByRef obj As Object) As Boolean
        Dim dirEntry As New DirectoryEntry(path, user, pass)
        Try
            Dim nat As Object
            'if the NativeObject can be created using those credentials
            'then they are valid.
            nat = dirEntry.NativeObject

            Return True
        Catch ex As Exception
            Dim dbconn As New dbaseClass
            'dbconn.MessageAlert(obj, ex.Message.ToString)
            dbconn.MessageAlert(obj, ex.Message.ToString & vbCrLf & "รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้องครับ!! กรุณาตรวจสอบ Keyboard ภาษาไทย/อังกฤษ หรือ Caps Lock ค้างอยู่หรือไม่ด้วยครับ" & vbCrLf & "หมายเหตุ.. ให้ใช้ User และ Password ที่ท่านใช้ล็อกอินเข้าเครื่องของท่านในทุกๆเช้าครับ!!(หากท่านเข้าผิดเกิน 3 ครั้ง User ของท่านจะถูกล็อกเช่นเดียวกัน)")
            Return False
        End Try
    End Function
End Class
