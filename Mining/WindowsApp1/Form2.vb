Imports System.IO
Imports System.Xml.Serialization

Public Class Form2

    Public Structure User
        Public g1 As String
        Public g2 As String
        Public g3 As String
        Public g4 As String
        Public g5 As String
        Public g6 As String
    End Structure

    Private Function CreateRecord() As User
        Dim r As User
        With r
            .g1 = TextBox1.Text
            .g2 = TextBox2.Text
            .g3 = TextBox3.Text
            .g4 = TextBox4.Text
            .g5 = TextBox5.Text
            .g6 = TextBox6.Text
        End With
        Return r
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ser As New XmlSerializer(GetType(User))
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "userrecord.txt")
        Dim fs As New FileStream(filepath, FileMode.Create)
        ser.Serialize(fs, CreateRecord())
        fs.Close()
    End Sub
    Private Sub LoadIntoTB(ByVal rec As User)
        With rec
            TextBox1.Text = .g1
            TextBox2.Text = .g2
            TextBox3.Text = .g3
            TextBox4.Text = .g4
            TextBox5.Text = .g5
            TextBox6.Text = .g6
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ser As New XmlSerializer(GetType(User))
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "userrecord.txt")
        Dim fs As New FileStream(filepath, FileMode.OpenOrCreate)
        Dim rec As User
        rec = DirectCast(ser.Deserialize(fs), User)
        LoadIntoTB(rec)
        fs.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2_Click(sender, e)
    End Sub

    Private Sub frmNotary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Button1_Click(sender, e)
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub
End Class