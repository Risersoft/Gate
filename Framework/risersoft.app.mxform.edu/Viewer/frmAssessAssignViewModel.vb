Imports risersoft.shared
Imports risersoft.app.mxent
Imports Infragistics.Win
Imports System.Runtime.Serialization
Imports risersoft.shared.cloud
Imports risersoft.app.mxengg
Imports System.IO

<DataContract>
Public Class frmAssessAssignViewModel
    Inherits clsFormDataModel

    Protected Overrides Sub InitViews()
    End Sub

    Public Sub New(context As IProviderContext)
        MyBase.New(context)
        Me.InitViews()
        Me.InitForm()
    End Sub

    Private Sub InitForm()
    End Sub

    Public Overrides Function PrepForm(oView As clsViewModel, ByVal prepMode As EnumfrmMode, ByVal prepIDX As String, Optional ByVal strXML As String = "") As Boolean
        Dim sql As String, dic As New clsCollecString(Of String)

        Me.FormPrepared = False
        If prepMode = EnumfrmMode.acEditM Then
            sql = "Select * from nlmslistAssessUser() where AssessUserID = " & prepIDX
            Me.InitData(sql, "AssessAssignmentID,CourseID", oView, prepMode, prepIDX, strXML)

            dic.Add("Assignment", "Select * from AssessAssignment where AssessAssignmentID = " & myUtils.cValTN(myRow("AssessAssignmentID")) & "")
            'dic.Add("Visitor", "Select top 1 userid, rolecode from nlmslistAssessUser() where AssessAssignmentID = " & myUtils.cValTN(myRow("AssessAssignmentID")) & " and userid='" & myContext.Police.UniqueUserID.ToString & "' order by assessnum desc")

            If myUtils.cValTN(myRow("courseid")) > 0 Then
                dic.Add("Visitor", "Select top 1 userid, rolecode from nlmslistCourseUser() where CourseID = " & myUtils.cValTN(myRow("CourseID")) & " and userid='" & myContext.Police.UniqueUserID.ToString & "' ")
            Else
                dic.Add("Visitor", "Select top 1 userid, rolecode from nlmslistAssessUser() where AssessAssignmentID = " & myUtils.cValTN(myRow("AssessAssignmentID")) & " and userid='" & myContext.Police.UniqueUserID.ToString & "' order by assessnum desc")
            End If

            Me.AddDataSet("Assign", dic)

            If myUtils.NullNot(myRow("startedon")) AndAlso (Not String.IsNullOrEmpty(myUtils.cStrTN(myRow("buttontype")))) Then
                Dim curDateTime As DateTime = TaskProviderFactory.FindLocalTime
                If curDateTime >= myUtils.cDateTN(myRow("EnableOn"), "1-Jan-1000") AndAlso curDateTime <= myUtils.cDateTN(myRow("DisableOn"), "1-Jan-3000") Then
                    myRow("StartedOn") = TaskProviderFactory.FindLocalTime
                    myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "select assessuserid,startedon from assessuser where 0=1")
                End If
            End If

            If myContext.Police.IsAdmin(False) Then
                Me.FormPrepared = True
            Else
                Dim dtVisitor = Me.DatasetCollection("assign").Tables("visitor")
                If dtVisitor.Rows.Count > 0 Then
                    If myRow("userid") = dtVisitor.Rows(0)("userid") Then
                        Me.FormPrepared = True
                    ElseIf myUtils.IsInList(dtVisitor.Rows(0)("rolecode"), "INS") Then
                        Me.FormPrepared = True
                    Else
                        Me.AddError("", "User not authorized to access this assessment")
                    End If
                Else
                    Me.AddError("", "User not assigned to this assessment")
                End If
            End If
        Else
            Me.AddError("", "Form cannot be opened in add mode")
        End If
        Return Me.FormPrepared
    End Function

    Public Overrides Function Validate() As Boolean
        Me.InitError()
        If Me.myRow("AssignmentName").Trim.Length = 0 Then Me.AddError("AssignmentName", "Enter Assignment Name")

        Return Me.CanSave
    End Function

    Public Overrides Function VSave() As Boolean
        VSave = False

        myRow("AssignmentHTML") = myFuncs.DecodeNormalizeHTML(myUtils.cStrTN(myRow("AssignmentHTML")))
        myRow("AssignmentText") = BucketUtility.TryBase64Decode(myUtils.cStrTN(myRow("AssignmentText")))

        If Me.Validate Then
            Dim strf = myContext.SQL.GenerateSQLWhere(myRow.Row, "assessuserid"), dic As New clsCollecString(Of String)
            dic.Add("au", $"Select notifymsg,buttontype from nlmslistassessuser() where " & strf)
            Dim ds2 = myContext.Provider.objSQLHelper.ExecuteDataset(CommandType.Text, dic)
            Dim rAU = ds2.Tables("au").Rows(0)

            Dim AssignmentDescrip As String = "Name: " & myRow("AssignmentName").ToString
            Try
                Dim dtVisitor = Me.DatasetCollection("assign").Tables("visitor")
                If dtVisitor.Rows.Count > 0 Then
                    Dim dt = Me.DatasetCollection("assign").Tables("assignment")
                    If myRow("userid") = dtVisitor.Rows(0)("userid") Then
                        'learner
                        If myUtils.IsInList(myUtils.cStrTN(rAU("buttontype")), "start", "continue") Then
                            myRow("submitcount") = myUtils.cValTN(myRow("submitcount")) + 1
                            myRow("lastsubmiton") = TaskProviderFactory.FindLocalTime
                            If myUtils.cBoolTN(dt.Rows(0)("completionsubmit")) Then
                                myRow(“completedon”) = TaskProviderFactory.FindLocalTime
                            End If
                            myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "AssessUserID", frmIDX)
                            myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select assessuserid, assignmenthtml, assignmenttext, assignattachjson, CompletedOn, lastsubmiton, submitcount from AssessUser where AssessUserID = " & frmIDX)
                            myContext.Provider.dbConn.CommitTransaction(AssignmentDescrip, frmIDX)
                            Me.PrepForm(Me.pView, Me.frmMode, Me.frmIDX, myContext.Data.VarBagXML(Me.vBag))
                        Else
                            'Test has expired
                            Me.AddError("", myUtils.cStrTN(rAU("notifymsg")))
                        End If
                    ElseIf myUtils.IsInList(dtVisitor.Rows(0)("rolecode"), "INS") Then
                        If Not myUtils.cBoolTN(dt.Rows(0)("completionsubmit")) Then
                            myRow(“completedon”) = TaskProviderFactory.FindLocalTime
                        End If
                        myContext.Provider.dbConn.BeginTransaction(myContext, Me.Name, Me.frmMode.ToString, "AssessUserID", frmIDX)
                        myContext.Provider.objSQLHelper.SaveResults(myRow.Row.Table, "Select assessuserid, CompletedOn, TotalScore, Remark from AssessUser where AssessUserID = " & frmIDX)
                        myContext.Provider.dbConn.CommitTransaction(AssignmentDescrip, frmIDX)


                    Else
                        Me.AddError("", "User not authorized to access this assessment")
                    End If
                Else
                    Me.AddError("", "User not assigned to this assessment")
                End If

                VSave = True
            Catch ex As Exception
                myContext.Provider.dbConn.RollBackTransaction(AssignmentDescrip, ex.Message)
                Me.AddError("", ex.Message)
            End Try
        End If

        Return VSave
    End Function

    Public Overrides Function GenerateParamsOutput(dataKey As String, Params As List(Of clsSQLParam)) As clsProcOutput
        Dim oRet As New clsProcOutput
        oRet = myEduFuncs.GenerateCommonOutput(myContext, dataKey, Params, "courseid")
        Return oRet
    End Function


End Class

