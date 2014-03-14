$(function () {

    $(".mTable").find("tr").not("tr:first").mouseover(function () {
        $(this).siblings().not(":first").css("background", "#ffffff");
        $(this).css("background", "#E2EAF3");
    });

});