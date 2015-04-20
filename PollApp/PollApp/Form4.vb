Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
            Me.Hide()
            Form3.Show()
        ElseIf VotersListStorage.search(TextBox1.Text, TextBox2.Text) Then
            Me.Hide()
            Form1.Show()
        Else
            MsgBox("The credentials you have entered are incorrect.")
        End If
    End Sub

End Class