<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCourseUser
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        Me.initForm()


    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_TimeLimit = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Level = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_CourseCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_CourseName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridUsers = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.btnDelUser = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddUser = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.txt_TimeLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Level, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnSave)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnCancel)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.btnOk)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 371)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(612, 41)
        Me.UltraPanel2.TabIndex = 13
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(363, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 41)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(446, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 41)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(529, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 41)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
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
        Me.UltraPanel1.Size = New System.Drawing.Size(612, 75)
        Me.UltraPanel1.TabIndex = 54
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance1
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(344, 46)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(65, 14)
        Me.UltraLabel3.TabIndex = 61
        Me.UltraLabel3.Text = "Time Limit :"
        '
        'txt_TimeLimit
        '
        Me.txt_TimeLimit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_TimeLimit.Location = New System.Drawing.Point(413, 43)
        Me.txt_TimeLimit.Name = "txt_TimeLimit"
        Me.txt_TimeLimit.ReadOnly = True
        Me.txt_TimeLimit.Size = New System.Drawing.Size(161, 21)
        Me.txt_TimeLimit.TabIndex = 60
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance2
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(370, 15)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(39, 14)
        Me.UltraLabel2.TabIndex = 59
        Me.UltraLabel2.Text = "Level :"
        '
        'txt_Level
        '
        Me.txt_Level.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Level.Location = New System.Drawing.Point(413, 12)
        Me.txt_Level.Name = "txt_Level"
        Me.txt_Level.ReadOnly = True
        Me.txt_Level.Size = New System.Drawing.Size(161, 21)
        Me.txt_Level.TabIndex = 58
        '
        'UltraLabel1
        '
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(23, 15)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(80, 14)
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
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance4
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
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 75)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl1.Size = New System.Drawing.Size(612, 296)
        Me.UltraTabControl1.TabIndex = 55
        UltraTab1.Key = "routing"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Users"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(608, 270)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridUsers)
        Me.UltraTabPageControl1.Controls.Add(Me.Panel17)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(608, 270)
        '
        'UltraGridUsers
        '
        Me.UltraGridUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridUsers.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridUsers.Name = "UltraGridUsers"
        Me.UltraGridUsers.Size = New System.Drawing.Size(608, 234)
        Me.UltraGridUsers.TabIndex = 0
        Me.UltraGridUsers.Text = "User"
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.btnDelUser)
        Me.Panel17.Controls.Add(Me.btnAddUser)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel17.Location = New System.Drawing.Point(0, 234)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(608, 36)
        Me.Panel17.TabIndex = 1
        '
        'btnDelUser
        '
        Me.btnDelUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelUser.Location = New System.Drawing.Point(466, 0)
        Me.btnDelUser.Name = "btnDelUser"
        Me.btnDelUser.Size = New System.Drawing.Size(70, 36)
        Me.btnDelUser.TabIndex = 1
        Me.btnDelUser.Text = "Delete"
        '
        'btnAddUser
        '
        Me.btnAddUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddUser.Location = New System.Drawing.Point(536, 0)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(72, 36)
        Me.btnAddUser.TabIndex = 2
        Me.btnAddUser.Text = "Add New"
        '
        'frmCourseUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Course User"
        Me.ClientSize = New System.Drawing.Size(612, 412)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmCourseUser"
        Me.Text = "Course User"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.txt_TimeLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Level, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CourseCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_CourseName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_TimeLimit As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Level As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_CourseCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_CourseName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridUsers As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel17 As Windows.Forms.Panel
    Friend WithEvents btnDelUser As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddUser As Infragistics.Win.Misc.UltraButton
End Class
