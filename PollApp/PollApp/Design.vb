Imports System.IO

Public Class Design
    '
    'Add new row in tlpin corresponding to a candidate
    '
    Public Shared Sub NewRow(ByRef form1 As Form1, ByVal candidatecount As Integer, ByVal candidateindex As Integer, ByVal pollindex As Integer)
        Dim tlp As TableLayoutPanel = form1.Controls.Find("tlpin" + Convert.ToString(pollindex), True)(0)
        tlp.RowStyles.Add(New RowStyle(SizeType.AutoSize))

        Dim TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Dim GroupBox1 = New System.Windows.Forms.GroupBox()
        Dim PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Dim Label2 = New System.Windows.Forms.Label()
        Dim RadioButton1 = New System.Windows.Forms.RadioButton()
        TableLayoutPanel3.SuspendLayout()
        tlp.Controls.Add(TableLayoutPanel3, candidateindex, 0)
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Controls.Add(RadioButton1, 3, 0)
        '
        'TableLayoutPanel3
        '
        TableLayoutPanel3.AutoSize = True
        TableLayoutPanel3.ColumnCount = 4
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.91925!))
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.08075!))
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 273.0!))
        TableLayoutPanel3.Controls.Add(PictureBox1, 1, 0)
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Controls.Add(RadioButton1, 3, 0)
        TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel3.Location = New System.Drawing.Point(6, 6)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 3
        TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        TableLayoutPanel3.Size = New System.Drawing.Size(452, 120)
        TableLayoutPanel3.TabIndex = 0
        '
        'PictureBox1
        '
        PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        PictureBox1.Location = New System.Drawing.Point(50, 3)
        PictureBox1.Name = "PictureBox1"
        TableLayoutPanel3.SetRowSpan(PictureBox1, 2)
        PictureBox1.Size = New System.Drawing.Size(91, 93)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(41, 40)
        Label2.TabIndex = 1
        Label2.Text = Convert.ToString(candidateindex + 1) + ")"
        Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RadioButton1
        '
        RadioButton1.AutoSize = True
        RadioButton1.Dock = System.Windows.Forms.DockStyle.Fill
        RadioButton1.Location = New System.Drawing.Point(181, 3)
        RadioButton1.Name = "rb" + Convert.ToString(pollindex) + Convert.ToString(candidateindex)
        RadioButton1.Size = New System.Drawing.Size(268, 34)
        RadioButton1.TabIndex = 2
        RadioButton1.TabStop = True
        RadioButton1.Text = Storage.getCandidateName(candidateindex, pollindex)
        RadioButton1.UseVisualStyleBackColor = True

        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()

    End Sub


    '-----------------------------------------------------------------
    '    Add new tab page corresponding to a poll
    '-----------------------------------------------------------------
    Public Shared Sub NewTabPage(ByRef Tabcontrol1 As TabControl, ByRef Form1 As Form1, ByVal pollindex As Integer)
        Dim TabPage1 = New System.Windows.Forms.TabPage()
        Dim TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Dim TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Dim FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Dim Label1 = New System.Windows.Forms.Label()
        Dim nextButton = New System.Windows.Forms.Button()
        Dim backButton = New System.Windows.Forms.Button()
        Dim closeButton = New System.Windows.Forms.Button()
        Tabcontrol1.SuspendLayout()
        TabPage1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        FlowLayoutPanel1.SuspendLayout()
        Form1.SuspendLayout()
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
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 1, 1)
        TableLayoutPanel1.Controls.Add(Label1, 1, 0)
        TableLayoutPanel1.Controls.Add(FlowLayoutPanel1, 1, 2)
        TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel1.Location = New System.Drawing.Point(2, 2)
        TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        TableLayoutPanel1.Name = "tlpout" + Convert.ToString(pollindex)
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        TableLayoutPanel1.Size = New System.Drawing.Size(654, 566)
        TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        TableLayoutPanel2.AutoSize = True
        TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 452.0!))
        TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel2.Location = New System.Drawing.Point(98, 83)
        TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        TableLayoutPanel2.Name = "tlpin" + Convert.ToString(pollindex)
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        TableLayoutPanel2.Size = New System.Drawing.Size(458, 106)
        TableLayoutPanel2.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.Controls.Add(closeButton)
        If pollindex > 0 Then
            FlowLayoutPanel1.Controls.Add(backButton)
        End If
        FlowLayoutPanel1.Controls.Add(nextButton)
        FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        FlowLayoutPanel1.Location = New System.Drawing.Point(450, 384)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New System.Drawing.Size(61, 179)
        FlowLayoutPanel1.TabIndex = 1
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
        closeButton.Location = New System.Drawing.Point(480, 194)
        closeButton.Name = "closeButton" + Convert.ToString(pollindex)
        closeButton.Size = New System.Drawing.Size(75, 23)
        closeButton.TabIndex = 2
        closeButton.Text = "Close"
        closeButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Tabcontrol1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        FlowLayoutPanel1.ResumeLayout(False)
        Form1.ResumeLayout(False)
    End Sub

    '-----------------------------------------------------------------
    '    Add 'Confirm Submission' page at the end
    '-----------------------------------------------------------------
    Public Shared Sub SubmitPage(ByRef Tabcontrol1 As TabControl, ByRef Form1 As Form1)
        Dim TabPage1 = New System.Windows.Forms.TabPage()
        Dim TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Dim FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Dim Button2 = New System.Windows.Forms.Button()
        Dim backButton = New System.Windows.Forms.Button()
        Dim Label3 = New System.Windows.Forms.Label()
        Dim Panel1 = New System.Windows.Forms.Panel()
        TabPage1.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        Panel1.SuspendLayout()
        '
        'TabControl1
        '
        Tabcontrol1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Tabcontrol1.Controls.Add(TabPage1)
        Tabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Tabcontrol1.ItemSize = New System.Drawing.Size(0, 1)
        Tabcontrol1.Location = New System.Drawing.Point(0, 0)
        Tabcontrol1.Margin = New System.Windows.Forms.Padding(2)
        Tabcontrol1.Name = "TabControl1"
        Tabcontrol1.SelectedIndex = 0
        Tabcontrol1.Size = New System.Drawing.Size(741, 596)
        Tabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Tabcontrol1.TabIndex = 0
        '
        'TabPage1
        '
        TabPage1.BackColor = System.Drawing.SystemColors.ControlLightLight
        TabPage1.Controls.Add(TableLayoutPanel4)
        TabPage1.Location = New System.Drawing.Point(4, 22)
        TabPage1.Margin = New System.Windows.Forms.Padding(2)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New System.Windows.Forms.Padding(2)
        TabPage1.Size = New System.Drawing.Size(658, 570)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        TableLayoutPanel4.AutoScroll = True
        TableLayoutPanel4.ColumnCount = 3
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500.0!))
        TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        TableLayoutPanel4.Controls.Add(FlowLayoutPanel1, 1, 2)
        TableLayoutPanel4.Controls.Add(Panel1, 1, 1)
        TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 3
        TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        TableLayoutPanel4.Size = New System.Drawing.Size(652, 564)
        TableLayoutPanel4.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        FlowLayoutPanel1.AutoSize = True
        FlowLayoutPanel1.Controls.Add(backButton)
        FlowLayoutPanel1.Controls.Add(Button2)
        FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        FlowLayoutPanel1.Location = New System.Drawing.Point(450, 384)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New System.Drawing.Size(61, 179)
        FlowLayoutPanel1.TabIndex = 1
        '
        'Button2
        '
        Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Button2.Location = New System.Drawing.Point(498, 384)
        Button2.Name = "submitButton"
        Button2.Size = New System.Drawing.Size(75, 23)
        Button2.TabIndex = 0
        Button2.Text = "Submit"
        Button2.UseVisualStyleBackColor = True
        '
        'backButton
        '
        backButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        backButton.Location = New System.Drawing.Point(480, 194)
        backButton.Name = "finalbackButton"
        backButton.Size = New System.Drawing.Size(75, 23)
        backButton.TabIndex = 2
        backButton.Text = "Back"
        backButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Label3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(19, 120)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(462, 49)
        Label3.TabIndex = 1
        Label3.Text = "Do you want to confirm your submission?"
        '
        'Panel1
        '
        Panel1.Controls.Add(Label3)
        Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Panel1.Location = New System.Drawing.Point(79, 84)
        Panel1.Name = "Panel1"
        Panel1.Size = New System.Drawing.Size(494, 294)
        Panel1.TabIndex = 2

        TabPage1.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
    End Sub

End Class

