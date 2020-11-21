<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestQuestionView
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
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.UltraGridAnswers = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraPanel4 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnMoveUp = New Infragistics.Win.Misc.UltraButton()
        Me.btnMoveDown = New Infragistics.Win.Misc.UltraButton()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFText = New risersoft.[shared].win.ctlRTF()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.CtlRTFQuestion = New risersoft.[shared].win.ctlRTF()
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.cmb_QuestionType = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraTabControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.UltraGridAnswers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraPanel4.ClientArea.SuspendLayout()
        Me.UltraPanel4.SuspendLayout()
        Me.UltraTabPageControl5.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.cmb_QuestionType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.UltraGridAnswers)
        Me.UltraTabPageControl6.Controls.Add(Me.UltraPanel4)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(580, 324)
        '
        'UltraGridAnswers
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGridAnswers.DisplayLayout.Appearance = Appearance1
        Me.UltraGridAnswers.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGridAnswers.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridAnswers.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridAnswers.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.UltraGridAnswers.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGridAnswers.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.UltraGridAnswers.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGridAnswers.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGridAnswers.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGridAnswers.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.UltraGridAnswers.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGridAnswers.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGridAnswers.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGridAnswers.DisplayLayout.Override.CellAppearance = Appearance8
        Me.UltraGridAnswers.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGridAnswers.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGridAnswers.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.UltraGridAnswers.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.UltraGridAnswers.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UltraGridAnswers.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.UltraGridAnswers.DisplayLayout.Override.RowAppearance = Appearance11
        Me.UltraGridAnswers.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGridAnswers.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.UltraGridAnswers.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGridAnswers.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGridAnswers.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.UltraGridAnswers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGridAnswers.Location = New System.Drawing.Point(0, 0)
        Me.UltraGridAnswers.Name = "UltraGridAnswers"
        Me.UltraGridAnswers.Size = New System.Drawing.Size(580, 291)
        Me.UltraGridAnswers.TabIndex = 20
        Me.UltraGridAnswers.Text = "UltraGrid1"
        '
        'UltraPanel4
        '
        '
        'UltraPanel4.ClientArea
        '
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btnMoveUp)
        Me.UltraPanel4.ClientArea.Controls.Add(Me.btnMoveDown)
        Me.UltraPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraPanel4.Location = New System.Drawing.Point(0, 291)
        Me.UltraPanel4.Name = "UltraPanel4"
        Me.UltraPanel4.Size = New System.Drawing.Size(580, 33)
        Me.UltraPanel4.TabIndex = 21
        '
        'btnMoveUp
        '
        Me.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMoveUp.Location = New System.Drawing.Point(426, 0)
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Size = New System.Drawing.Size(77, 33)
        Me.btnMoveUp.TabIndex = 6
        Me.btnMoveUp.Tag = "Add"
        Me.btnMoveUp.Text = "Move Up"
        '
        'btnMoveDown
        '
        Me.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMoveDown.Location = New System.Drawing.Point(503, 0)
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Size = New System.Drawing.Size(77, 33)
        Me.btnMoveDown.TabIndex = 5
        Me.btnMoveDown.Tag = "Add"
        Me.btnMoveDown.Text = "Move Down"
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.CtlRTFText)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(580, 324)
        '
        'CtlRTFText
        '
        Me.CtlRTFText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFText.EditEnabled = True
        Me.CtlRTFText.HTMLText = ""
        Me.CtlRTFText.LayoutType = "Continuous"
        Me.CtlRTFText.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFText.Name = "CtlRTFText"
        Me.CtlRTFText.PlainText = ""
        Me.CtlRTFText.RTFText = ""
        Me.CtlRTFText.Size = New System.Drawing.Size(580, 324)
        Me.CtlRTFText.TabIndex = 204
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.CtlRTFQuestion)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(580, 151)
        '
        'CtlRTFQuestion
        '
        Me.CtlRTFQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRTFQuestion.EditEnabled = True
        Me.CtlRTFQuestion.HTMLText = ""
        Me.CtlRTFQuestion.LayoutType = "Continuous"
        Me.CtlRTFQuestion.Location = New System.Drawing.Point(0, 0)
        Me.CtlRTFQuestion.Name = "CtlRTFQuestion"
        Me.CtlRTFQuestion.PlainText = ""
        Me.CtlRTFQuestion.RTFText = ""
        Me.CtlRTFQuestion.Size = New System.Drawing.Size(580, 151)
        Me.CtlRTFQuestion.TabIndex = 206
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.UltraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 212)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(584, 350)
        Me.UltraTabControl1.TabIndex = 59
        UltraTab6.Key = "ans"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "Answers"
        UltraTab4.Key = "free"
        UltraTab4.TabPage = Me.UltraTabPageControl5
        UltraTab4.Text = "Free Text"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab4})
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(580, 324)
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.cmb_QuestionType)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.UltraLabel12)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(584, 35)
        Me.UltraPanel1.TabIndex = 343
        '
        'cmb_QuestionType
        '
        Appearance13.FontData.BoldAsString = "False"
        Me.cmb_QuestionType.Appearance = Appearance13
        Me.cmb_QuestionType.Location = New System.Drawing.Point(107, 6)
        Me.cmb_QuestionType.Name = "cmb_QuestionType"
        Me.cmb_QuestionType.ReadOnly = True
        Me.cmb_QuestionType.Size = New System.Drawing.Size(203, 22)
        Me.cmb_QuestionType.TabIndex = 322
        Me.cmb_QuestionType.Text = "UltraCombo5"
        '
        'UltraLabel12
        '
        Appearance14.FontData.SizeInPoints = 8.25!
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance14
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel12.Location = New System.Drawing.Point(16, 10)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(87, 14)
        Me.UltraLabel12.TabIndex = 321
        Me.UltraLabel12.Text = "Question Type :"
        '
        'UltraTabControl2
        '
        Me.UltraTabControl2.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControl2.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraTabControl2.Location = New System.Drawing.Point(0, 35)
        Me.UltraTabControl2.Name = "UltraTabControl2"
        Me.UltraTabControl2.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControl2.Size = New System.Drawing.Size(584, 177)
        Me.UltraTabControl2.TabIndex = 344
        UltraTab2.TabPage = Me.UltraTabPageControl4
        UltraTab2.Text = "Description"
        Me.UltraTabControl2.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(580, 151)
        '
        'frmTestQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Caption = "TestQuestion View"
        Me.ClientSize = New System.Drawing.Size(584, 562)
        Me.Controls.Add(Me.UltraTabControl1)
        Me.Controls.Add(Me.UltraTabControl2)
        Me.Controls.Add(Me.UltraPanel1)
        Me.Name = "frmTestQuestionView"
        Me.Text = "TestQuestion View"
        CType(Me.eBag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.UltraGridAnswers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraPanel4.ClientArea.ResumeLayout(False)
        Me.UltraPanel4.ResumeLayout(False)
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.PerformLayout()
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.cmb_QuestionType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CtlRTFText As ctlRTF
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraGridAnswers As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraPanel4 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnMoveUp As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnMoveDown As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents cmb_QuestionType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabControl2 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents CtlRTFQuestion As ctlRTF
End Class
