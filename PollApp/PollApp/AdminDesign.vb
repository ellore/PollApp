Imports System.IO

Public Class AdminDesign
    '-----------------------------------------------------------------
    '    Add new tab page corresponding to a poll
    '-----------------------------------------------------------------
    Public Shared Sub NewTabPage(ByRef Tabcontrol1 As TabControl, ByRef Form2 As Form2, ByVal pollindex As Integer, ByVal pollcount As Integer)
        Dim TabPage1 = New System.Windows.Forms.TabPage()
        Dim TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Dim FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Dim Label1 = New System.Windows.Forms.Label()
        Dim nextButton = New System.Windows.Forms.Button()
        Dim backButton = New System.Windows.Forms.Button()
        Dim closeButton = New System.Windows.Forms.Button()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()

        Tabcontrol1.SuspendLayout()
        TabPage1.SuspendLayout()
        CType(Form2.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        Form2.SuspendLayout()
        '
        'TabControl1
        '
        Tabcontrol1.Controls.Add(TabPage1)
        Tabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Tabcontrol1.Location = New System.Drawing.Point(0, 0)
        Tabcontrol1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Tabcontrol1.Name = "TabControl1"
        Tabcontrol1.SelectedIndex = 0
        Tabcontrol1.Size = New System.Drawing.Size(666, 596)
        Tabcontrol1.TabIndex = 0
        '
        'TabPage1
        '
        TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        TabPage1.Controls.Add(TableLayoutPanel1)
        TabPage1.Location = New System.Drawing.Point(4, 22)
        TabPage1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        TabPage1.Size = New System.Drawing.Size(658, 570)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        TableLayoutPanel1.AutoScroll = True
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        TableLayoutPanel1.Controls.Add(Label1, 1, 0)
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel1, 1, 2)
        TableLayoutPanel1.Controls.Add(Chart1, 1, 1)
        TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        TableLayoutPanel1.Name = "tlpout" + Convert.ToString(pollindex)
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        TableLayoutPanel1.Size = New System.Drawing.Size(654, 566)
        TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(98, 0)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(458, 81)
        Label1.TabIndex = 1
        Label1.Text = Storage.getPollName(pollindex)
        Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FlowLayoutPanel1
        '
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.Controls.Add(closeButton)
        If pollindex > 0 Then
            FlowLayoutPanel1.Controls.Add(backButton)
        End If
        If pollindex < pollcount Then
            FlowLayoutPanel1.Controls.Add(nextButton)
        End If
        FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        FlowLayoutPanel1.Location = New System.Drawing.Point(269, 372)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New System.Drawing.Size(152, 64)
        FlowLayoutPanel1.TabIndex = 2
        '
        'nextButton
        '
        nextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        nextButton.Location = New System.Drawing.Point(480, 194)
        nextButton.Name = "nextButton" + Convert.ToString(pollindex)
        nextButton.Size = New System.Drawing.Size(75, 23)
        nextButton.TabIndex = 2
        nextButton.Text = "Next"
        nextButton.UseVisualStyleBackColor = True
        '
        'backButton
        '
        backButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        backButton.Location = New System.Drawing.Point(480, 194)
        backButton.Name = "backButton" + Convert.ToString(pollindex)
        backButton.Size = New System.Drawing.Size(75, 23)
        backButton.TabIndex = 2
        backButton.Text = "Back"
        backButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        closeButton.Location = New System.Drawing.Point(351, 372)
        closeButton.Name = "closeButton" + Convert.ToString(pollindex)
        closeButton.Size = New System.Drawing.Size(70, 23)
        closeButton.TabIndex = 1
        closeButton.Text = "Close"
        closeButton.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea" + Convert.ToString(pollindex)
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend" + Convert.ToString(pollindex)
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New System.Drawing.Point(127, 72)
        Chart1.Name = "Chart" + Convert.ToString(pollindex)
        Series1.ChartArea = "ChartArea" + Convert.ToString(pollindex)
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend" + Convert.ToString(pollindex)
        Series1.Name = "Series" + Convert.ToString(pollindex)
        Chart1.Series.Add(Series1)
        Chart1.Size = New System.Drawing.Size(294, 294)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart" + Convert.ToString(pollindex)
        '
        'Form2
        '
        Tabcontrol1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        CType(Form2.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        FlowLayoutPanel1.ResumeLayout(False)
        Form2.ResumeLayout(False)
    End Sub
End Class

