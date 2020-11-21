Imports risersoft.app.mxform.talent
Imports System.Configuration
Imports System.Windows.Forms

Public Class frmContentUnitLink
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim fBrowse As IMxBrowser, ContentUrl As String
    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        fBrowse = myWinApp.objAppExtender.fBrowser
        Dim f = CType(fBrowse, frmMax)
        f.AddtoTab(Me.UltraTabControl1, "url", False)
        AddHandler fBrowse.OnAddressChanged, Sub(s, address)
                                                 If Me.FormPrepared = True Then
                                                     ContentUrl = address
                                                 End If
                                             End Sub
    End Sub

    Private Sub frmContentUnitLink_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim f = CType(fBrowse, frmMax)
        If f IsNot Nothing Then f.Size = Me.UltraTabControl1.Tabs(0).TabPage.Size
    End Sub

    Private Sub frmContentUnitLink_Load(sender As Object, e As EventArgs) Handles Me.Load
        If myUtils.cStrTN(myRow("contenturl")).Trim.Length > 0 Then fBrowse.LoadUrl(myUtils.cStrTN(myRow("contenturl")))
    End Sub

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmContentUnitLinkModel = Me.InitData("frmContentUnitLinkModel", oView, prepMode, prepIDX, strXML)
        If Me.BindModel(objModel, oView) Then
            Dim dt As DataTable = Me.Model.DatasetCollection("Course").Tables("Course")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                txt_CourseCode.Text = myUtils.cStrTN(dt.Rows(0)("CourseCode"))
                txt_CourseName.Text = myUtils.cStrTN(dt.Rows(0)("CourseName"))
                txt_Level.Text = myUtils.cStrTN(dt.Rows(0)("Level"))
                txt_TimeLimit.Text = myUtils.cStrTN(dt.Rows(0)("TimeLimit"))
            End If


            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            myRow("contenturl") = Me.ContentUrl
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function


End Class