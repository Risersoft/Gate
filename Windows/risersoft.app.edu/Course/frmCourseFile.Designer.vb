<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCourseFile
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.CtlUpLoad2 = New risersoft.[shared].win.ctlUpLoad()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmb_CourseID = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FileSizeKB = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FileType = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FileName = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_FileURL = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraPanel2 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnCancel = New Infragistics.Win.Misc.UltraButton()
        Me.btnOk = New Infragistics.Win.Misc.UltraButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FileSizeKB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FileType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FileName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_FileURL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel2.ClientArea.SuspendLayout()
        Me.UltraPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.CtlUpLoad2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.Label9)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_CourseID)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel3)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_FileSizeKB)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel2)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_FileType)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel1)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_FileName)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel12)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.txt_FileURL)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(490, 267)
        Me.UltraPanel1.TabIndex = 56
        '
        'CtlUpLoad2
        '
        Me.CtlUpLoad2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CtlUpLoad2.Location = New System.Drawing.Point(3, 156)
        Me.CtlUpLoad2.Name = "CtlUpLoad2"
        Me.CtlUpLoad2.Size = New System.Drawing.Size(487, 108)
        Me.CtlUpLoad2.TabIndex = 222
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(25, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 19)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Course :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_CourseID
        '
        Appearance1.FontData.BoldAsString = "False"
        Me.cmb_CourseID.Appearance = Appearance1
        Me.cmb_CourseID.Location = New System.Drawing.Point(96, 12)
        Me.cmb_CourseID.Name = "cmb_CourseID"
        Me.cmb_CourseID.Size = New System.Drawing.Size(197, 22)
        Me.cmb_CourseID.TabIndex = 63
        Me.cmb_CourseID.Text = "UltraCombo5"
        '
        'UltraLabel3
        '
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance2
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(34, 101)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel3.TabIndex = 61
        Me.UltraLabel3.Text = "File Size :"
        '
        'txt_FileSizeKB
        '
        Me.txt_FileSizeKB.Location = New System.Drawing.Point(96, 98)
        Me.txt_FileSizeKB.Name = "txt_FileSizeKB"
        Me.txt_FileSizeKB.ReadOnly = True
        Me.txt_FileSizeKB.Size = New System.Drawing.Size(161, 21)
        Me.txt_FileSizeKB.TabIndex = 60
        '
        'UltraLabel2
        '
        Appearance3.FontData.SizeInPoints = 8.25!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(32, 127)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(57, 14)
        Me.UltraLabel2.TabIndex = 59
        Me.UltraLabel2.Text = "File Type :"
        '
        'txt_FileType
        '
        Me.txt_FileType.Location = New System.Drawing.Point(96, 126)
        Me.txt_FileType.Name = "txt_FileType"
        Me.txt_FileType.ReadOnly = True
        Me.txt_FileType.Size = New System.Drawing.Size(161, 21)
        Me.txt_FileType.TabIndex = 58
        '
        'UltraLabel1
        '
        Appearance4.FontData.SizeInPoints = 8.25!
        Appearance4.TextHAlignAsString = "Right"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(29, 44)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel1.TabIndex = 57
        Me.UltraLabel1.Text = "File Name :"
        '
        'txt_FileName
        '
        Me.txt_FileName.Location = New System.Drawing.Point(96, 41)
        Me.txt_FileName.Name = "txt_FileName"
        Me.txt_FileName.ReadOnly = True
        Me.txt_FileName.Size = New System.Drawing.Size(258, 21)
        Me.txt_FileName.TabIndex = 56
        '
        'UltraLabel12
        '
        Appearance5.FontData.SizeInPoints = 8.25!
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance5
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(36, 73)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(54, 14)
        Me.UltraLabel12.TabIndex = 55
        Me.UltraLabel12.Text = "File URL :"
        '
        'txt_FileURL
        '
        Me.txt_FileURL.Location = New System.Drawing.Point(96, 70)
        Me.txt_FileURL.Name = "txt_FileURL"
        Me.txt_FileURL.ReadOnly = True
        Me.txt_FileURL.Size = New System.Drawing.Size(258, 21)
        Me.txt_FileURL.TabIndex = 54
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
        Me.UltraPanel2.Location = New System.Drawing.Point(0, 267)
        Me.UltraPanel2.Name = "UltraPanel2"
        Me.UltraPanel2.Size = New System.Drawing.Size(490, 44)
        Me.UltraPanel2.TabIndex = 55
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSave.Location = New System.Drawing.Point(241, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 44)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.Location = New System.Drawing.Point(324, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(83, 44)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnOk.Location = New System.Drawing.Point(407, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(83, 44)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "XLS Files|*.xls|XLSX Files|*.xlsx"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "JPG Files|*.jpg|GIF Files|*.gif|BMP Files|*.bmp"
        '
        'frmCourseFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "Course File"
        Me.ClientSize = New System.Drawing.Size(490, 311)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Controls.Add(Me.UltraPanel2)
        Me.Name = "frmCourseFile"
        Me.Text = "Course File"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.cmb_CourseID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FileSizeKB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FileType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FileName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_FileURL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel2.ClientArea.ResumeLayout(False)
        Me.UltraPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FileSizeKB As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FileName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_FileURL As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraPanel2 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnOk As Infragistics.Win.Misc.UltraButton
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents cmb_CourseID As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents CtlUpLoad2 As ctlUpLoad
    Friend WithEvents txt_FileType As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents SaveFileDialog1 As Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
End Class
