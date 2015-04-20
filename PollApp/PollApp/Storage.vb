Imports System.IO

Public Class Storage

    Private Shared polls() As DataTable
    Private Shared pollnames As DataTable
    Private Shared count As Integer

    Shared Sub New()
        pollnames = New DataTable()
        pollnames.Columns.Add("name", GetType(String))
        pollnames = importPollNames(pollnames)

        'Loads data from text files into Data Tables
        Dim lines() As String = {}
        If File.Exists("polls.txt") Then
            lines = File.ReadAllLines("polls.txt")
            count = lines.Count
        Else
            MsgBox("polls.txt is not found")
        End If
        ReDim polls(count)
        For index As Integer = 0 To count - 1
            polls(index) = New DataTable()
            polls(index).Columns.Add("CandidateName", GetType(String))
            polls(index).Columns.Add("Votes", GetType(Integer))
        Next
        For index As Integer = 0 To count - 1
            If Not File.Exists("votes" + index.ToString() + ".txt") Then
                Dim poll_f As System.IO.FileStream = System.IO.File.Create("votes" + index.ToString() + ".txt")
                poll_f.Close()
            End If
            If File.Exists("candidates" + index.ToString() + ".txt") Then
                polls(index) = importTable(polls(index), index)
            End If
        Next
    End Sub

    Private Shared Function importTable(ByRef DataTable As DataTable, ByVal index As Integer) As DataTable
        Dim newTable As DataTable = DataTable.Clone()
        Dim votelines() As String = {}
        Dim candidatelines() As String = File.ReadAllLines("candidates" + index.ToString() + ".txt")
        If File.Exists("votes" + index.ToString() + ".txt") Then
            votelines = File.ReadAllLines("votes" + index.ToString() + ".txt")
        End If
        If votelines.Count < candidatelines.Count Then
            ReDim votelines(candidatelines.Count)
            For Each voteline As String In votelines
                voteline = "0"
            Next
        End If
        For lineindex = 0 To candidatelines.Count - 1
            Dim row As DataRow = newTable.NewRow()
            row(0) = candidatelines(lineindex)
            row(1) = Convert.ToInt32(votelines(lineindex))
            newTable.Rows.Add(row)
        Next
        Return newTable
    End Function

    Public Shared Sub addVote(ByVal pollindex As Integer, ByVal candidateindex As Integer)
        'Plus one the number of votes for a particular candidate
        Dim row As DataRow = polls(pollindex).Rows(candidateindex)
        row(1) = row(1) + 1
        exportTable(polls(pollindex), "votes" + pollindex.ToString() + ".txt")
    End Sub

    Private Shared Function exportTable(ByVal table As DataTable, ByVal filename As String) As Boolean
        'Update the votes from DataTable to Text file
        Dim lines(table.Rows.Count) As String
        For i As Integer = 0 To table.Rows.Count - 1
            Dim row As DataRow = table.Rows(i)
            lines(i) = row(1)
        Next
        AdminStorage.WriteAllLinesBetter(filename, lines)
        Return True
    End Function

    Private Shared Function importPollNames(ByRef DataTable As DataTable) As DataTable
        Dim newTable As DataTable = DataTable.Clone()
        Dim lines() As String = {}
        If File.Exists("polls.txt") Then
            lines = File.ReadAllLines("polls.txt")
        End If
        For Each line As String In lines
            Dim row As DataRow = newTable.NewRow()
            row(0) = line
            newTable.Rows.Add(row)
        Next
        Return newTable
    End Function

    Public Shared Function getPollName(ByVal pollindex As Integer) As String
        'Get name of poll from DataTable
        Return pollnames.Rows(pollindex)(0)
    End Function

    Public Shared Function getPollsCount() As Integer
        'Get the number of polls from DataTable
        Return count
    End Function

    Public Shared Function getCandidateCount(ByVal pollindex As Integer) As Integer
        'Get the number of candidates from DataTable
        Return polls(pollindex).Rows.Count
    End Function

    Public Shared Function getCandidateName(ByVal candidateindex As Integer, ByVal pollindex As Integer) As String
        'Get name of a particular canididate contesting for a particular poll from DataTable
        Dim table As DataTable = Storage.polls(pollindex)
        Return table.Rows(candidateindex)(0)
    End Function

    Public Shared Function getPolls() As DataTable()
        Return polls.Clone()
    End Function

    Public Shared Sub ResetVotes()
        For Each myFile As String In Directory.GetFiles(System.Windows.Forms.Application.StartupPath, "votes*.txt")
            File.Delete(myFile)
        Next
        For index As Integer = 0 To count - 1
            For sub_index As Integer = 0 To polls(index).Rows.Count - 1
                polls(index).Rows(sub_index)(1) = "0"
            Next
        Next
    End Sub

End Class


Public Class VotersListStorage
    Private Shared voterslist As DataTable

    Shared Sub New()
        voterslist = New DataTable()
        voterslist.Columns.Add("user_id", GetType(String))
        voterslist.Columns.Add("password", GetType(String))
        voterslist.Columns.Add("state", GetType(String))

        If File.Exists("voterslist.csv") Then
            Dim sr As New StreamReader("voterslist.csv")
            Dim fullfileStr As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            Dim voterslistlines As String() = fullfileStr.Split({ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
            For index As Integer = 0 To voterslistlines.Count - 1
                Dim row As DataRow = voterslist.NewRow()
                row.Item(0) = voterslistlines(index).Split(","c)(0)
                row.Item(1) = voterslistlines(index).Split(","c)(1).TrimEnd()
                row.Item(2) = False
                voterslist.Rows.Add(row)
            Next
        End If
    End Sub

    Public Shared Function search(ByVal username As String, ByVal password As String) As Boolean
        Dim check As Boolean = False
        For index As Integer = 0 To voterslist.Rows.Count - 1
            If voterslist.Rows(index)(0) = username And voterslist.Rows(index)(1) = password Then
                check = True
                Exit For
            End If
        Next
        Return check
    End Function
End Class