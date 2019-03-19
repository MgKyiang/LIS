function setValidationRule() {
    $("#frmPlace").validate({
        rules: {
            txtName: {
                required: true,
            },
            selCity: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmPlace").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Place/Entry",
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
                    $("#pFailureMessage").text("Place Name is duplicated")
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
    if (!$("#frmPlace").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Place/Edit",
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
                    $("#pFailureMessage").text("Place Name is duplicated")
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
        "CityId": $("#selCity").val(),
    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "Name": $("#txtName").val(),
        "CityId": $("#selCity").val(),
    });
    return data;
}

function fillData(selectedCityId) {
    $("#selCity").val(selectedCityId);
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
        url: "/Place/Delete",
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