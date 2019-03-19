function fillClass() {
    $('#selClass').empty().append('<option value="">Select One</option>');

    if (!$("#selGrade").val()) {
        return;
    }

    $.ajax({
        type: "GET",
        url: "/Class/GetListByGradeId?gradeId=" + $("#selGrade").val(),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {
            $.each(data, function (i, o) {
                $('#selClass').append($("<option></option>")
                                .attr("value", o.Id)
                                .text(o.Name));
            });
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function setValidationRule() {
    $("#frmStudentHistory").validate({
        rules: {
            selBatch: {
                required: true,
            },
            selGrade: {
                required: true,
            },            
            selClass: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmStudentHistory").valid()) {
        return;
    }

    var inputData = getInputData();

    $.ajax({
        type: "POST",
        url: "/StudentInBatch/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: inputData,
        cache: false,
        success: function (outputData) {
            if (outputData == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (outputData == "duplicate") {
                    $("#pFailureMessage").text("The student is already registered for the Batch.");
                }
                else {
                    $("#pFailureMessage").text("Saving is fail");
                }

                $("#divFailure").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmStudentHistory").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/StudentInBatch/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate") {
                    $("#pFailureMessage").text("StudentInBatch No or NRC is duplicated");
                }
                else {
                    $("#pFailureMessage").text("Saving is fail");
                }

                $("#divFailure").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "BranchId": $("#hidBranchId").val(),
        "StudentId": $("#hidStudentId").val(),
        "BatchId": $("#selBatch").val(),
        "GradeId": $("#selGrade").val(),
        "ClassId": $("#selClass").val(),
    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "BranchId": $("#hidBranchId").val(),
        "StudentId": $("#hidStudentId").val(),
        "BatchId": $("#selBatch").val(),
        "GradeId": $("#selGrade").val(),
        "ClassId": $("#selClass").val(),
    });

    return data;
}

function fillData(selectedBatchId, selectedGradeId, selectedClassId) {
    $("#selBatch").val(selectedBatchId);
    $("#selGrade").val(selectedGradeId);
    $("#selClass").val(selectedClassId);
}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function remove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({
        type: "POST",
        url: "/StudentInBatch/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Deleting is done");
            } else {
                $("#pMessage").text("Deleting is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}
