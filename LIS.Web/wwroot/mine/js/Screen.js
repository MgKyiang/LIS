function fillData(selectedCityId,selectedToCityId , selectedDate) {
    $("#selFrom").val(selectedCityId);
    $("#selTo").val(selectedToCityId);
    $("#selDate").val(selectedDate);
}

var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function fillFromData() {
    window.location = '/Screen/Booking?selectedFromCityId=' + $("#selFrom").val();
}
//function fillToData() {
//    $('#selTo').empty().append('<option value="">Select One</option>');
//    if (!$("#selFrom").val()) {
//        return;
//    }
//    $.ajax({
//        type: "GET",
//        url: "/Screen/ListByFromId?cityId=" + $("#selFrom").val(),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        cache: false,
//        success: function (data) {
//            $.each(data, function (i, o) {
//                $("#selTo").append($("<option></option>")
//                                .attr("value", o.Id)
//                                .text(o.Name));
//            });
//        },
//        error: function (xhr, status, error) {
//            alert(xhr.responseText);
//        }
//    });
//}

function fillToData() {
    window.location = '/Screen/Booking?selectedFromCityId=' + $("#selFrom").val() + '&selectedToCityId=' + $("#selTo").val();
}

var Selectedseat = [];
function check() {
    $(document).ready(function () {

        //$(".reserved input").prop('checked', true); //set value true to checked input
        //$(".reserved input").prop('disabled', true);//set value true to disabled input checkbox
        $("label").click(function () {
            if (!$(this).hasClass("reserved")) {//check to see booking or not
                if ($(this).find("input").is(":checked")) {//check if checkbox is clicked or not
                    $(this).addClass("selected");
                } else {
                    console.log("selected");
                    $(this).removeClass("selected");
                }
            }
            else {
                alert("Already booked");
            }
        })
    });
}

function save() {
    $(document).ready(function () {
        var favorite = [];
        $.each($("input[name='checkseat']:checked"), function () {
            favorite.push($(this).val());
        });
        //alert("Selected Seats are: " + favorite.join(", "));
        Selectedseat = favorite;
    });
    if (Selectedseat.length > 0) {
        var data = getInputData();//JSON.stringify(Selectedseat);

        $.ajax({
            type: "POST",
            url: "/Screen/SeatPlan",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: data,
            cache: false,
            success: function (data) {
                window.location = '/Screen/List';
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        });
    } else {
        alert("Choose seat");
    }
}

function getInputData() {
    var data = JSON.stringify({
        "CarNo": $("#hidCarNo").val(),
        "Departure_Date": 20171124,
        "TripPlanName": $("#hidTripPlanName").val(),
        //"CarType": $("#txtCarNo").val(),
        "Departure_Time": $("#hidDeparture_Time").val(),
        "Arrival_Time": $("#hidArrival_Time").val(),
        "Price": $("#hidPrice").val(),
        "selectSeat": Selectedseat,
        "TripPlanId": $("#hidId").val(),
    });
    return data;
}

function setValidationRule() {
    $("#frmSale").validate({
        rules: {
            txtName: {
                required: true,
            },
            txtPhoneNo: {
                required: true,
            },
        }
    });
}

function Sale() {
    if (!$("#frmSale").valid()) {
        return;
    }

    var data = getInputData1();

    $.ajax({
        type: "POST",
        url: "/Admin/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage1").text("Thank You So Much For Your Order!!!");
                $("#pMessage2").text("Visit Our Website Again!!!");
                $("#divSuccess").modal('toggle');
            } else {
                $("#pMessage").text("User name or password is invalid.");
                $("#divError").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData1() {
    return JSON.stringify({
        "UserName": $("#txtName").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
    });
}

function enter(e) {
    e = e || window.event;
    if (e.keyCode == 13) {
        Sale();
    }
}
