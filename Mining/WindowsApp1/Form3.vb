Imports System.IO
Imports System.Xml.Serialization

Public Class Form3
    Public Structure User
        Public c1 As String
        Public c2 As String
    End Structure

    Private Function CreateRecord() As User
        Dim r As User
        With r
            .c1 = TextBox1.Text
            .c2 = TextBox2.Text
        End With
        Return r
    End Function

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            TextBox2.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ser As New XmlSerializer(GetType(User))
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "usercards.txt")
        Dim fs As New FileStream(filepath, FileMode.Create)
        ser.Serialize(fs, CreateRecord())
        fs.Close()
    End Sub
    Private Sub LoadIntoTB(ByVal rec As User)
        With rec
            TextBox1.Text = .c1
            TextBox2.Text = .c2
        End With
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ser As New XmlSerializer(GetType(User))
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "usercards.txt")
        Dim fs As New FileStream(filepath, FileMode.OpenOrCreate)
        Dim rec As User
        rec = DirectCast(ser.Deserialize(fs), User)
        LoadIntoTB(rec)
        fs.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "usercards.txt")
        If File.Exists(filepath) Then
            If File.ReadAllText(filepath).Length <> 0 Then
                Button4_Click(sender, e)
            End If
        Else
            MsgBox("Wybierz ścieżki do aplikacji kopiącycych kryptowalutę.")
            MsgBox("Zrobisz to klikając prawym w głównym oknie i przechodząc do Konfiguracji Kart.")
        End If
    End Sub

    Private Sub frmNotary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Button3_Click(sender, e)
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub
End Class