﻿$(document).ready(function () {

    var items = "<option value='0'>Select</option>";
    $("#Brand_id").html(items);
    $("#Model_id").html(items);
    $('#Man_id').val('0');
    //bind brand
    $('#Man_id').change(function () {
        var url = "/Master/GetBrand";
        var ddlman = "#Man_id";
        $.getJSON(url, { Man_id: $(ddlman).val() }, function (data) {
            var items = '';
            $("#Brand_id").empty();
            $("#Model_id").empty();
            var itemst = "<option value='0'>Select</option>"
            $("#Brand_id").html(itemst)
            $("#Model_id").html(itemst)
            $.each(data, function (i, Brand) {
                items += "<option value='" + Brand.value + "'>" + Brand.text + "</option>";
            });
            $("#Brand_id").html(items)
        });
    });
    //bind model
    $('#Brand_id').change(function () {
        var url = "/Master/GetModel";
        var ddlbrand = "#Brand_id";
        $.getJSON(url, { Brand_id: $(ddlbrand).val() }, function (data) {
            var items = '';
            $("#Model_id").empty();
            $.each(data, function (i, Model) {
                items += "<option value='" + Model.value + "'>" + Model.text + "</option>";
            });
            $("#Model_id").html(items)
        });
    });


});