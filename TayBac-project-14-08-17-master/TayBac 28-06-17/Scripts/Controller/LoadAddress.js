$(document).ready(function () {
    var idtinh = $("#idtinh").val();
    initHuyen(idtinh);
})

$("#idtinh").change(function () {
    var idtinh = $(this).val();
    initHuyen(idtinh);
})

$("#idhuyen").change(function () {
    var idhuyen = $(this).val();
    initXa(idhuyen);
})
function initHuyen(id) {
    $.ajax({
        url: '/Huyen/ListHuyens',
        dataType: "json",
        type: "GET",
        data: { id: id },
        async: true,
        success: function (data) {
            $("#idhuyen > *").remove();
            for (var i = 0; i < data.length; i++) {
                // $("#idhuyen").append('<option value="' + data[i]["id"].trim() + '">' + data[i]["name"] + '</option>');
                $("#idhuyen").append(new Option(data[i]["name"], data[i]["id"]));
            }
            var idhuyen = $("#idhuyen").val();
            initXa(idhuyen);
        }
    })
}
function initXa(id) {
    $.ajax({
        url: '/Xa/ListXas',
        dataType: "json",
        type: "GET",
        data: { id: id },
        async: true,
        success: function (data) {
            $("#idxa > *").remove();
            for (var i = 0; i < data.length; i++) {
                // $("#idxa").append('<option value="' + data[i]["id"] + '">' + data[i]["name"] + '</option>');
                $("#idxa").append(new Option(data[i]["name"], data[i]["id"]));

            }
        }
    })
}