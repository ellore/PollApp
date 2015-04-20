Imports System.IO

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            If System.IO.File.Exists("import2.csv") = True Then
                Dim fi As New FileInfo("import2.csv")
                fi.Delete()
            End If
            File.Copy(dialog.FileName, "import2.csv")
        End Using
        AdminStorage.readcsv("import2.csv")
        AdminStorage.createfiles()
        MsgBox("Upload Successful")
        Storage.ResetVotes()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If File.Exists("polls.txt") Then
            Form2.ShowDialog()
        Else
            MsgBox("Please Upload Candidates CSV first.")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Application.Restart()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using dialog As New OpenFileDialog
            If dialog.ShowDialog() <> DialogResult.OK Then Return
            If System.IO.File.Exists("voterslist.csv") = True Then
                Dim fi As New FileInfo("voterslist.csv")
                fi.Delete()
            End If
            File.Copy(dialog.FileName, "voterslist.csv")
        End Using
        MsgBox("Upload Successful")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If File.Exists("polls.txt") Then
            Storage.ResetVotes()
            MsgBox("Votes have been reset")
        Else
            MsgBox("Please Upload Candidates CSV first.")
        End If
    End Sub
End Class