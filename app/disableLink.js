/// <reference path="C:\Users\idoda\Documents\Visual Studio 2015\Projects\WebApplication34\WebApplication34\Vendors/Jquery.js" />


$(document).ready(function () {
    $("#myMenu").find('*[href]').each(function () {
        if ($(this).attr("href") == window.location.pathname) {
            $(this).removeAttr("href");
        }
    })
});
var sum = 0;
$(document).ready(function () {
    $(".priceRes").each(function () {
        var value = $(this).text();
        if (!isNaN(value) && value.length != 0) {
            sum += parseFloat(value);
        }
    });
    $('#spanRes').text(sum);
});

$(document).ready(function () {
    $('.myCb').click(function () {
        var tableRow = $(this).parent().parent();
        var pId = $(this).attr('myid');
        var myUrl = 'http://localhost:64245/ShoppingCart/RemoveProduct/';
        $.post(myUrl,{ prodId:pId},function (id) {
                $(tableRow).remove();
        });
    });
});

var buyBtn = document.getElementById("buyAllBtn");
function buyAll() {
    alert("thank you for your buying");
};
buyBtn.addEventListener("click", buyAll);
