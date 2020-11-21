<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContentUnitView
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
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFHTML = New risersoft.[shared].win.ctlRTF()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFUpload = New risersoft.[shared].win.ctlRTF()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFWeb = New risersoft.[shared].win.ctlRTF()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnContPrev = New Infragistics.Win.Misc.UltraButton()
        Me.btnStartNew = New Infragistics.Win.Misc.UltraButton()
        Me.btnStart = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraPanel4 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnPrevious = New Infragistics.Win.Misc.UltraButton()
        Me.btnNext = New Infragistics.Win.Misc.UltraButton()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraPanel4.ClientArea.SuspendLayout()
        Me.UltraPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.CtlRTFHTML)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(655, 322)
        '
        'CtlRTFHTML
        '
        Me.CtlRTFHTML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFHTML.EditEnabled = True
        Me.CtlRTFHTML.HTMLText = ""
        Me.CtlRTFHTML.LayoutType = "Continuous"
        Me.CtlRTFHTML.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFHTML.Name = "CtlRTFHTML"
        Me.CtlRTFHTML.PlainText = ""
        Me.CtlRTFHTML.RTFText = ""
        Me.CtlRTFHTML.Size = New System.Drawing.Size(655, 322)
        Me.CtlRTFHTML.TabIndex = 203
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.CtlRTFUpload)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(655, 313)
        '
        'CtlRTFUpload
        '
        Me.CtlRTFUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFUpload.EditEnabled = True
        Me.CtlRTFUpload.HTMLText = ""
        Me.CtlRTFUpload.LayoutType = "Continuous"
        Me.CtlRTFUpload.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFUpload.Name = "CtlRTFUpload"
        Me.CtlRTFUpload.PlainText = ""
        Me.CtlRTFUpload.RTFText = ""
        Me.CtlRTFUpload.Size = New System.Drawing.Size(655, 313)
        Me.CtlRTFUpload.TabIndex = 203
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.CtlRTFWeb)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(655, 313)
        '
        'CtlRTFWeb
        '
        Me.CtlRTFWeb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFWeb.EditEnabled = True
        Me.CtlRTFWeb.HTMLText = ""
        Me.CtlRTFWeb.LayoutType = "Continuous"
        Me.CtlRTFWeb.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFWeb.Name = "CtlRTFWeb"
        Me.CtlRTFWeb.PlainText = ""
        Me.CtlRTFWeb.RTFText = ""
        Me.CtlRTFWeb.Size = New System.Drawing.Size(655, 313)
        Me.CtlRTFWeb.TabIndex = 203
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.btnContPrev)
        Me.UltraTabPageControl4.Controls.Add(Me.btnStartNew)
        Me.UltraTabPageControl4.Controls.Add(Me.btnStart)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(655, 313)
        '
        'btnContPrev
        '
        Me.btnContPrev.Location = New System.Drawing.Point(179, 55)
        Me.btnContPrev.Name = "btnContPrev"
        Me.btnContPrev.Size = New System.Drawing.Size(99, 44)
        Me.btnContPrev.TabIndex = 6
        Me.btnContPrev.Tag = "Add"
        Me.btnContPrev.Text = "Continue Previous"
        '
        'btnStartNew
        '
        Me.btnStartNew.Location = New System.Drawing.Point(179, 105)
        Me.btnStartNew.Name = "btnStartNew"
        Me.btnStartNew.Size = New System.Drawing.Size(99, 44)
        Me.btnStartNew.TabIndex = 5
        Me.btnStartNew.Tag = "Add"
        Me.btnStartNew.Text = "Start New"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(179, 155)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(99, 44)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Start"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl3)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(659, 348)
        Me.UltraTabControl1.TabIndex = 55
        UltraTab5.Key = "html"
        UltraTab5.TabPage = Me.UltraTabPageControl1
        UltraTab5.Text = "HTML"
        UltraTab1.Key = "upload"
        UltraTab1.TabPage = Me.UltraTabPageControl2
        UltraTab1.Text = "Upload"
        UltraTab2.Key = "web"
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "Web"
        UltraTab3.Key = "Assess"
        UltraTab3.TabPage = Me.UltraTabPageControl4
        UltraTab3.Text = "Assessment"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5, UltraTab1, UltraTab2, UltraTab3})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(655, 322)
        '
        'UltraPanel4
        '
        '
        'UltraPanel4.ClientArea
        '
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btnPrevious)
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btnNext)
        Me.UltraPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel4.Location = New System.Drawing.Point(0, 348)
        Me.UltraPanel4.Name = "UltraPanel4"
        Me.UltraPanel4.Size = New System.Drawing.Size(659, 44)
        Me.UltraPanel4.TabIndex = 335
        '
        'btnPrevious
        '
        Me.btnPrevious.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPrevious.Location = New System.Drawing.Point(461, 0)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(99, 44)
        Me.btnPrevious.TabIndex = 2
        Me.btnPrevious.Tag = "Add"
        Me.btnPrevious.Text = "<< Previous"
        '
        'btnNext
        '
        Me.btnNext.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNext.Location = New System.Drawing.Point(560, 0)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(99, 44)
        Me.btnNext.TabIndex = 0
        Me.btnNext.Text = "Next >>"
        '
        'frmContentUnitView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "ContentUnit View"
        Me.ClientSize = New System.Drawing.Size(659, 392)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraPanel4)
        Me.Name = "frmContentUnitView"
        Me.Text = "ContentUnit View"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraPanel4.ClientArea.ResumeLayout(False)
        Me.UltraPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CtlRTFHTML As ctlRTF
    Friend WithEvents CtlRTFWeb As ctlRTF
    Friend WithEvents CtlRTFUpload As ctlRTF
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents btnContPrev As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnStartNew As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnStart As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel4 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnPrevious As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnNext As Infragistics.Win.Misc.UltraButton
End Class
