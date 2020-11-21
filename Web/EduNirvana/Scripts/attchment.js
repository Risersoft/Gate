var submitUri = null;
var bar = $('.progress-bar');
var percent = $('.percent');
var _fileName = "";
var fileSize = "";
var pFileId = "";
var iFileId = "";
var lstModifiedDateTime = "";

$scope.$watch('fileStatus', function (fileStatus) {
    //debugger
    if (fileStatus) {
        var valNew = fileStatus.split('===');
        var sSuccessMsg = valNew[0];
        var sFileName = valNew[1];
        if (sSuccessMsg) {
            $scope.IsInitializing = true;
            $scope.checkStatusInterval(sSuccessMsg, sFileName, sFileName.split('==')[3]);
        }
    }
});

$scope.Upload = function () {
    $scope.isShowMsg = false;
    $scope.isbtnAttachmentUpload = "disabled";
    var fileExtn;

    if ($('#attach_filename').val() != "" && $('#attach_filename').val() != undefined && $('#attach_filename').val() != null) {
        fileExtn = $('#attach_filename').val().split('.').pop();

        if (fileExtn.toLowerCase() !== "pdf" && fileExtn.toLowerCase() !== "doc" && fileExtn.toLowerCase() !== "docx" && fileExtn.toLowerCase() !== "ppt" && fileExtn.toLowerCase() !== "pptx") {
            $('#errorModel').modal('toggle');
            $scope.isbtnAttachmentUpload = "";
            return false;
        }
    }

    if ($('#filename').val() != "" && $('#filename').val() != undefined && $('#filename').val() != null) {
        //debugger;
        $("div.spinnerTarget").addClass("backdrop");
        $("body").css("overflow", "hidden");
        usSpinnerService.spin('spinner-1');

        // For Progress baar
        filc = $('#attach_filename');
        filec = $('#attach_filename').val();

    } else {
        // For Progress baar
        if ($('#attach_filename').val() !== "" && $('#attach_filename').val() !== undefined && $('#attach_filename').val() !== null) {
            //debugger;
            $("div.spinnerTarget").addClass("backdrop");
            $("body").css("overflow", "hidden");
            usSpinnerService.spin('spinner-1');

            filc = $('#attach_filename');
            filec = $('#attach_filename').val();
        } else {
            $('#errorSelectModal').modal("toggle");
            return false;
        }
    }
    
    var url = '/frmAssessAssignView/ParamsOutput' + location.search;
    var payload = { filename: filec };
    payload = JSON.stringify(payload);
    var payloaddata = { key: 'sas', Params: payload, __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };
    // generic fxn
    $scope.UploadFile(url, payloaddata, true);
}

