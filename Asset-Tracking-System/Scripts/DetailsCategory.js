    $("#GeneralCategoryId").on("change", function () {
        var generalCategoryId = $('#GeneralCategoryId').val();

        var jsonData = { generalCategoryId: generalCategoryId };
        $('#categoryId').empty();
        var defaultDropDownValue = '<option value="">--SELECT--</option>';
        $('#categoryId').append(defaultDropDownValue);


        $.ajax({
            type : "POST",
            url: "/DetailsCategory/GetCategoriesByGeneralCategory",
            data: JSON.stringify(jsonData),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                // get json data list
                $.each(data, function (key, category) {

                    var optionText = "<option value='" + category.Id + "'>" + category.Name + "</option>";
                    $('#categoryId').append(optionText);
                });


            }


        });

    });

    $("#categoryId").on("change", function () {
        var categoryId = $('#categoryId').val();

        var jsonData = { categoryId: categoryId };
        $('#subcategoryId').empty();
        var defaultDropDownValue = '<option value="">--SELECT--</option>';
        $('#subcategoryId').append(defaultDropDownValue);
        $.ajax({
            type: "POST",
            url: "/DetailsCategory/GetSubCategoriesByCategory",
            data: JSON.stringify(jsonData),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                // get json data list
                $.each(data, function (key, subCategory) {

                    var optionText = "<option value='" + subCategory.Id + "'>" + subCategory.Name + "</option>";
                    $('#subcategoryId').append(optionText);
                });


            }


        });

    });