alert("a");
$("#MailEkleClick").click(function () {

    $.Email = $("#TekilMailInput").val();
    $.KisiId = $("#KisiId").val();

    $.EmailModel = {
        "Email": $.Email,
        "KisiId": $.KisiId
    };

    $.ajax({
        type: "POST",
        url: '@Url.Action("MailEkle", "Admin")',
        data: $.EmailModel,
        dataType: "json",
        success: function (data) {
            alert("Başarılı bir şekilde eklenedi");
        }
    }).always(function () {
        location.reload();
    });

});

$("#TelEkleClick").click(function () {

    $.Phone = $("#TekilTelInput").val();
    $.KisiId = $("#KisiId").val();

    $.PhoneModel = {
        "Phone": $.Phone,
        "KisiId": $.KisiId
    };

    $.ajax({
        type: "POST",
        url: '@Url.Action("PhoneEkle","Admin")',
        data: $.PhoneModel,
        dataType: "json",
        success: function (data) {
            alert("Başarılı bir şekilde eklenedi");
        }
    }).always(function () {
        location.reload();
    });

});