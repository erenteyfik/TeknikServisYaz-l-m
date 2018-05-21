$(function () {
    $('#gunlukdate').datepicker({
        format: 'dd-MM-yyyy',
        autoclose: true,
        language: "tr",
    });
});
$("#hesapla").click(function (event) {
    $("#gunlukdate").addClass("value");
});
$("#gunlukdate").removeAttr("value");