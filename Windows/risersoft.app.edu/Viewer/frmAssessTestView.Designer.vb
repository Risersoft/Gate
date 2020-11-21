<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAssessTestView
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.cmb_CourseID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.txt_MaxAttempts = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_PerPassScore = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_Duration = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_TestName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.UltraPanel3 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSubmit = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_MaxAttempts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PerPassScore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_Duration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TestName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.UltraPanel3.ClientArea.SuspendLayout()
        Me.UltraPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 95)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(674, 426)
        Me.Panel2.TabIndex = 339
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel4)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_CourseID)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_MaxAttempts)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel12)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_PerPassScore)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_Duration)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_TestName)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(674, 95)
        Me.UltraPanel1.TabIndex = 340
        '
        'UltraLabel4
        '
        Appearance1.FontData.SizeInPoints = 8.25!
        Appearance1.TextHAlignAsString = "Right"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance1
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(386, 13)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel4.TabIndex = 320
        Me.UltraLabel4.Text = "Course :"
        '
        'cmb_CourseID
        '
        Appearance2.FontData.BoldAsString = "False"
        Me.cmb_CourseID.Appearance = Appearance2
        Me.cmb_CourseID.Location = New System.Drawing.Point(440, 11)
        Me.cmb_CourseID.Name = "cmb_CourseID"
        Me.cmb_CourseID.ReadOnly = True
        Me.cmb_CourseID.Size = New System.Drawing.Size(197, 22)
        Me.cmb_CourseID.TabIndex = 319
        Me.cmb_CourseID.Text = "UltraCombo5"
        '
        'txt_MaxAttempts
        '
        Me.txt_MaxAttempts.Location = New System.Drawing.Point(511, 40)
        Me.txt_MaxAttempts.Name = "txt_MaxAttempts"
        Me.txt_MaxAttempts.ReadOnly = True
        Me.txt_MaxAttempts.Size = New System.Drawing.Size(126, 21)
        Me.txt_MaxAttempts.TabIndex = 54
        '
        'UltraLabel12
        '
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance3
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UltraLabel12.Location = New System.Drawing.Point(424, 43)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(83, 14)
        Me.UltraLabel12.TabIndex = 55
        Me.UltraLabel12.Text = "Max Attempts :"
        '
        'UltraLabel3
        '
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance4
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(32, 43)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(71, 14)
        Me.UltraLabel3.TabIndex = 61
        Me.UltraLabel3.Text = "Pass Score :"
        '
        'txt_PerPassScore
        '
        Me.txt_PerPassScore.Location = New System.Drawing.Point(107, 40)
        Me.txt_PerPassScore.Name = "txt_PerPassScore"
        Me.txt_PerPassScore.ReadOnly = True
        Me.txt_PerPassScore.Size = New System.Drawing.Size(153, 21)
        Me.txt_PerPassScore.TabIndex = 60
        '
        'UltraLabel2
        '
        Appearance5.FontData.SizeInPoints = 8.25!
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance5
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(48, 70)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(55, 14)
        Me.UltraLabel2.TabIndex = 59
        Me.UltraLabel2.Text = "Duration :"
        '
        'txt_Duration
        '
        Me.txt_Duration.Location = New System.Drawing.Point(107, 67)
        Me.txt_Duration.Name = "txt_Duration"
        Me.txt_Duration.ReadOnly = True
        Me.txt_Duration.Size = New System.Drawing.Size(128, 21)
        Me.txt_Duration.TabIndex = 58
        '
        'UltraLabel1
        '
        Appearance6.FontData.SizeInPoints = 8.25!
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance6
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(20, 15)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel1.TabIndex = 57
        Me.UltraLabel1.Text = "Test Name :"
        '
        'txt_TestName
        '
        Me.txt_TestName.Location = New System.Drawing.Point(107, 12)
        Me.txt_TestName.Name = "txt_TestName"
        Me.txt_TestName.ReadOnly = True
        Me.txt_TestName.Size = New System.Drawing.Size(238, 21)
        Me.txt_TestName.TabIndex = 56
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(591, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 44)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(508, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 44)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(425, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 44)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
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
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 568)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(674, 44)
        Me.UltraPanel2.TabIndex = 337
        '
        'UltraPanel3
        '
        '
        'UltraPanel3.ClientArea
        '
        Me.UltraPanel3.ClientArea.Controls.Add(Me.btnSubmit)
        Me.UltraPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel3.Location = New System.Drawing.Point(0, 521)
        Me.UltraPanel3.Name = "UltraPanel3"
        Me.UltraPanel3.Size = New System.Drawing.Size(674, 47)
        Me.UltraPanel3.TabIndex = 341
        '
        'btnSubmit
        '
        Me.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubmit.Location = New System.Drawing.Point(575, 0)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(99, 47)
        Me.btnSubmit.TabIndex = 3
        Me.btnSubmit.Text = "Submit"
        '
        'frmAssessTestView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "AssessTest View"
        Me.ClientSize = New System.Drawing.Size(674, 612)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.UltraPanel3)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmAssessTestView"
        Me.Text = "AssessTest View"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_MaxAttempts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PerPassScore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_Duration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TestName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.UltraPanel3.ClientArea.ResumeLayout(False)
        Me.UltraPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_PerPassScore As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_Duration As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_TestName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_MaxAttempts As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraPanel3 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSubmit As Infragistics.Win.Misc.UltraButton
    Friend WithEvents cmb_CourseID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
End Class
