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
    $("#frmStaff").validate({
        rules: {
            selBranch: {
                required: true,
            },
            selPosition: {
                required: true,
            },
            txtName: {
                required: true,
            },
            txtPassword: {
                required: true,
            },
            txtDOB: {
                required: true,
            },
            txtNRC: {
                required: true,
            },
            txtFatherName: {
                required: true,
            },
            selCity: {
                required: true,
            },
            selTownship: {
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
            txtJoinedDate: {
                required: true,
            },
        }
    });
}

function save() {
    if (!$("#frmStaff").valid()) {
        return;
    }

    var inputData = getInputData();

    $.ajax({
        type: "POST",
        url: "/Staff/Entry",
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
    if (!$("#frmStaff").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Staff/Edit",
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
        "PositionId": $("#selPosition").val(),
        "Name": $("#txtName").val(),
        "Password": $("#txtPassword").val(),        
        "DOB": $("#txtDOB").val().replace(/-/g, ''),
        "NRC": $("#txtNRC").val(),
        "Gender": $('input[name=rdoGender]:checked').val(),
        "FatherName": $("#txtFatherName").val(),
        "CityId": $("#selCity").val(),
        "TownshipId": $("#selTownship").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),
        "JoinDate": $("#txtJoinedDate").val().replace(/-/g, ''),
    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "BranchId": $("#selBranch").val(),
        "PositionId": $("#selPosition").val(),
        "Name": $("#txtName").val(),
        "Password": $("#txtPassword").val(),
        "Gender": $('input[name=rdoGender]:checked').val(),
        "DOB": $("#txtDOB").val().replace(/-/g, ''),
        "NRC": $("#txtNRC").val(),
        "FatherName": $("#txtFatherName").val(),
        "CityId": $("#selCity").val(),
        "TownshipId": $("#selTownship").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),
        "JoinDate": $("#txtJoinedDate").val().replace(/-/g, ''),
    });

    return data;
}

function fillData(selectedBranchId, selectedPositionId, selectedCityId, selectedTownshipId) {
    $("#selBranch").val(selectedBranchId);
    $("#selPosition").val(selectedPositionId);
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
        url: "/Staff/Delete",
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
