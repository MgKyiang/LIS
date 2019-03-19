function Deliver() {

    $.ajax({
        type: "POST",
        url: "/Admin/Deliver",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate")
                {
                $("#pFailureMessage").text("List name is duplicated")
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
        url: "/Admin/Deliver",
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

function fillData(selectedCityId, selectedToCityId, selectedDate) {
    $("#selFrom").val(selectedCityId);
    $("#selTo").val(selectedToCityId);
    $("#selDate").val(selectedDate);
}

function fillFromData() {
    window.location = '/Admin/Booking?selectedFromCityId=' + $("#selFrom").val();
}

function fillToData() {
    window.location = '/Admin/Booking?selectedFromCityId=' + $("#selFrom").val() + '&selectedToCityId=' + $("#selTo").val();
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
            url: "/Admin/SeatPlan",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: data,
            cache: false,
            success: function (data) {
                window.location = '/Admin/Table';
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

function Sale() {

    $.ajax({
        type: "POST",
        url: "/Admin/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        cache: false,
        success: function (data) {
            if (data == "success") {
                window.location = "/Home/Index";
            } else {
                $("#pMessage").text("User is invalid.");
                $("#divError").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}