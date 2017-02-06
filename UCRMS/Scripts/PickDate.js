$(document).ready(function () {
    $(".pickerDate").daterangepicker({
        locale: {
            format: "YYYY-MM-DD"
        },
        singleDatePicker: true,
        showDropdowns: true,
        opens: "left"
    }, function (start, end, label) {
        moment().diff(start, 'years');
    });
});