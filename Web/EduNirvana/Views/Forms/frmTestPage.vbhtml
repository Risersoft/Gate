@imports AuthorizationFramework.Proxies
@imports risersoft.shared.portable
@imports risersoft.app.mxform
@imports risersoft.app.mxform.talent
@imports risersoft.shared.portable.Proxies
@imports risersoft.shared.web.Extensions
@imports Newtonsoft.Json
@imports Controllers.Controllers
@imports risersoft.shared
@imports risersoft.shared.web
@imports risersoft.shared.web.Extensions
@imports System.Diagnostics
@imports Syncfusion.EJ2

@ModelType frmTestPageModel

@Code
    ViewData("Title") = "Test Question View"
    Layout = "~/Views/Shared/_FrameworkLayout.vbhtml"
    Dim modeljson = Model.SerializeJson
End Code

<script type="text/javascript">
    var defaultRTEFN;
    function createdfn() {
        defaultRTEFN = this
    };
</script>
<style type="text/css">
    .tblPiar {
        margin-top: -122px;
        margin-left: 535px;
    }

    .style23199588 {
        font-size: 16px !important;
    }

    .ddlClass {
        width: 20%;
        padding: .375rem .75rem;
        background-clip: padding-box;
        border: 1px solid #ced4da;
        border-radius: .25rem;
    }

    p span {
        font-size: 15px !important;
        font-weight: normal !important;
        color: #212529 !important;
        font-family: 'Droid Sans', sans-serif !important;
    }
</style>


<div Class="container cbackground">
    <form action="" method="post" name="userform" id="userform" ng-controller="FormController">
        <input type="hidden" id="model_json" value='@Html.Raw(modelJson)' />
        <input type="hidden" id="saveQuestionStatus" />
        @Html.AntiForgeryToken()

        <!-- Start Page Heading Section -->
        <div class="row">
            <div class="col-md-10">
                <label class="control-label"></label>
                <h5 style="color:#1c66a7">View Test Course - {{assessName}}</h5>
            </div>
            <div class="col-md-1"></div>
        </div>
        <hr />
        <!-- End Page Heading Section -->
        <!-- Start Page Content -->
        <div class="form-row">
            <div class="form-group col-md-12">
                <label for="inputEmail4"><b>Question: </b></label>
                <p ng-bind-html="testQuestion | unsafe"></p>
                <p ng-bind-html="myHTML | unsafe"></p>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-12">
                <table id="tblAnswers_mcq" class="table table-sm table-bordered" style="width: 100%;" ng-show="contentType == 'mcq'">
                    <tbody>
                        <tr ng-repeat="ans in testQuestionAnswer">
                            <td style="width: 5%;"><input type="checkbox" ng-model="ans.sysincl" /></td>
                            <td ng-bind-html="ans.AnswerText1"></td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblAnswers_odr" class="table table-sm table-bordered" style="width: 100%;" ng-show="contentType == 'odr'">
                    <tbody>
                        <tr ng-repeat="ans in testQuestionAnswer">
                            <td>{{ans.AnswerText1}}</td>
                            <td>
                                <a href="javascript:void(0)" ng-click="moveUp($index, testQuestionAnswer)" ng-show="!$first"><i class="fa fa-arrow-up"></i></a>
                                <a href="javascript:void(0)" ng-click="moveDown($index, testQuestionAnswer)" ng-show="!$last"><i class="fa fa-arrow-down"></i></a>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblAnswers_pair" class="table table-sm table-bordered" style="width: 50%; border:1px solid #cc0000;" ng-show="contentType == 'pair'">
                    <tbody>
                        <tr ng-repeat="ans in testQuestionAnswer">
                            <td>{{ans.AnswerText1}}</td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblAnswers_pair_1" class="table table-sm table-bordered" style="width: 50%;" ng-show="contentType == 'pair'" ng-class="{'tblPiar' : contentType == 'pair'}">
                    <tbody>
                        <tr ng-repeat="ans in ansArray" style="margin-top:-25px;">
                            <td style="width: 475px;">{{ans.AnswerText2}}</td>
                            <td>
                                <a href="javascript:void(0)" ng-click="moveUp($index, ansArray)" ng-show="!$first"><i class="fa fa-arrow-up"></i></a>
                                <a href="javascript:void(0)" ng-click="moveDown($index, ansArray)" ng-show="!$last"><i class="fa fa-arrow-down"></i></a>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table id="tblTestQAns_txt" class="table table-sm table-bordered" style="width: 100%;" ng-show="contentType == 'txt'">
                    <tbody>
                        <tr>
                            <td>
                                <div class="control-section">
                                    <div class="control-wrapper">
                                        <div class="control-section">
                                            @Html.EJS().RichTextEditor("defaultfn").Value("").Created("createdfn").Render()
                                        </div>
                                    </div>
                                </div>
                                @Html.EJS().ScriptManager()
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        @*testQuestionAnswer*@
        <div class="form-row">
            <div class="form-group col-md-12">
                <a href="javascript:void(0)" ng-class="{ disabled: isNextDisable}" class="btn btn-default btnf" ng-click="btnNextSave()"> Next <i class="fa fa-angle-double-right"></i></a>
            </div>
        </div>
        <!-- End Page Content-->
    </form>
