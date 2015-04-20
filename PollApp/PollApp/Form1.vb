Imports System.IO

Public Class Form1
    Private Sub Application_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Load Tabpages and TableLayouts based on config files: polls.txt and candidate*.txt
        TabControl1.TabPages.Clear()
        If File.Exists("polls.txt") Then
            Dim pollcount As Integer = Storage.getPollsCount()
            For pollindex As Integer = 0 To pollcount - 1
                Design.NewTabPage(TabControl1, Me, pollindex)
                Dim candidatecount = Storage.getCandidateCount(pollindex)
                For candidateindex As Integer = 0 To candidatecount - 1
                    Design.NewRow(Me, candidatecount, candidateindex, pollindex)
                Next
                AddEventsToButtons(Me, pollindex)
                AddEventsToRadioButtons(Me, pollindex, candidatecount)
            Next
            Design.SubmitPage(TabControl1, Me)
            AddEventToSubmitButton(Me)
        Else
            MsgBox("At first, please import Candidates CSV from Admin Panel.")
            Me.Close()
            Form4.Show()
        End If
    End Sub

    Private Sub AddEventsToRadioButtons(ByRef Form1 As Form1, ByVal pollindex As Integer, ByVal candidatecount As Integer)
        For candidateindex = 0 To candidatecount - 1
            Dim RadioButton = Form1.Controls.Find("rb" + Convert.ToString(pollindex) + Convert.ToString(candidateindex), True)(0)
            AddHandler RadioButton.Click, AddressOf RadioButton_Click
        Next
    End Sub

    Public Sub RadioButton_Click(sender As System.Object, e As System.EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        Dim pollindex As Integer = TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
        Dim candidatecount = Storage.getCandidateCount(pollindex)
        For candidateindex = 0 To candidatecount - 1
            Dim radiobutton As RadioButton = TabControl1.SelectedTab.Controls.Find("rb" + Convert.ToString(pollindex) + Convert.ToString(candidateindex), True)(0)
            radiobutton.Checked = False
        Next
        rb.Checked = True
    End Sub

    Private Sub AddEventsToButtons(ByRef Form1 As Form1, ByVal pollindex As Integer)
        If Form1.Controls.Find("nextButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim nextButton = Form1.Controls.Find("nextButton" + Convert.ToString(pollindex), True)(0)
            AddHandler nextButton.Click, AddressOf NextButton_Click
        End If

        If Form1.Controls.Find("backButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim backButton = Form1.Controls.Find("backButton" + Convert.ToString(pollindex), True)(0)
            AddHandler backButton.Click, AddressOf backButton_Click
        End If

        If Form1.Controls.Find("closeButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim closeButton = Form1.Controls.Find("closeButton" + Convert.ToString(pollindex), True)(0)
            AddHandler closeButton.Click, AddressOf closeButton_Click
        End If
    End Sub

    Public Sub NextButton_Click()
        Dim pollindex As Integer = TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
        If pollindex < TabControl1.TabPages.Count - 1 Then
            TabControl1.SelectTab(TabControl1.TabPages.IndexOf(TabControl1.SelectedTab) + 1)
        End If

    End Sub

    Public Sub backButton_Click()
        Dim pollindex As Integer = TabControl1.TabPages.IndexOf(TabControl1.SelectedTab)
        If pollindex > 0 Then
            TabControl1.SelectTab(TabControl1.TabPages.IndexOf(TabControl1.SelectedTab) - 1)
        End If

    End Sub

    Public Sub closeButton_Click()
        Form4.Show()
        Me.Close()
    End Sub

    Public Sub AddEventToSubmitButton(ByRef Form1 As Form1)
        Dim RadioButton = Form1.Controls.Find("submitButton", True)(0)
        AddHandler RadioButton.Click, AddressOf EvaluateVotes
        Dim finalbackButton = Form1.Controls.Find("finalbackButton", True)(0)
        AddHandler finalbackButton.Click, AddressOf finalbackButton_Click
    End Sub

    Public Sub finalbackButton_Click()
        TabControl1.SelectTab(TabControl1.TabPages.IndexOf(TabControl1.SelectedTab) - 1)
    End Sub

    Public Sub EvaluateVotes()
        For pollindex As Integer = 0 To Storage.getPollsCount() - 1
            Dim candidatecount = Storage.getCandidateCount(pollindex)
            For candidateindex = 0 To candidatecount - 1
                Dim radiobutton As RadioButton = TabControl1.Controls.Find("rb" + Convert.ToString(pollindex) + Convert.ToString(candidateindex), True)(0)
                If radiobutton.Checked = True Then
                    Storage.addVote(pollindex, candidateindex)
                End If
            Next
        Next
        MsgBox("Thank You for Voting")
        Form4.Show()
        Me.Close()
    End Sub
End Class