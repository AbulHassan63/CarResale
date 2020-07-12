$(document).ready(function () {

    var items = "<option value='0'>Select</option>"
    $("#Brand_id").html(items);
    $("#Model_id").html(items);
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


    $('#btnclear').click(function () {
        var items = "<option value='0'>Select</option>"
        $("#Brand_id").html(items);
        $("#Model_id").html(items);
        $('#YearBuild').val("")
        $('#Kilometer_Coverd').val("");
    });
    $("#btnsave").click(function () {
        if ($('#Man_id').val() == "0") {
            alert("Please select  Make!");
            return false;
        }
        else if ($('#Brand_id').val() == "0") {
            alert("Please select Brand !");
            return false;
        }
        else if ($('#Model_id').val() == "0") {
            alert("Please select Model !");
            return false;
        }
        else if ($('#Kilometer_Coverd').val() == "" || $('#Kilometer_Coverd').val() == "0") {
            alert("Please Fill Kilometer covered !");
            return false;
        }
        else if ($('#YearBuild').val() == "" || $('#YearBuild').val() == "0") {
            alert("Please Fill YearBuild !");
            return false;
        }
        return true;
    });

});