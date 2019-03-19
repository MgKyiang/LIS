function setValidationRule() {
    $("#frmCity").validate({
        rules: {
            txtName: {
                required: true,
            },
            txtDistrict_Name: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmCity").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/City/Entry",
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
                    $("#pFailureMessage").text("City Name is duplicated")
                }
                else {
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
    if (!$("#frmCity").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/City/Edit",
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
                    $("#pFailureMessage").text("City Name is duplicated")
                }
                else {
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

function getInputData() {
    var data = JSON.stringify({
        "Name": $("#txtName").val(),
        "District_Name": $("#txtDistrict_Name").val(),

    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "Name": $("#txtName").val(),
        "District_Name": $("#txtDistrict_Name").val(),

    });
    return data;
}

function fillData(selectedPlaceId, selectedCityId) {
    $("#selCity").val(selectedCityId);
    $("#selPlace").val(selectedPlaceId);
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
        url: "/City/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Deleting is done.");
            } else {
                $("#pMessage").text("Deleting is fail.");
            }
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}
