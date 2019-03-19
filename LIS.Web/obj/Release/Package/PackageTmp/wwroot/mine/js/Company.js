function setValidationRule() {
    $("#frmCompany").validate({
        rules: {
            txtName: {
                required: true,
            },
            txtLicense: {
                required: true,
            },
            txtRegisteredDate: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmCompany").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Company/Entry",
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
                $("#pFailureMessage").text("Company name is duplicated")
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
    if (!$("#frmCompany").valid()) {
        return;
    }
    var data = getInputDataForUpdate();
    $.ajax({
        type: "POST",
        url: "/Company/Edit",
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
                    $("#pFailureMessage").text("Company name is duplicated");
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
        "Name": $("#txtName").val(),
        "License": $("#txtLicense").val(),
        "RegisteredDate": $("#txtRegisteredDate").val().replace(/-/g, ''),
    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "Name": $("#txtName").val(),
        "License": $("#txtLicense").val(),
        "RegisteredDate": $("#txtRegisteredDate").val().replace(/-/g, ''),
    });
    return data;
}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function removeDelete() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });
    $.ajax({
        type: "POST",
        url: "/Company/Delete",
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
