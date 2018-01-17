Imports System.IO

Public Class Mining
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Opacity = 0
        Form2.Show()
        Form3.Opacity = 0
        Form3.Show()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub KonfiguracjaGierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KonfiguracjaGierToolStripMenuItem.Click
        Form2.Opacity = 1
        Form2.Show()
    End Sub

    Private Sub KonfiguracjaKartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KonfiguracjaKartToolStripMenuItem.Click
        Form3.Opacity = 1
        Form3.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim sciezka1 As String = (Form3.TextBox1.Text)
        Dim sciezka2 As String = (Form3.TextBox2.Text)
        Dim g1() As Process = Process.GetProcessesByName(Form2.TextBox1.Text)
        Dim g2() As Process = Process.GetProcessesByName(Form2.TextBox2.Text)
        Dim g3() As Process = Process.GetProcessesByName(Form2.TextBox3.Text)
        Dim g4() As Process = Process.GetProcessesByName(Form2.TextBox4.Text)
        Dim g5() As Process = Process.GetProcessesByName(Form2.TextBox5.Text)
        Dim g6() As Process = Process.GetProcessesByName(Form2.TextBox6.Text)
        Dim nazwa As String = Path.GetFileNameWithoutExtension(sciezka1)
        Dim nazwa2 As String = Path.GetFileNameWithoutExtension(sciezka2)
        Dim procez() As Process = Process.GetProcessesByName(nazwa)
        Dim procez2() As Process = Process.GetProcessesByName(nazwa2)
        Dim filepath As String
        filepath = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, "usercards.txt")

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = ProgressBar1.Minimum
        End If
 
        If File.ReadAllText(filepath).Length = 0 Or sciezka1 = "" Or sciezka2 = "" Then
            TextBox1.Text = "Wybierz ścieżki do aplikacji kopiącycych kryptowalutę."
            TextBox1.Update()
            ProgressBar1.PerformStep()
        Else
            If (g1.Count = 1 Or g2.Count = 1 Or g3.Count = 1 Or g4.Count = 1 Or g5.Count = 1 Or g6.Count = 1) And procez.Count = 0 Then
                TextBox1.Text = "Włączanie kopania standardowego."
                TextBox1.Update()
                Process.Start(sciezka1)
                ProgressBar1.PerformStep()
            ElseIf (g1.Count = 1 Or g2.Count = 1 Or g3.Count = 1 Or g4.Count = 1 Or g5.Count = 1 Or g6.Count = 1) And procez2.Count = 1 Then
                TextBox1.Text = "Wyłączanie kopania zaawansowanego."
                TextBox1.Update()
                procez(0).CloseMainWindow()
                ProgressBar1.PerformStep()
            ElseIf (g1.Count = 0 And g2.Count = 0 And g3.Count = 0 And g4.Count = 0 And g5.Count = 0 And g6.Count = 0) And procez.Count = 1 Then
                TextBox1.Text = "Wyłączanie kopania standardowego."
                TextBox1.Update()
                procez2(0).CloseMainWindow()
                ProgressBar1.PerformStep()
            ElseIf (g1.Count = 0 And g2.Count = 0 And g3.Count = 0 And g4.Count = 0 And g5.Count = 0 And g6.Count = 0) And procez2.Count = 0 Then
                TextBox1.Text = "Włączanie kopania zaawansowanego."
                TextBox1.Update()
                Process.Start(sciezka2)
                ProgressBar1.PerformStep()
            ElseIf (g1.Count = 0 And g2.Count = 0 And g3.Count = 0 And g4.Count = 0 And g5.Count = 0 And g6.Count = 0) And procez2.Count = 1 Then
                TextBox1.Text = "Kopanie zaawansowane."
                TextBox1.Update()
                ProgressBar1.PerformStep()
            ElseIf (g1.Count = 1 Or g2.Count = 1 Or g3.Count = 1 Or g4.Count = 1 Or g5.Count = 1 Or g6.Count = 1) And procez.Count = 1 Then
                TextBox1.Text = "Granie i kopanie standardowe."
                TextBox1.Update()
                ProgressBar1.PerformStep()
            End If
        End If
    End Sub
End Class