</div>

@section botscripts
    <script type="text/javascript">
        rsApp.filter('unsafe', function ($sce) {
            return function (val) {
                return $sce.trustAsHtml(val);
            };
        });

        rsApp.controller('FormController', function ($scope, usSpinnerService, $sce) {
            $scope.model = JSON.parse($("#model_json").val());
            $scope.status = 'loaded';
            var arrSelVal = [];
            var arrSelText = [];
            var loadmodel = function (result) {
                $scope.model = result;
                //set values in scope
                $scope.QuestionInfo = $scope.model.dsForm.DT[0];
                //Set Course Details
                //$scope.CourseDetails = $scope.model.pViewState.ContextRow.valuebag;
                //Set Page Heading
                $scope.title = ($scope.model.frmMode == 2 ? "Add" : $scope.model.frmMode == 1 ? "Edit" : "");
                //Show Hide Delete Buttons
                $scope.visdel = ($scope.model.frmMode == 2 ? false : true);
                //Set Question HTML
                $scope.testQuestion = $scope.QuestionInfo.QuestionHTML;
                //Set Answers List
                //if ($scope.model.frmMode == 2) {
                //$scope.model.GridViews.Answers.MainGrid.myDS.dt = $scope.testQuestionAnswer;
                $scope.testQuestionAnswer = $scope.model.GridViews.Answers.MainGrid.myDS.dt || $scope.model.GridViews.Answers.MainGrid.myDS.List;
                //}
                //Set Content Type
                $scope.contentType = $scope.QuestionInfo.QuestionType.toLocaleLowerCase();
                //Set Title AssessName and Course Name

                if ($scope.model.DatasetCollection.tu.au.length > 0) {
                    if ($scope.model.DatasetCollection.tu.au[0].CourseName != undefined && $scope.model.DatasetCollection.tu.au[0].CourseName != "")
                        $scope.assessName = $scope.model.DatasetCollection.tu.au[0].AssessName + " (" + $scope.model.DatasetCollection.tu.au[0].CourseName + ")";
                    else
                        $scope.assessName = $scope.model.DatasetCollection.tu.au[0].AssessName;
                }

                if ($scope.contentType == 'pair') {
                    $scope.ansArray = [];
                    for (var i = 0; i < $scope.testQuestionAnswer.length; i++) {
                        $scope.ansArray.push({ AnswerText2: $scope.testQuestionAnswer[i].AnswerText2, TestAnswerID: $scope.testQuestionAnswer[i].TestAnswerID, TestQuestionID: $scope.testQuestionAnswer[i].TestQuestionID })
                    }
                }

                if ($scope.contentType == "ftg") {
                    for (var i = 0; i < $scope.testQuestionAnswer.length; i++) {
                        var ddlOptionalList = $scope.model.GridViews.Answers.MainGrid.myDS.List[i].List.split('|');
                        var ddl = '<select id="testQuestionAnswer_' + i + '" class="ddlClass"><option> Select </option>';
                        for (var x = 0; x < ddlOptionalList.length; x++) {
                            ddl += '<option value=' + x + '>' + ddlOptionalList[x] + '</option>';
                        }
                        ddl += '</select>';

                        var repVal = "[" + parseInt(i + 1) + "]";
                        $scope.testQuestion = $scope.testQuestion.toString().replace(repVal, ddl);
                    }
                }
            }

            loadmodel($scope.model);

            //CleanUp Model
            $scope.cleanupmodel = function (datamodel) {
                datamodel.dsForm.DT[0].QuestionHTML = '';
                datamodel.dsForm.DT[0].QuestionText = '';
                //datamodel.GridViews.Answers.MainGrid.myDS.dt = '';
            };

            //Calculate Model
            $scope.calculatemodel = function () {
                if ($scope.contentType == "mcq") {
                    var ans_val = []; var ans_txt = [];
                    for (var i = 0; i < $scope.testQuestionAnswer.length; i++) {
                        if ($scope.testQuestionAnswer[i].sysincl == true) {
                            ans_val.push($scope.testQuestionAnswer[i].TestAnswerID);
                            ans_txt.push($scope.testQuestionAnswer[i].AnswerText1);
                        }
                    }

                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerIDCSV = ans_val.join();
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerText = ans_txt.join();
                    $scope.model.DatasetCollection.tu.qu[0].CourseID = $scope.model.DatasetCollection.tu.au[0].courseid;
                }
                if ($scope.contentType == "txt") {
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerHTML = base64EncodeUnicode(defaultRTEFN.getHtml());
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerText = base64EncodeUnicode(defaultRTEFN.getText());
                    $scope.model.DatasetCollection.tu.qu[0].CourseID = $scope.model.DatasetCollection.tu.au[0].courseid;
                }
                if ($scope.contentType == "odr") {
                    var ans_val = []; var ans_txt = [];
                    for (var i = 0; i < $scope.testQuestionAnswer.length; i++) {
                        $scope.testQuestionAnswer[i].sortindex = i + 1;
                        ans_val.push($scope.testQuestionAnswer[i].TestAnswerID);
                        ans_txt.push($scope.testQuestionAnswer[i].AnswerText1);
                    }

                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerIDCSV = ans_val.join();
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerText = ans_txt.join();
                    $scope.model.DatasetCollection.tu.qu[0].CourseID = $scope.model.DatasetCollection.tu.au[0].courseid;
                }
                if ($scope.contentType == "pair") {
                    var ans_val = []; var ans_txt = [];
                    for (var i = 0; i < $scope.ansArray.length; i++) {
                        ans_val.push($scope.ansArray[i].TestAnswerID);
                        ans_txt.push($scope.ansArray[i].AnswerText2);
                    }

                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerIDCSV = ans_val.join();
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerText = ans_txt.join();
                    $scope.model.DatasetCollection.tu.qu[0].CourseID = $scope.model.DatasetCollection.tu.au[0].courseid;
                }
                if ($scope.contentType == "ftg") {
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerIDCSV = arrSelVal.join();
                    $scope.model.DatasetCollection.tu.qu[0].TestAnswerText = arrSelText.join();
                    $scope.model.DatasetCollection.tu.qu[0].CourseID = $scope.model.DatasetCollection.tu.au[0].courseid;
                }
            };

            //Delete Records
            $scope.GenerateDelPayload = function () {
                var payload = { EntityKey: 'TestQuestion', ID: $scope.model.dsForm.DT[0].TestQuestionID, AcceptWarning: false };
                return payload;
            };

            $scope.btnNextSave = function () {
                $("div.spinnerTarget").addClass("backdrop");
                $("body").css("overflow", "hidden");
                usSpinnerService.spin('spinner-1');

                $scope.isNextDisable = "disabled";
                $scope.btnsave(true);

                $scope.$watch('saveQuestionStatus', function (saveQuestionStatus) {
                    if (saveQuestionStatus) {
                        var valNew = saveQuestionStatus.split("===");
                        var sSuccessMsg = valNew[0];
                        var sFileName = valNew[1];

                        if (sFileName == "Data Saved") {
                            var url = '/frmTestQuestionView/ParamsOutput' + location.search;
                            var payload = '';
                            if ($scope.model.DatasetCollection.tu.au[0].AssessTestID != undefined)
                                payload = { TestID: $scope.model.DatasetCollection.tu.au[0].AssessTestID, AssessUserID: $scope.model.DatasetCollection.tu.au[0].AssessUserID, TestQuestionID: $scope.QuestionInfo.TestQuestionID };
                            else
                                payload = { SurveyID: $scope.model.DatasetCollection.tu.au[0].AssessSurveyID, AssessUserID: $scope.model.DatasetCollection.tu.au[0].AssessUserID, TestQuestionID: $scope.QuestionInfo.TestQuestionID };

                            payload = JSON.stringify(payload);
                            var payloaddata = { key: 'testquestion', Params: payload, __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

                            $.post(url, payloaddata, function (result) {
                                var base = '/App/Link' + location.search;
                                var questionInfoContent = {};
                                angular.copy($scope.QuestionInfo, questionInfoContent);
                                questionInfoContent.DescriptionHTML = '';
                                questionInfoContent.DescriptionText = '';
                                questionInfoContent.QuestionHTML = '';
                                questionInfoContent.QuestionText = '';

                                questionInfoContent.AssessUserID = $scope.model.vBag.assessuserid;
                                var payload = '';
                                if (result.Data.ID == 0) {
                                    if ($scope.model.DatasetCollection.tu.au[0].ContentUnitID > 0) {
                                        payload = { fKey: 'frmContentUnitView', fMode: 'acEditM', IDX: $scope.model.DatasetCollection.tu.au[0].ContentUnitID, rowData: JSON.stringify(questionInfoContent) };
                                    }
                                    else if ($scope.model.DatasetCollection.tu.au[0].AssessSurveyID > 0) {
                                        payload = { fKey: 'frmAssessSurveyView', fMode: 'acEditM', IDX: $scope.model.DatasetCollection.tu.au[0].AssessUserID, rowData: JSON.stringify(questionInfoContent) };
                                    }
                                    else {
                                        payload = { fKey: 'frmAssessTestView', fMode: 'acEditM', IDX: $scope.model.DatasetCollection.tu.au[0].AssessUserID, rowData: JSON.stringify(questionInfoContent) };
                                    }
                                }
                                else {
                                    payload = { fKey: 'frmTestQuestionView', fMode: 'acEditM', IDX: result.Data.ID, rowData: JSON.stringify(questionInfoContent) };
                                }

                                $.post(base, payload, function (result) {
                                    $scope.status = 'loaded';
                                    window.location = result;
                                });
                            });
                        }

                    }
                });
            }

            $(document).on('change', '.ddlClass', function () {
                var selValue = $(this).children("option:selected").val();
                var selectedText = $(this).children("option:selected").html();

                arrSelVal.push(selValue);
                arrSelText.push(selectedText);
            });

            @Html.RenderFile("~/scripts/rsforms.js");
        });
    </script>
End Section
