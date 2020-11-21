Imports risersoft.shared.web
Imports System.Threading.Tasks

Namespace Controllers

    Public Class StartController
        Inherits clsMvcControllerBase

        <Authorize> <HostActionFilter>
        Public Overridable Async Function Test() As Task(Of ActionResult)
            If Await Me.myMvcController.CheckInitModel(Me.myMvcController.GetAppInfo, True) Then
                Dim sql = "select assessuserid From assessuser where assesstestid is not null and completedon is null and userid='" & myMvcController.Police.UniqueUserID.ToString & "'"
                Dim dt1 As DataTable = myMvcController.DataProvider.objSQLHelper.ExecuteDataset(CommandType.Text, sql).Tables(0)
                If dt1.Rows.Count > 0 Then
                    Return Me.Redirect2("/frmAssessTestView/Edit/" & dt1.Rows(0)("assessuserid"))
                Else
                    Return Me.HttpNotFound
                End If
            End If
        End Function
    End Class

End Namespace