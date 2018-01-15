Imports System.DirectoryServices
Public Class ClassTotal2008


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
