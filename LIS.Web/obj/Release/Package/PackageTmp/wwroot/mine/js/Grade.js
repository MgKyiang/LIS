function setValidationRule() {
    $("#frmGrade").validate({
        rules: {
            selGrade: {
                required: true,
            },
            txtName: {
                required: true,
            },
            txtDescription: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmGrade").valid()) {
        return;
    }

    var inputData = getInputData();

    $.ajax({
        type: "POST",
        url: "/Grade/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: inputData,
        cache: false,
        success: function (outputData) {
            if (outputData == "success") {
                $("#pMessage").text("Saving is done");                
            } else {
                $("#pMessage").text("Saving is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmGrade").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Grade/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Updating is done");
            } else {
                $("#pMessage").text("Updating is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "BranchId": $("#selBranch").val(),
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "BranchId": $("#selBranch").val(),
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
    });

    return data;
}

function fillData(selectedBranchId) {
    $("#selBranch").val(selectedBranchId);
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
        url: "/Grade/Delete",
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

function fillGradeData() {
    window.location = '/Grade/List?selectedBranchId=' + $("#selBranch").val();
} 
