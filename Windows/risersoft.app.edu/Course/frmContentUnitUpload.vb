Imports risersoft.app.mxform.talent
Imports System.Configuration

Public Class frmContentUnitUpload
    Inherits frmMax
    Friend fMat As frmCourseContent
    Dim ServerPath As String = "", LocalPath As String = ""

    Dim f As New frmApiTaskStatus

    Private Sub InitForm()
        f.AddtoTab(Me.UltraTabControl1, "status", True)
        f.SetParent(Me)
        AddHandler f.TaskExecuted, Sub(s, ApiTaskId)
                                   End Sub
        AddHandler f.LinkClicked, Sub(s, filePath)
                                      Me.SaveFileDialog1.FileName = System.IO.Path.GetFileName(filePath)
                                      Me.GetExtensionName()
                                      If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
                                          Dim client = Me.Controller.App.objAppExtender.FileProviderClient(Me.Controller, ConfigurationManager.AppSettings("StorageContainerName"))
                                          client.DownloadFile(filePath, Me.SaveFileDialog1.FileName)
                                      End If
                                  End Sub
        WinFormUtils.SetButtonConf(Me.btnOk, Me.btnCancel, Me.btnSave)

    End Sub

    Public Function GetExtensionName()
        Dim FileExtCode = System.IO.Path.GetExtension(myUtils.cStrTN(Me.SaveFileDialog1.FileName))
        Dim FileExt = myWinFtp.FileExtText(FileExtCode)
        Dim strFilter As String = FileExt & " (*" & FileExtCode & ")|*" & FileExtCode
        Me.SaveFileDialog1.Filter = strFilter
    End Function

    Public Overrides Function PrepForm(oView As clsWinView, ByVal prepMode As EnumfrmMode, ByVal prepIdx As String, Optional ByVal strXML As String = "") As Boolean
        Me.FormPrepared = False
        Dim objModel As frmContentUnitUploadModel = Me.InitData("frmContentUnitUploadModel", oview, prepMode, prepIdx, strXML)

        If Me.BindModel(objModel, oview) Then
            InitUpLoad(myUtils.cStrTN(myRow("DocType")))
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
            myWinSQL.AssignCmb(Me.dsCombo, "DocType", "", Me.cmb_DocType)

            Return True
        End If
        Return False
    End Function

    Public Overrides Function VSave() As Boolean
        Me.InitError()
        VSave = False
        cm.EndCurrentEdit()
        If Me.ValidateData() Then
            If Me.SaveModel() Then
                Return True
            End If
        Else
            Me.SetError()
        End If
        Me.Refresh()
    End Function

    Private Function InitUpLoad(DocType As String)
        Dim str1 As String = ""
        Select Case DocType.Trim.ToLower
            Case "document"
                str1 = "Word Document(.doc)|*.doc|Word XML Document (.docx)|*.docx|Rich Text File (*.rtf)|*.rtf"
            Case "video"
                str1 = "Moving Pictures Group|*.mpg|Moving Picture Experts Group|*.mpeg|Advanced Video Coding|*.mp4"
            Case "audio"
                str1 = "Media Player Version 3|*.mp3|Windows Media Audio/Video File|*.wmv|Waveform Audio File|*.wav"
            Case "pdf"
                str1 = "Portable Document File(.pdf)|*.pdf"
            Case "presentation"
                str1 = "PowerPoint Presentation|*.ppt|PowerPoint XML Presentation|*.pptx"
            Case "excel"
                str1 = "XLS File|*.xls|XLSX File|*.xlsx"
        End Select

        Me.CtlUpLoad1.InitFilter(EnumfrmMode.acEditM, "", Me.Controller.App.objAppExtender.FileServerPath, "", str1, ConfigurationManager.AppSettings("StorageContainerName"))
        AddHandler Me.CtlUpLoad1.FileSelected, Sub(SelectedFile As String)
                                                   LocalPath = SelectedFile
                                                   Dim UniqueFileId = System.Guid.NewGuid.ToString
                                                   Me.CtlUpLoad1.FileName = System.IO.Path.GetFileNameWithoutExtension(SelectedFile) & "-" & UniqueFileId & System.IO.Path.GetExtension(SelectedFile)
                                               End Sub
        AddHandler Me.CtlUpLoad1.FileUploaded, Sub(ByVal localFile As String, ServerPath As String)
                                                   Me.ServerPath = ServerPath
                                                   myRow("ContentFilePath") = ServerPath
                                                   Dim oRet = GetParams("process", "")
                                                   MsgBox(oRet.Message, MsgBoxStyle.Information, myWinApp.Vars("appname"))
                                               End Sub
        Return True
    End Function

    Private Function GetParams(Key As String, UploadType As String) As clsProcOutput
        Dim info As New IO.FileInfo(LocalPath)
        'Case to be added for ActionType -> Convert, Search


        Dim serverPath2 = Uri.EscapeUriString(System.IO.Path.GetFileName(ServerPath))
        'ActionType = "Import"
        Dim Params As New List(Of clsSQLParam)

        Params.Add(New clsSQLParam("@serverPath", myUtils.cStrTN(serverPath2), GetType(Uri), False))
        Params.Add(New clsSQLParam("@DocType", "'" & myUtils.cStrTN(Me.cmb_DocType.Value) & "'", GetType(String), False))
        Params.Add(New clsSQLParam("@Length", "'" & myUtils.cStrTN(info.Length) & "'", GetType(String), False))

        Dim oRet = Me.GenerateParamsOutput(Key, Params)
        If oRet.Success Then
            Dim rTask = oRet.GetCalcRows("task")(0)
            Dim result As Guid
            If System.Guid.TryParse(oRet.Description, result) Then
                myRow("ContentPDFPath") = rTask("filename")
                f.AddTask(result.ToString)
            End If
        End If
        Return oRet

    End Function


End Class
