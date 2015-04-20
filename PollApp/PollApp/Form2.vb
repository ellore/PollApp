Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Load Tabpages and TableLayouts based on config files: polls.txt and candidate*.txt
        TabControl1.TabPages.Clear()
        Dim pollcount As Integer = Storage.getPollsCount()
        For pollindex As Integer = 0 To pollcount - 1
            AdminDesign.NewTabPage(TabControl1, Me, pollindex, pollcount)
            Dim candidatecount = Storage.getCandidateCount(pollindex)
            AddEventsToButtons(Me, pollindex)
        Next
        LoadPieCharts(Me, pollcount)
    End Sub

    Private Sub LoadPieCharts(ByRef Form2 As Form2, ByVal pollcount As Integer)
        Dim polls() As DataTable = Storage.getPolls()
        For pollindex = 0 To pollcount - 1
            Dim charttable As DataTable = polls(pollindex)
            'Assign Data Table to chart
            If Me.Controls.Find("Chart" + Convert.ToString(pollindex), True).Count > 0 Then
                Dim graph As System.Windows.Forms.DataVisualization.Charting.Chart = Me.Controls.Find("Chart" + Convert.ToString(pollindex), True)(0)
                graph.Series(0)("PieLabelStyle") = "Disabled"
                With graph.Series(0)
                    .Name = "Votes"
                    .Points.DataBind(charttable.DefaultView, "CandidateName", "Votes", Nothing)
                End With
            End If

        Next

    End Sub

    Private Sub AddEventsToButtons(ByRef Form2 As Form2, ByVal pollindex As Integer)
        If Form2.Controls.Find("nextButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim nextButton = Form2.Controls.Find("nextButton" + Convert.ToString(pollindex), True)(0)
            AddHandler nextButton.Click, AddressOf nextButton_Click
        End If

        If Form2.Controls.Find("backButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim backButton = Form2.Controls.Find("backButton" + Convert.ToString(pollindex), True)(0)
            AddHandler backButton.Click, AddressOf backButton_Click
        End If

        If Form2.Controls.Find("closeButton" + Convert.ToString(pollindex), True).Count > 0 Then
            Dim closeButton = Form2.Controls.Find("closeButton" + Convert.ToString(pollindex), True)(0)
            AddHandler closeButton.Click, AddressOf closeButton_Click
        End If
    End Sub

    Public Sub nextButton_Click()
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
        Me.Close()
    End Sub

End Class