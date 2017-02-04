$(document).ready(function () {
    $("#DepartmentId").change(function () {
        $("#TeacherId").empty().html('<option value>Select One</option>');
        var departmentId = $(this).val();
        var jsonData = { departmentId: departmentId };
        $.ajax({
            type: "POST",
            url: '@Url.Action("GetAllTeacherByDepartmentId", "Teacher")',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function (response) {
                $.each(response, function (key, value) {
                    $("#TeacherId").append('<option value="' + value.Id + '">' + value.Name + '</option>');
                });
            }
        });
    });
});