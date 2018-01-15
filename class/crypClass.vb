Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class crypClass
    Private enPass As New MemoryStream
    Private dePass As New MemoryStream
    Private rc2 As New RC2CryptoServiceProvider
    Private iv() As Byte = {10, 20, 30, 40, 50, 60, 70, 80}
    Private myEncrypt As ICryptoTransform
    Private myDecrypt As ICryptoTransform
    Private key As String = "abcdefg"
    Public enMessage As String
    Public deMessage As String
    Public encrypted1 As String
    Public encrypted2 As String
    Function enRc2() As String
        rc2.Key = Encoding.ASCII.GetBytes(key)
        rc2.IV = iv
        myEncrypt = rc2.CreateEncryptor()
        Dim pwd() As Byte = Encoding.ASCII.GetBytes(enMessage)
        Dim myCryptostream As New CryptoStream(enPass, myEncrypt, CryptoStreamMode.Write)
        myCryptostream.Write(pwd, 0, pwd.Length)
        myCryptostream.Close()
        encrypted1 = Convert.ToBase64String(enPass.ToArray)
        Return encrypted1
    End Function
    Function deRc2() As String
        rc2.Key = Encoding.ASCII.GetBytes(key)
        rc2.IV = iv
        myDecrypt = rc2.CreateDecryptor()
        Dim enpwd() As Byte = Convert.FromBase64String(encrypted2)
        Dim myCryptostream As New CryptoStream(dePass, myDecrypt, CryptoStreamMode.Write)
        myCryptostream.Write(enpwd, 0, enpwd.Length)
        myCryptostream.Close()
        deMessage = Encoding.ASCII.GetString(dePass.ToArray)
        Return deMessage
    End Function
End Class
