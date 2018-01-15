#Region "Import Namespace and Option"
Option Compare Text
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
#End Region

Namespace UtilEncrypt

    Public Class EncryptFuncClass

#Region "Declare Variable"
        'Private Variable
        Private isEncrypted As Boolean
        Private isDecrypted As Boolean
#End Region

#Region "Method and Function"
        Public Function RijndaelEncode(ByVal EncodedString) As String
            Dim result As String
            Dim Key() As Byte = {121, 56, 63, 55, 88, 25, 64, 56, 45, 56, 56, 56, 78, 56, 54, 123}
            Dim IV() As Byte = {45, 89, 89, 68, 56, 65, 85, 56, 56, 23, 11, 12, 13, 14, 15, 16}
            Try
                Dim EncodedStringasByte() As Byte = ASCIIEncoding.ASCII.GetBytes(EncodedString)
                Dim TargetStream As New MemoryStream
                Dim RMEncryptor As New RijndaelManaged
                Dim CryptStream As New CryptoStream(TargetStream, RMEncryptor.CreateEncryptor(Key, IV), CryptoStreamMode.Write)
                CryptStream.Write(EncodedStringasByte, 0, EncodedStringasByte.Length)
                CryptStream.FlushFinalBlock()
                Dim EncrytedDataAsByte() As Byte = TargetStream.GetBuffer()
                isEncrypted = True
                result = Convert.ToBase64String(EncrytedDataAsByte, 0, TargetStream.Length)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Function RijndaelDecode(ByVal decodedString) As String
            Dim result As String
            Dim Key() As Byte = {121, 56, 63, 55, 88, 25, 64, 56, 45, 56, 56, 56, 78, 56, 54, 123}
            Dim IV() As Byte = {45, 89, 89, 68, 56, 65, 85, 56, 56, 23, 11, 12, 13, 14, 15, 16}
            Try
                Dim DecodedStringAsByte() As Byte = Convert.FromBase64String(decodedString)
                Dim SourceStream As New MemoryStream(DecodedStringAsByte, 0, DecodedStringAsByte.Length)
                Dim RMDeCryptor As New RijndaelManaged
                Dim DecryptStream As New CryptoStream(SourceStream, RMDeCryptor.CreateDecryptor(Key, IV), CryptoStreamMode.Read)
                Dim SReader As New StreamReader(DecryptStream)
                isDecrypted = True
                result = SReader.ReadToEnd
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Public Function Rc2Encode(ByVal EncodedString) As String
            Dim result As String
            Dim Key As String = "AXSOFTC"
            Dim IV() As Byte = {11, 12, 33, 50, 78, 25, 72, 84}
            Try
                Dim rc2 As New RC2CryptoServiceProvider
                rc2.Key = Encoding.ASCII.GetBytes(Key)
                rc2.IV = IV
                Dim myEncrypt As ICryptoTransform = rc2.CreateEncryptor()
                Dim pwd() As Byte = Encoding.ASCII.GetBytes(EncodedString)
                Dim TargetStream As New MemoryStream
                Dim myCryptostream As New CryptoStream(TargetStream, myEncrypt, CryptoStreamMode.Write)
                myCryptostream.Write(pwd, 0, pwd.Length)
                myCryptostream.Close()
                Return Convert.ToBase64String(TargetStream.ToArray)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function

        Function Rc2Decode(ByVal decodedString) As String
            Dim result As String
            Dim Key As String = "AXSOFTC"
            Dim IV() As Byte = {11, 12, 33, 50, 78, 25, 72, 84}
            Try
                Dim rc2 As New RC2CryptoServiceProvider
                rc2.Key = Encoding.ASCII.GetBytes(Key)
                rc2.IV = IV
                Dim myDecrypt As ICryptoTransform = rc2.CreateDecryptor()
                Dim pwd() As Byte = Convert.FromBase64String(decodedString)
                Dim SourceStream As New MemoryStream
                Dim myCryptostream As New CryptoStream(SourceStream, myDecrypt, CryptoStreamMode.Write)
                myCryptostream.Write(pwd, 0, pwd.Length)
                myCryptostream.Close()
                Return Encoding.ASCII.GetString(SourceStream.ToArray)
            Catch ex As Exception
                Throw ex
            End Try
            Return result
        End Function
#End Region

    End Class

End Namespace


