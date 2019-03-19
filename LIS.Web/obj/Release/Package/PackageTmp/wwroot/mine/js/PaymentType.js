function setValidationRule() {
    $("#frmPaymentType").validate({
        rules: {
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
    if (!$("#frmPaymentType").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/PaymentType/Entry",
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
                $("#pFailureMessage").text("PaymentType name is duplicated")
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
    if (!$("#frmPaymentType").valid()) {
        return;
    }
    var data = getInputDataForUpdate();
    $.ajax({
        type: "POST",
        url: "/PaymentType/Edit",
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
                    $("#pFailureMessage").text("PaymentType name is duplicated");
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
        "Description": $("#txtDescription").val(),
    });
    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
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
        url: "/PaymentType/Delete",
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
