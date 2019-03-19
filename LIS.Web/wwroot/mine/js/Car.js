function setValidationRule() {
    $("#frmCar").validate(
        {
            rules: {                
                txtCarNo: {
                    required: true,
                },
                txtColour: {
                    required: true,
                },
                txtCarType: {
                    required: true,
                },
                txtTotalSeatNo: {
                    required: true,
                },
            }
        })
}

function save() {
    if (!$("#frmCar").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Car/Entry",
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
                    $("#pFailureMessage").text("Car Number is duplicated")
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
        "CarNo": $("#txtCarNo").val(),
        "Colour":$("#txtColour").val(),
        "CarType": $("#txtCarType").val(),
        "TotalSeatNo": $("#txtTotalSeatNo").val(),        
    });
    return data;
}

function update() {
    if (!$("#frmCar").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Car/Edit",
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
                    $("#pFailureMessage").text("Car Number is duplicated")
                }
                else {
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
        "CarNo": $("#txtCarNo").val(),
        "Colour": $("#txtColour").val(),
        "CarType": $("#txtCarType").val(),
        "TotalSeatNo": $("#txtTotalSeatNo").val(),

    });
    return data;
}

function newRemove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({
        type: "POST",
        url: "/Car/Delete",
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

var id, version;

function setRemoveData(itemid, itemversion) {
    id = itemid;
    version = itemversion;
}