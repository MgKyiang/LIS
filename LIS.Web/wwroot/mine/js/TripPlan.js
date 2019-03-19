function setValidationRule() {
    $("#frmTripplan").validate({
        rules: {
            selCar: {
                required: true,
            },
            txtTripPlanName: {
                required: true,
            },
            txtDeparture: {
                required: true,
            },
            txtArrvial: {
                required: true,
            },
            txtDepartureDate: {
                required: true,
            },
            txtDepartureTime: {
                required: true,
            },
            txtArrivalDate: {
                required: true,
            },
            txtArrivalTime: {
                required: true,
            },
            txtPrice: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmTripplan").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Tripplan/Entry",
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
                    $("#pFailureMessage").text("TripPlan Name is duplicated")
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
    if (!$("#frmTripplan").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Tripplan/Edit",
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
                    $("#pFailureMessage").text("TripPlan Name is duplicated")
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
        "CarId": $("#selCar").val(),
        "TripPlanName": $("#txtTripPlanName").val(),
        "Departure": $("#txtDeparture").val(),
        "Arrvial": $("#txtArrvial").val(),
        "Price": $("#txtPrice").val(),
        "Departure_Date": $("#txtDepartureDate").val().replace(/-/g, ''),
        "Departure_Time": $("#txtDepartureTime").val(),
        "Arrival_Date": $("#txtArrivalDate").val().replace(/-/g, ''),
        "Arrival_Time": $("#txtArrivalTime").val(),
        "Available_Status": $('input[name=rdoStatus]:checked').val(),
    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "CarId": $("#selCar").val(),
        "TripPlanName": $("#txtTripPlanName").val(),
        "Departure": $("#txtDeparture").val(),
        "Arrvial": $("#txtArrvial").val(),
        "Price": $("#txtPrice").val(),
        "Departure_Date": $("#txtDepartureDate").val().replace(/-/g, ''),
        "Departure_Time": $("#txtDepartureTime").val(),
        "Arrival_Date": $("#txtArrivalDate").val().replace(/-/g, ''),
        "Arrival_Time": $("#txtArrivalTime").val(),
        "Available_Status": $('input[name=rdoStatus]:checked').val(),
    });
    return data;
}

function fillData(selectedCarId,selectedDeparture,selectedArrival) {
    $("#selCar").val(selectedCarId);
    $("#txtDeparture").val(selectedDeparture);
    $("#txtArrvial").val(selectedArrival);
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
        url: "/Tripplan/Delete",
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