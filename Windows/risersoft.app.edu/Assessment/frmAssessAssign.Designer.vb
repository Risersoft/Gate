<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssessAssign
    Inherits frmMax

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call

        Me.InitForm()


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
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFDescrip = New risersoft.[shared].win.ctlRTF()
        Me.UltraPanel3 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.LabelCourse = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmb_CompletionSubmit = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmb_CourseID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_AssignmentName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraTabControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridUsers = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.btnDelUser = New Infragistics.Win.Misc.UltraButton()
        Me.btnAddUser = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        Me.UltraPanel3.ClientArea.SuspendLayout()
        Me.UltraPanel3.SuspendLayout()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        CType(Me.cmb_CompletionSubmit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_AssignmentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl2.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGridUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.CtlRTFDescrip)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(635, 208)
        '
        'CtlRTFDescrip
        '
        Me.CtlRTFDescrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFDescrip.EditEnabled = True
        Me.CtlRTFDescrip.HTMLText = ""
        Me.CtlRTFDescrip.LayoutType = "Continuous"
        Me.CtlRTFDescrip.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFDescrip.Name = "CtlRTFDescrip"
        Me.CtlRTFDescrip.PlainText = ""
        Me.CtlRTFDescrip.RTFText = ""
        Me.CtlRTFDescrip.Size = New System.Drawing.Size(635, 208)
        Me.CtlRTFDescrip.TabIndex = 324
        '
        'UltraPanel3
        '
        '
        'UltraPanel3.ClientArea
        '
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnSave)
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnCancel)
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnOk)
        Me.UltraPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel3.Location = New System.Drawing.Point(0, 319)
        Me.UltraPanel3.Name = "UltraPanel3"
        Me.UltraPanel3.Size = New System.Drawing.Size(639, 48)
        Me.UltraPanel3.TabIndex = 59
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(390, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 48)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(473, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 48)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(556, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 48)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'UltraPanel2
        '
        '
        'UltraPanel2.ClientArea
        '
        Me.UltraPanel2.ClientArea.Controls.Add(Me.LabelCourse)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.cmb_CompletionSubmit)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.cmb_CourseID)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.UltraLabel12)
        Me.UltraPanel2.ClientArea.Controls.Add(Me.txt_AssignmentName)
        Me.UltraPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(639, 85)
        Me.UltraPanel2.TabIndex = 58
        '
        'LabelCourse
        '
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.LabelCourse.Appearance = Appearance1
        Me.LabelCourse.AutoSize = True
        Me.LabelCourse.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelCourse.Location = New System.Drawing.Point(379, 20)
        Me.LabelCourse.Name = "LabelCourse"
        Me.LabelCourse.Size = New System.Drawing.Size(50, 14)
        Me.LabelCourse.TabIndex = 158
        Me.LabelCourse.Text = "Course :"
        '
        'UltraLabel1
        '
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel1.Location = New System.Drawing.Point(5, 51)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(112, 14)
        Me.UltraLabel1.TabIndex = 157
        Me.UltraLabel1.Text = "How to complete it :"
        '
        'cmb_CompletionSubmit
        '
        ValueListItem1.DataValue = False
        ValueListItem1.DisplayText = "Salary"
        ValueListItem2.DataValue = True
        ValueListItem2.DisplayText = "Wage"
        Me.cmb_CompletionSubmit.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.cmb_CompletionSubmit.Location = New System.Drawing.Point(122, 48)
        Me.cmb_CompletionSubmit.Name = "cmb_CompletionSubmit"
        Me.cmb_CompletionSubmit.Size = New System.Drawing.Size(317, 21)
        Me.cmb_CompletionSubmit.TabIndex = 156
        Me.cmb_CompletionSubmit.Text = "UltraComboEditor9"
        '
        'cmb_CourseID
        '
        Appearance3.FontData.BoldAsString = "False"
        Me.cmb_CourseID.Appearance = Appearance3
        Me.cmb_CourseID.Location = New System.Drawing.Point(434, 17)
        Me.cmb_CourseID.Name = "cmb_CourseID"
        Me.cmb_CourseID.ReadOnly = True
        Me.cmb_CourseID.Size = New System.Drawing.Size(197, 22)
        Me.cmb_CourseID.TabIndex = 57
        Me.cmb_CourseID.Text = "UltraCombo5"
        '
        'UltraLabel12
        '
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance4
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(9, 20)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(110, 14)
        Me.UltraLabel12.TabIndex = 55
        Me.UltraLabel12.Text = "Assignment Name :"
        '
        'txt_AssignmentName
        '
        Me.txt_AssignmentName.Location = New System.Drawing.Point(123, 17)
        Me.txt_AssignmentName.Name = "txt_AssignmentName"
        Me.txt_AssignmentName.Size = New System.Drawing.Size(237, 21)
        Me.txt_AssignmentName.TabIndex = 54
        '
        'UltraTabControl2
        '
        Me.UltraTabControl2.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl2.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl2.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl2.Location = New System.Drawing.Point(0, 85)
        Me.UltraTabControl2.Name = "UltraTabControl2"
        Me.UltraTabControl2.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl2.Size = New System.Drawing.Size(639, 234)
        Me.UltraTabControl2.TabIndex = 332
        UltraTab1.Key = "descrip"
        UltraTab1.TabPage = Me.UltraTabPageControl5
        UltraTab1.Text = "Description"
        UltraTab2.Key = "assign"
        UltraTab2.TabPage = Me.UltraTabPageControl1
        UltraTab2.Text = "Assignment"
        Me.UltraTabControl2.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(635, 208)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGridUsers)
        Me.UltraTabPageControl1.Controls.Add(Me.Panel17)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(635, 208)
        '
        'UltraGridUsers
        '
        Me.UltraGridUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridUsers.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridUsers.Name = "UltraGridUsers"
        Me.UltraGridUsers.Size = New System.Drawing.Size(635, 172)
        Me.UltraGridUsers.TabIndex = 6
        Me.UltraGridUsers.Text = "User"
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.btnDelUser)
        Me.Panel17.Controls.Add(Me.btnAddUser)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel17.Location = New System.Drawing.Point(0, 172)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(635, 36)
        Me.Panel17.TabIndex = 7
        '
        'btnDelUser
        '
        Me.btnDelUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelUser.Location = New System.Drawing.Point(493, 0)
        Me.btnDelUser.Name = "btnDelUser"
        Me.btnDelUser.Size = New System.Drawing.Size(70, 36)
        Me.btnDelUser.TabIndex = 1
        Me.btnDelUser.Text = "Delete"
        '
        'btnAddUser
        '
        Me.btnAddUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddUser.Location = New System.Drawing.Point(563, 0)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(72, 36)
        Me.btnAddUser.TabIndex = 2
        Me.btnAddUser.Text = "Add New"
        '
        'frmAssessAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Assess Assign"
        Me.ClientSize = New System.Drawing.Size(639, 367)
        Me.Controls.Add(Me.UltraTabControl2)
        Me.Controls.Add(Me.UltraPanel3)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmAssessAssign"
        Me.Text = "Assess Assign"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraPanel3.ClientArea.ResumeLayout(False)
        Me.UltraPanel3.ResumeLayout(False)
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ClientArea.PerformLayout()
        Me.UltraPanel2.ResumeLayout(False)
        CType(Me.cmb_CompletionSubmit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_AssignmentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl2.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGridUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel3 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents cmb_CourseID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_AssignmentName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabControl2 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CtlRTFDescrip As ctlRTF
    Friend WithEvents cmb_CompletionSubmit As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents LabelCourse As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridUsers As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel17 As Windows.Forms.Panel
    Friend WithEvents btnDelUser As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAddUser As Infragistics.Win.Misc.UltraButton
End Class
