

$(document).ready(function () {
    $('#servis-formu').mDatatable({
        search: {
            input: $('#generalSearch')
        },
        layout: {
            scroll: true,
            height: 1400
        },
    });
    
    //$("#statedropdown").change(function () {
    //    var value = this.value;
    //    $.ajax({
    //        url: '@Url.Action("ServisFormlarımState", "Admin")',
    //        type: 'POST',
    //        data: {
    //            state: value
    //        },
    //        success: function (response) {
    //            //console.log(response);
    //            $('#table-wrapper').html(response);

    //            $('#servis-formu').mDatatable({
    //                search: {
    //                    input: $('#generalSearch')
    //                },
    //                layout: {
    //                    scroll: true,
    //                    height: 1400
    //                }
    //            });
    //        },
    //        error: function (err) {

    //        }
    //    });
    //});
});

//$("body").on("change", "#statedropdown", function (e) {
//    var value = this.value;
//    $.ajax({
//        url: '@Url.Action("ServisFormlarım", "Admin")',
//        type: 'POST',
//        data: {
//            state: value
//        },
//        success: function (response) {
//            //console.log(response);
//            $('#mahmut').html(response);
//        },
//        error: function (err) {

//        }
//    })
//});



////<![CDATA[
//jQuery(function ($) {

//    $("#printcontainer").find('button').on('click', function () {
//        //Print ele4 with custom options
//        $("#printcontainer").print({

           
//        });
//    });
//    // Fork https://github.com/sathvikp/jQuery.print for the full list of options
//});
////]]>


