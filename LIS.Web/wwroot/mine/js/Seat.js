function setValidationRule() {
    $("#frmSeat").validate({
        rules: {
            selCarId: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmSeat").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Seat/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
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

function getInputData() {
    var data = JSON.stringify({        
        "CarId": $("#selCarId").val(),
        "Start": $("#txtStart").val(),
        "End": $("#txtEnd").val(),
        "SeatNo": $("#txtSeatNo").val(),
    });
    return data;
}

function fillData(selectedCarId) {
    $("#selCarId").val(selectedCarId);
}

function update() {
    if (!$("#frmSeat").valid()) {
        return;
    }
    var data = getInputDataForUpdate();
    $.ajax({
        type: "POST",
        url: "/Seat/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Updating is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate") {
                    $("#pFailureMessage").text("Seat name is duplicated");
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

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "CarId": $("#selCarId").val(),
        "Start": $("#txtStart").val(),
        "End": $("#txtEnd").val(),
        "SeatNo": $("#txtSeatNo").val(),
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
        url: "/Seat/Delete",
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

