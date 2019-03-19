function fillTownship() {
    $('#selTownship').empty().append('<option value="">Select One</option>');

    if (!$("#selCity").val()) {
        return;
    }

    $.ajax({
        type: "GET",
        url: "/Township/GetListByCityId?cityId=" + $("#selCity").val(),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {
            $.each(data, function (i, o) {
                $('#selTownship').append($("<option></option>")
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
    $("#frmBranch").validate({
        rules: {
            selCity: {
                required: true,
            },
            selTownship: {
                required: true,
            },
            txtName: {
                required: true,
            },
            txtFullAddress: {
                required: true,
            },
            txtPhoneNo: {
                required: true,
            },
            txtEmail: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmBranch").valid()) {
        return;
    }

    var inputData = getInputData();

    $.ajax({
        type: "POST",
        url: "/Branch/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: inputData,
        cache: false,
        success: function (outputData) {
            if (outputData == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else
            {
                if (outputData == "duplicate") {
                    $("#pFailureMessage").text("Branch name is duplicated");                   
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
    if (!$("#frmBranch").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Branch/Edit",
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
                    $("#pFailureMessage").text("Branch name is duplicated");
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
        "CityId": $("#selCity").val(),
        "TownshipId": $("#selTownship").val(),
        "Name": $("#txtName").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),
    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "CityId": $("#selCity").val(),
        "TownshipId": $("#selTownship").val(),
        "Name": $("#txtName").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),
    });

    return data;
}

function fillData(selectedCityId, selectedTownshipId) {
    $("#selCity").val(selectedCityId);
    $("#selTownship").val(selectedTownshipId);
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
        url: "/Branch/Delete",
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
