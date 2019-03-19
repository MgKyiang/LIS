function setValidationRule() {
    $("#frmUser").validate({
        rules: {
            selRole: {
                required: true,
            },
            txtFullName: {
                required: true,
            },
            txtPassword: {
                required: true,
            },
            txtNRC: {
                required: true,
            },
            txtAddress: {
                required: true,
            },
            txtContactNo: {
                required: true,
            },
            txtPosition: {
                required: true,
            },
        }
    });
}

function fillData(selectedRoleId) {
    $("#selRole").val(selectedRoleId);
}

function save() {
    if (!$("#frmUser").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/User/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate")
                {
                $("#pFailureMessage").text("User name is duplicated")
                }
                else
                {
                    $("#pMessage").text("Saving is fail");
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
    if (!$("#frmUser").valid()) {
        return;
    }
    var data = getInputDataForUpdate();
    $.ajax({
        type: "POST",
        url: "/User/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Updating is done");
                $("#divSuccess").modal('toggle');
            } else {
                if(data == "duplicate"){
                    $("#pFailureMessage").text("User name is duplicated");
                } else {
                    $("#pMessage").text("Updating is fail");
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
        "RoleId": $("#selRole").val(),
        "FullName": $("#txtFullName").val(),
        "Password": $("#txtPassword").val(),
        "NRC": $("#txtNRC").val(),
        "Address": $("#txtAddress").val(),
        "ContactNo": $("#txtContactNo").val(),
        "Position": $("#txtPosition").val(),
    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "RoleId": $("#selRole").val(),
        "FullName": $("#txtFullName").val(),
        "Password": $("#txtPassword").val(),
        "NRC": $("#txtNRC").val(),
        "Address": $("#txtAddress").val(),
        "ContactNo": $("#txtContactNo").val(),
        "Position": $("#txtPosition").val(),
    });
    return data;
}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function newRemove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });
    $.ajax({
        type: "POST",
        url: "/User/Delete",
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


