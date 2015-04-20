Imports System.IO

Public Class AdminStorage

    Private Shared pollcount As Integer
    Private Shared polltable As DataTable
    Private Shared ardat() As DataTable


    Public Shared Sub readcsv(ByVal path As String)
        polltable = New DataTable()
        polltable.Columns.Add("pollname", GetType(String))
        Dim sr As New StreamReader(path)
        Dim fullFileStr As String = sr.ReadToEnd()
        sr.Close()
        sr.Dispose()

        Dim lines As String() = fullFileStr.Split({ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
        pollcount = lines(0).Split({","c}, StringSplitOptions.RemoveEmptyEntries).Count

        ReDim ardat(pollcount - 1)

        For index As Integer = 0 To ardat.Count - 1
            ardat(index) = New DataTable
            ardat(index).Columns.Add("Name", GetType(String))
        Next

        For index As Integer = 0 To pollcount - 1
            Dim row As DataRow = polltable.NewRow()
            row.Item(0) = lines(0).Split({","c}, StringSplitOptions.RemoveEmptyEntries)(index)
            polltable.Rows.Add(row)
        Next

        For index As Integer = 0 To pollcount - 1
            Dim sub_index As Integer = 1
            While sub_index < lines.Count
                Dim row1 As DataRow = ardat(index).NewRow()
                row1.Item(0) = lines(sub_index).Split(","c)(index).TrimEnd()
                If row1.Item(0) <> "" Then
                    ardat(index).Rows.Add(row1)
                End If
                sub_index += 1
            End While
        Next
        'MsgBox(ardat(6).Rows.Count)
    End Sub

    Public Shared Sub createfiles()
        Dim poll_fi As New FileInfo("polls.txt")
        poll_fi.Delete()
        Dim poll_f As System.IO.FileStream = System.IO.File.Create("polls.txt")
        poll_f.Close()
        export(polltable, "polls.txt")
        For index As Integer = 0 To pollcount - 1
            If File.Exists("candidates" + index.ToString() + ".txt") Then
                Dim fi As New FileInfo("candidates" + index.ToString() + ".txt")
                fi.Delete()
            End If
        Next
        For index As Integer = 0 To pollcount - 1
            If Not File.Exists("candidates" + index.ToString() + ".txt") Then
                Dim f As System.IO.FileStream = System.IO.File.Create("candidates" + index.ToString() + ".txt")
                f.Close()
            End If
        Next
        For index As Integer = 0 To pollcount - 1
            export(ardat(index), "candidates" + index.ToString() + ".txt")
        Next
    End Sub


    Public Shared Sub export(ByRef table As DataTable, ByVal filename As String)
        Dim lines(table.Rows.Count) As String
        For i As Integer = 0 To table.Rows.Count - 1
            Dim rowString As String = New String("")
            Dim row As DataRow = table.Rows(i)
            rowString = row.Item(0)
            lines(i) = rowString
        Next
        WriteAllLinesBetter(filename, lines)
    End Sub

    Public Shared Sub WriteAllLinesBetter(path As String, ParamArray lines As String())
        If path Is Nothing Then
            Throw New ArgumentNullException("path")
        End If
        If lines Is Nothing Then
            Throw New ArgumentNullException("lines")
        End If
        Using stream = File.OpenWrite(path)
            Using writer As New StreamWriter(stream)
                If lines.Length > 2 Then
                    If lines.Length > 0 Then
                        For i As Integer = 0 To lines.Length - 4
                            writer.WriteLine(lines(i))
                        Next
                        writer.WriteLine(lines(lines.Length - 3))
                        writer.Write(lines(lines.Length - 2))
                    End If
                ElseIf lines.Length = 2 Then
                    writer.Write(lines(lines.Length - 2))
                End If
            End Using
        End Using
    End Sub

End Class
