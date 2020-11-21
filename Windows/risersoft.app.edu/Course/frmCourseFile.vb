Imports System.Configuration
Imports risersoft.app.mxform.talent

Public Class frmCourseFile
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim ServerPath As String = "", LocalPath As String = ""

    Private Sub InitForm()
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)
        Me.GetExtensionName()
    End Sub

    Public Function GetExtensionName()
        Dim FileExtCode = System.IO.Path.GetExtension(myUtils.cStrTN(Me.SaveFileDialog1.FileName))
        Dim FileExt = myWinFtp.FileExtText(FileExtCode)

        'myRow("FileType") = Me.Controller.FTP.FileExtText(FileExt)

        Dim strFilter As String = FileExt & " (*" & FileExtCode & ")|*" & FileExtCode
        Me.SaveFileDialog1.Filter = strFilter

    End Function

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False

        Dim objModel As frmCourseFileModel = Me.InitData("frmCourseFileModel", oView, prepMode, prepIdx, strXML)
        If Me.BindModel(objModel, oView) Then
            InitUpLoad()

            Me.FormPrepared = True

        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function BindModel(NewModel As clsFormDataModel, oView As clsView) As Boolean
        If MyBase.BindModel(NewModel, oView) Then
            myWinSQL.AssignCmb(Me.dsCombo, "Course", "", Me.cmb_CourseID)
            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False
        If Me.ValidateData() Then
            cm.EndCurrentEdit()
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()

    End Function

    Private Function InitUpLoad()
        Dim str1 As String = ""
        str1 = "XLS File|*.xls|XLSX File|*.xlsx|Word Document(.doc)|*.doc|Word XML Document (.docx)|*.docx|Rich Text File (*.rtf)|*.rtf|Portable Document File(.pdf)|*.pdf"

        Me.CtlUpLoad2.InitFilter(EnumfrmMode.acEditM, "", Me.Controller.App.objAppExtender.FileServerPath, "", str1, ConfigurationManager.AppSettings("StorageContainerName"))
        AddHandler Me.CtlUpLoad2.FileSelected, Sub(SelectedFile As String)
                                                   LocalPath = SelectedFile
                                                   Dim UniqueFileId = System.Guid.NewGuid.ToString
                                                   Me.CtlUpLoad2.FileName = System.IO.Path.GetFileNameWithoutExtension(SelectedFile) & "-" & UniqueFileId & System.IO.Path.GetExtension(SelectedFile)
                                               End Sub
        AddHandler Me.CtlUpLoad2.FileUploaded, Sub(ByVal localFile As String, ServerPath As String)
                                                   Me.ServerPath = ServerPath
                                                   myRow("FileURL") = ServerPath
                                                   myRow("FileName") = Me.CtlUpLoad2.FileName
                                                   'myRow("FileURL") = LocalPath
                                                   'Dim oRet = GetParams("process", "")
                                                   'MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                                               End Sub
        Return True
    End Function

End Class