$scope.checkStatusInterval = function (valMsg, flName, contnetUnit) {
    //debugger;
    if (contnetUnit == "true") {
        if (valMsg == "success") {
            //setTimeout(function () {
                $('#spnMsg').html("<i class='fa fa-check-circle fa-2x' style='color: green'></i>  Your file has been uploaded successfully, if you want to upload another file so please continue with same process.");
                $scope.UploadFiles.push({ bloborgname: $('#attach_filename').val().split('\\')[2], blobname: flName.split("==")[0], filesize: (flName.split("==")[1] / 1024), lastmodified: new Date(flName.split("==")[2] * 1000).toGMTString(), blobUrl: flName.split("==")[4], isDeleted: true });
                $scope.isShowMsg = true;
                console.log($scope.UploadFiles);
                $scope.isbtnAttachmentUpload = "";
                $('#attach_filename').val('');
                $('#btnAttachmentUpload').removeAttr("disabled");
                $('#btnsave').removeAttr("disabled");
            //}, 100);            

            $("div.spinnerTarget").removeClass("backdrop");
            $("body").css("overflow", "auto");
            usSpinnerService.stop('spinner-1');
        }
    }
    else {
        if (valMsg == "success") {
            //debugger;
            var url = '/frmContentUnitUpload/ParamsOutput' + location.search;
            var payload = { serverPath: _fileName, length: _fileName.length, courseid: $scope.id, docType: $scope.model.vBag.doctype };
            payload = JSON.stringify(payload);
            var payloaddata = { key: 'process', Params: payload, __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

            $.post(url, payloaddata, function (result) {
                //debugger;
                if (result.Data.Success) {
                    var strMsg = '<div class="row"><div class="col-sm-1"><div class="loader"></div></div><div class="col-sm-11"><span style="font-size:20px">Your upload is in progress...</span><br/>' + result.Data.Message + '</div></div>';
                    $('#taskMsg').html(strMsg);
                    $('#taskMsg').show();

                    $('#btnFullPreview').hide();
                    $('#btnUpload').prop('disabled', true);
                    $('#btnsave').prop('disabled', true);
                    
                    var payload = { ApiTaskID: result.Data.Description };
                    payload = JSON.stringify(payload);
                    var payloaddata = { key: 'payloadstatus', Params: payload, __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

                    var stop = $interval(function () {
                        $.post(url, payloaddata, function (result) {
                            $('#btnFullPreview').hide();
                            $('#btnUpload').prop('disabled', true);
                            $('#btnsave').prop('disabled', true);

                            //console.log('running');
                            $('#showPreview').html('');
                            $('#taskMsg').html('');
                            //debugger;
                            if (result.status == "Executed") {
                                $scope.stopFight(stop);
                                if (result.Success) {
                                    $('#taskMsg').show();
                                    $('#taskMsg').html('<i class="fa fa-check-circle fa-2x" style="color:green"></i> <span style="font-size:20px">Your file has been uploaded successfully </span><br>' + result.Message);

                                    if (!$scope.IsInitializing) {
                                        var d_Data = result.result;
                                        var data = '';

                                        if (d_Data !== undefined) {
                                            data = JSON.parse(d_Data);
                                            //debugger;
                                            if (data.pdf !== undefined || data.medialensecs !== undefined) {
                                                $scope.flName = data.pdf;

                                                if ($scope.model.vBag.doctype !== "video" && $scope.model.vBag.doctype !== "audio") {
                                                    if (result.DownloadUrl.includes("png")) {
                                                        $('#taskMsg').hide();
                                                        $('#imgSrc').show();
                                                        $('#imgSrc').attr("src", result.DownloadUrl);
                                                    }
                                                } else {
                                                    $('#taskMsg').hide();
                                                }

                                                $('#btnFullPreview').show();
                                                $('#btnUpload').removeAttr("disabled");
                                                $('#btnsave').removeAttr("disabled");
                                                //debugger;
                                                if ($scope.model.vBag.doctype == "document" || $scope.model.vBag.doctype == "presentation" || $scope.model.vBag.doctype == "pdf") {
                                                    $scope.model.dsForm.DT[0].ContentFilePath = data.pdf;
                                                    $scope.flName = data.pdf;    // JSON.parse(result.Data.CalcList.task[0].InfoJson).path;
                                                    $('#cFileName').val($scope.flName);
                                                } else {
                                                    $scope.model.dsForm.DT[0].ContentFilePath = _fileName;
                                                    $scope.flName = _fileName;    // JSON.parse(result.Data.CalcList.task[0].InfoJson).path;
                                                    $('#cFileName').val(_fileName);
                                                }

                                                $scope.model.dsForm.DT[0].ContentPDFPath = data.pdf;
                                                $scope.model.dsForm.DT[0].ContentImagePath = data.img;
                                                $scope.model.dsForm.DT[0].ContentSizeMB = data.contentsizemb;
                                                $scope.model.dsForm.DT[0].ContentLenSecs = data.medialensecs;
                                                console.log($scope.model.dsForm.DT[0]);
                                                var strMsg1 = '';
                                                $('#taskMsg').html(strMsg1);
                                                $('#taskMsg').hide();

                                                $('#btnFullPreview').show();
                                                $('#btnUpload').removeAttr("disabled");
                                                $('#btnsave').removeAttr("disabled");
                                            }
                                            else {
                                                var strMsg1 = '<div class="row"><div class="col-sm-11"><span style="font-size:20px">Your file could not be uploaded successfully, please try again!!!</span></div></div>';
                                                $('#taskMsg').show();
                                                $('#taskMsg').html(strMsg1);

                                                $('#btnFullPreview').hide();
                                                $('#btnUpload').removeAttr("disabled");
                                                $('#btnsave').prop('disabled', true);
                                            }
                                        }
                                        else {
                                            $('#taskMsg').hide();
                                        }
                                    }
                                }
                                else {
                                    var strMsg1 = '<div class="row"><div class="col-sm-11"><span style="font-size:20px">Your file could not be uploaded successfully, please try again!!!</span></div></div>';
                                    $('#taskMsg').show();
                                    $('#taskMsg').html(strMsg1);

                                    $('#btnFullPreview').hide();
                                    $('#btnUpload').removeAttr("disabled");
                                    $('#btnsave').prop('disabled', true);
                                }
                            }
                            else {
                                var strMsg1 = '<div class="row"><div class="col-sm-1"><div class="loader"></div></div><div class="col-sm-11"><span style="font-size:20px">Your upload is in progress...</span><br/>' + result.Message + '</div></div>';
                                $('#taskMsg').show();
                                $('#taskMsg').html(strMsg1);
                            }
                        });

                    }, 1000);
                    return;
                }
            });
        }
        else {
            $scope.hideLoadbutton = false;
            $scope.disableUploadButton = false;
            $('#btnsave').prop('disabled', true);
        }
    }

    return false;
}

$scope.deleteRow = function (index) {
    $scope.UploadFiles.splice(index, 1);
}

$scope.stopFight = function (stop) {
    $interval.cancel(stop);
    console.log('stop');
    $scope.IsInitializing = false;
};