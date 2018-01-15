Option Compare Text
Imports System.Data.SqlClient

Public Class dbaseClass
    Public Sql = New System.Data.SqlClient.SqlConnection
    'Public strCon As String = "workstation id=(local);packet size=4096;user id=sa;data source=(local);persist security info=False;initial catalog=TAFWEB"
    'Public strCon As String = System.Configuration.ConfigurationSettings.AppSettings("webconfig_conn")
    Public strCon As String = ConfigurationManager.ConnectionStrings("webconfig_conn").ConnectionString
    Public Sub New()
        Sql.ConnectionString = strCon
    End Sub
    Public Function GetDataset(ByVal sql1 As String, Optional ByVal DatasetName As String = "Dataset1", Optional ByVal TableName As String = "Table") As DataSet
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql1, strCon)
        Dim dataset As New DataSet(DatasetName)
        Try
            adapter.Fill(dataset, TableName)
        Catch

        End Try
        Return dataset
    End Function

    Public Function GetDataTable(ByVal sql1 As String, Optional ByVal TableName As String = "Table") As DataTable
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql1, strCon)
        Dim datatable As New DataTable(TableName)
        Try
            adapter.Fill(datatable)
        Catch

        End Try
        Return datatable
    End Function

    Function GetID(ByVal TableName As String, ByVal Col_ID As String) As String
        'Open database 
        If Sql.State.Open Then Sql.Close()
        Sql.Open()
        Dim sql1 As String = ""
        sql1 = "Select Max(" & Col_ID & ") as MaxID From " & TableName & ""
        Dim adapter1 As New SqlDataAdapter(sql1, strCon)
        Dim dataset1 As New DataSet
        adapter1.Fill(dataset1, "GetID")
        adapter1.Dispose()
        Sql.Close()
        If IsDBNull(dataset1.Tables("GetID").Rows(0)("MaxID")) Then
            Return 1
        Else
            Return CInt(dataset1.Tables("GetID").Rows(0)("MaxID")) + 1
        End If
    End Function

    Public Sub ConfirmBox(ByRef BtnName As Object, ByVal StrMessage As String)
        BtnName.Attributes.Add("onclick", "return confirm('" & StrMessage & " ');")
    End Sub

    Public Sub MessageAlert(ByRef aspxPage As System.Web.UI.Page, ByVal strMessage As String)
        If strMessage = "" Then
            Exit Sub
        Else
            strMessage = strMessage.Replace("\", "\\")
            strMessage = strMessage.Replace("'", "\'")
            strMessage = strMessage.Replace("<br>", "\n")
            strMessage = strMessage.Replace(Convert.ToChar(10), "\n")
            strMessage = strMessage.Replace(Convert.ToChar(13), "")
            Dim strScript As String = "<script language=JavaScript>alert('" & strMessage & "')</script>"
            If (Not aspxPage.IsStartupScriptRegistered("strKey1")) Then
                aspxPage.RegisterStartupScript("strKey1", strScript)
            End If
        End If

    End Sub
    Public Sub SetFocus(ByRef aspxPage As System.Web.UI.Page, ByVal FocusControl As Control)
        Dim Script As New System.Text.StringBuilder
        Dim ClientID As String = FocusControl.ClientID

        With Script
            .Append("<script language='javascript'>")
            .Append("document.getElementById('")
            .Append(ClientID)
            .Append("').focus();")
            .Append("</script>")
        End With
        aspxPage.RegisterStartupScript("setFocus", Script.ToString())
    End Sub
    Public Function ShowAllData(ByVal Table As String) As DataSet
        'Open database
        If Sql.State.Open Then Sql.Close()
        Sql.Open()
        'ddlQuestion Query
        Dim sql1 As String = ""
        sql1 = "Select * From " & Table
        'Add dataset
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql1, strCon)
        Dim dataset As New DataSet
        adapter.Fill(dataset, Table)

        'Close database
        Sql.Close()
        Return dataset
    End Function
    Public Function ShowAllData(ByVal Table As String, ByVal by As String, ByVal sort As String) As DataSet
        'Open database
        If Sql.State.Open Then Sql.Close()
        Sql.Open()
        'ddlQuestion Query
        Dim sql1 As String = ""
        sql1 = "Select * From " & Table
        sql1 &= " order by " & by & " " & sort

        'Add dataset
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql1, strCon)
        Dim dataset As New DataSet
        adapter.Fill(dataset, Table)

        'Close database
        Sql.Close()
        Return dataset
    End Function

    Public Function ExecuteNonQuery(ByVal sql1 As String) As SqlCommand
        Dim cmd As New SqlCommand(sql1, Sql)
        cmd.ExecuteNonQuery()
        Return cmd
    End Function
    Function WordWrap(ByVal strTextToBeWrapped As String, ByVal intMaxLineLength As Integer) As String
        Dim strWrappedText As String            ' Result storage

        Dim intLengthOfInput As Integer         ' Length of original

        Dim intCurrentPosition As Integer       ' Where we're at now
        Dim intCurrentLineStart As Integer      ' Where the current line starts
        Dim intPositionOfLastSpace As Integer   ' Last space we saw


        intLengthOfInput = Len(strTextToBeWrapped)


        intCurrentPosition = 1
        intCurrentLineStart = 1

        Do While intCurrentPosition < intLengthOfInput

            If Mid(strTextToBeWrapped, intCurrentPosition, 1) = " " Then
                intPositionOfLastSpace = intCurrentPosition
            End If


            If intCurrentPosition = intCurrentLineStart + intMaxLineLength Then

                strWrappedText = strWrappedText _
                     & Trim(Mid(strTextToBeWrapped, intCurrentLineStart, _
                     intPositionOfLastSpace - intCurrentLineStart + 1)) _
                     & vbCrLf


                intCurrentLineStart = intPositionOfLastSpace + 1

                Do While Mid(strTextToBeWrapped, intCurrentLineStart, 1) = " "
                    intCurrentLineStart = intCurrentLineStart + 1
                Loop
            End If

            intCurrentPosition = intCurrentPosition + 1
        Loop


        strWrappedText = strWrappedText & Trim(Mid(strTextToBeWrapped, _
             intCurrentLineStart)) & vbCrLf


        WordWrap = strWrappedText
    End Function
    Function check_text(ByVal str As String)
        Dim str_new As String = Replace(Replace(Replace(Replace(Replace(Replace(str, "'", "&#39;"), """", "&quot;"), " ", "&nbsp;"), "&lt;", "<"), "&gt;", ">"), Chr(13), "<br>")
        'Dim str_new As String = Replace(Replace(Replace(Replace(str, "'", "&#39;"), """", "&quot;"), " ", "&nbsp;"), Chr(13), "<br>")
        Return str_new
    End Function
    Function check_text_revert(ByVal str As String)
        Dim str_new As String = Replace(Replace(Replace(Replace(str, "&lt;", "<"), "&gt;", ">"), "&nbsp;", " "), "<br>", "")
        Return str_new
    End Function

    Public Sub windows_open(ByRef aspxPage As System.Web.UI.Page, ByVal strUrl As String, Optional ByVal toolbar As Boolean = True, Optional ByVal w As String = "", Optional ByVal h As String = "")
        If w <> "" Then
            w = ",width=" & w
        End If
        If h <> "" Then
            h = ",height=" & h
        End If

        If strUrl = "" Then
            Exit Sub
        Else
            Dim strScript As String = ""
            If toolbar = False Then
                strScript = "<script language=JavaScript>window.open('" & strUrl & "','','toolbar=no " & w & h & "');</script>"
            Else
                strScript = "<script language=JavaScript>window.open('" & strUrl & "','toolbar=yes " & w & h & "');</script>"
            End If
            If (Not aspxPage.IsStartupScriptRegistered("strKeyUrl")) Then
                aspxPage.RegisterStartupScript("strKeyUrl", strScript)
            End If
        End If
        ',width=150,height=100'
    End Sub

    Function getstatusColor(ByVal strname) As String
        Select Case strname
            Case "waiting"
                Return "<font color=#FF6600>" & strname & "</font>"
            Case "Closed"
                Return "<font color=Black>" & strname & "</font>"
            Case "Ongoing"
                Return "<font color=Green>" & strname & "</font>"
            Case "Panding"
                Return "<font color=Blue>" & strname & "</font>"
            Case "Cancel"
                Return "<font color=Red>" & strname & "</font>"
        End Select
        Return strname
    End Function
End Class
