<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCourseView
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        Me.InitForm()


    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_TimeLimit = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Level = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_CourseCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_CourseName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnViewSelected = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel3 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnStart = New Infragistics.Win.Misc.UltraButton()
        Me.btnContinue = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridList = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_TimeLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Level, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.UltraPanel3.ClientArea.SuspendLayout()
        Me.UltraPanel3.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_TimeLimit)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Level)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_CourseCode)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel12)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_CourseName)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(706, 78)
        Me.UltraPanel1.TabIndex = 336
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.FontData.SizeInPoints = 8.25!
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance5
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(438, 46)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(65, 14)
        Me.UltraLabel3.TabIndex = 61
        Me.UltraLabel3.Text = "Time Limit :"
        '
        'txt_TimeLimit
        '
        Me.txt_TimeLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_TimeLimit.Location = New System.Drawing.Point(507, 43)
        Me.txt_TimeLimit.Name = "txt_TimeLimit"
        Me.txt_TimeLimit.ReadOnly = True
        Me.txt_TimeLimit.Size = New System.Drawing.Size(161, 21)
        Me.txt_TimeLimit.TabIndex = 60
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.FontData.SizeInPoints = 8.25!
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance6
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(464, 15)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(39, 14)
        Me.UltraLabel2.TabIndex = 59
        Me.UltraLabel2.Text = "Level :"
        '
        'txt_Level
        '
        Me.txt_Level.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Level.Location = New System.Drawing.Point(507, 12)
        Me.txt_Level.Name = "txt_Level"
        Me.txt_Level.ReadOnly = True
        Me.txt_Level.Size = New System.Drawing.Size(161, 21)
        Me.txt_Level.TabIndex = 58
        '
        'UltraLabel1
        '
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.TextHAlignAsString = "Right"
        Appearance7.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance7
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(23, 15)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(79, 14)
        Me.UltraLabel1.TabIndex = 57
        Me.UltraLabel1.Text = "Course Code :"
        '
        'txt_CourseCode
        '
        Me.txt_CourseCode.Location = New System.Drawing.Point(107, 12)
        Me.txt_CourseCode.Name = "txt_CourseCode"
        Me.txt_CourseCode.ReadOnly = True
        Me.txt_CourseCode.Size = New System.Drawing.Size(161, 21)
        Me.txt_CourseCode.TabIndex = 56
        '
        'UltraLabel12
        '
        Appearance8.FontData.SizeInPoints = 8.25!
        Appearance8.TextHAlignAsString = "Right"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance8
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(19, 46)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel12.TabIndex = 55
        Me.UltraLabel12.Text = "Course Name :"
        '
        'txt_CourseName
        '
        Me.txt_CourseName.Location = New System.Drawing.Point(107, 43)
        Me.txt_CourseName.Name = "txt_CourseName"
        Me.txt_CourseName.ReadOnly = True
        Me.txt_CourseName.Size = New System.Drawing.Size(221, 21)
        Me.txt_CourseName.TabIndex = 54
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnViewSelected)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 392)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(706, 44)
        Me.UltraPanel2.TabIndex = 332
        '
        'btnViewSelected
        '
        Me.btnViewSelected.Location = New System.Drawing.Point(268, 0)
        Me.btnViewSelected.Name = "btnViewSelected"
        Me.btnViewSelected.Size = New System.Drawing.Size(99, 44)
        Me.btnViewSelected.TabIndex = 5
        Me.btnViewSelected.Tag = "Add"
        Me.btnViewSelected.Text = "View Selected"
        '
        'UltraPanel3
        '
        '
        'UltraPanel3.ClientArea
        '
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnStart)
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnContinue)
        Me.UltraPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel3.Location = New System.Drawing.Point(0, 78)
        Me.UltraPanel3.Name = "UltraPanel3"
        Me.UltraPanel3.Size = New System.Drawing.Size(706, 44)
        Me.UltraPanel3.TabIndex = 337
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(182, 0)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(99, 44)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Tag = "Add"
        Me.btnStart.Text = "Start"
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(345, 0)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(99, 44)
        Me.btnContinue.TabIndex = 3
        Me.btnContinue.Text = "Continue"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 122)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(706, 270)
        Me.UltraTabControl1.TabIndex = 338
        UltraTab1.Key = "0"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "List"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(702, 244)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridList)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(702, 244)
        '
        'UltraGridList
        '
        Me.UltraGridList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridList.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridList.Name = "UltraGridList"
        Me.UltraGridList.Size = New System.Drawing.Size(702, 244)
        Me.UltraGridList.TabIndex = 0
        Me.UltraGridList.Text = "Content Units"
        '
        'frmCourseView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Course View"
        Me.ClientSize = New System.Drawing.Size(706, 436)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraPanel3)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmCourseView"
        Me.Text = "Course View"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_TimeLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Level, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.UltraPanel3.ClientArea.ResumeLayout(False)
        Me.UltraPanel3.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_TimeLimit As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Level As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_CourseCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_CourseName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraPanel3 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnStart As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnContinue As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnViewSelected As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridList As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
