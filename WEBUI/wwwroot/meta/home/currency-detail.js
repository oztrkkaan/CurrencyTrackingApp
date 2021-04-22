$(document).ready(function () {
    var hiddenStartDate = $("#StartDate");
    var hiddenEndDate = $("#EndDate");

    hiddenStartDate.val(moment().format("DD.MM.yyyy"));
    hiddenEndDate.val(moment().format("DD.MM.yyyy"));


    $("#startDatePicker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format("YYYY"), 10),
         locale: {
            format: "DD.MM.YYYY"
        }
    }, function (startDate) {
            startDate = moment(startDate).format("DD.MM.yyyy");
            hiddenStartDate.val(startDate);
    });

    $("#endDatePicker").daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format("YYYY"), 10),
        locale: {
            format: "DD.MM.YYYY"
        }
    }, function (endDate) {
            endDate = moment(endDate).format("DD.MM.yyyy");
            hiddenEndDate.val(endDate);
    });


});

