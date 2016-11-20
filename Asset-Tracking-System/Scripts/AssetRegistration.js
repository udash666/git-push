$("#GeneralCategoryId").on("change", function () {
    var generalCategoryId = $('#GeneralCategoryId').val();

    var jsonData = { generalCategoryId: generalCategoryId };
    $('#categoryId').empty();
    var defaultDropDownValue = '<option value="">--SELECT--</option>';
    $('#categoryId').append(defaultDropDownValue);


    $.ajax({
        type: "POST",
        url: "/AssetRegistration/GetCategoriesByGeneralCategory",
        data: JSON.stringify(jsonData),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            // get json data list
            $.each(data, function (key , category) {

                var optionText = "<option value='" +category.Id + "'>" + category.Code+ "</option>";
                $('#categoryId').append(optionText);
            });


        }


    });

});

function Action(AssetId) {
    $.ajax({
        url: "/AssetRegistration/AssetIdGenerate",
        type: "POST",
        data: { "AssetId": AssetId },
        "success": function (data) {
            if (data != null) {
                var vdata = data;
                $("#GeneralCategoryId").val(vdata[0].code);
                $("#CategoryId").val(vdata[0].code);
                $("#Id").val(vdata[0].key);
            }
        }
    });
}