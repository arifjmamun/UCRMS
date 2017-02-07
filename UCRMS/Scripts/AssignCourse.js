$(document).ready(function () {
    $("#DepartmentId").change(function () {
        $("#TeacherId").empty().html('<option value>Select One</option>');
        $("#CourseId").empty().html('<option value>Select One</option>');
        $("#RemainingCredit").val('');
        $("#CreditToBeTaken").val('');
        $("#CourseName").val('');
        $("#CourseCredit").val('');

        var departmentId = $(this).val();
        var jsonData = { departmentId: departmentId };
        $.ajax({
            type: "POST",
            url: '/Teacher/GetAllTeacherAndCourseByDepartmentId',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function (response) {
                $.each(response.Teachers, function (key, value) {
                    $("#TeacherId").append('<option value="' + value.Id + '">' + value.Name + '</option>');
                });

                $.each(response.Courses, function (key, value) {
                    $("#CourseId").append('<option value="' + value.Id + '">' + value.Code + '</option>');
                });
            }
        });
    });

    $("#TeacherId").change(function () {
        $("#RemainingCredit").val('');
        $("#CreditToBeTaken").val('');
        var teacherId = $(this).val();
        if (teacherId !== '') {
            var jsonData = { teacherId: teacherId };
            $.ajax({
                type: "POST",
                url: '/Teacher/GetTeacherCourseCreditInfoByTeacherId',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(jsonData),
                success: function (response) {
                    $("#RemainingCredit").val(response.RemainingCredit);
                    $("#CreditToBeTaken").val(response.CreditToBeTaken);
                }
            });
        }
    });

    $("#CourseId").change(function () {
        $("#CourseName").val('');
        $("#CourseCredit").val('');
        var courseId = $(this).val();
        if (courseId !== '') {
            var jsonData = { courseId: courseId };
            $.ajax({
                type: "POST",
                url: '/Teacher/GetCourseInfoByCourseId',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(jsonData),
                success: function (response) {
                    $("#CourseName").val(response.Name);
                    $("#CourseCredit").val(response.Credit);
                }
            });
        }
    });

    $('#assignCourseForm').submit(function (e) {
        e.preventDefault();
        if ($(this).valid()) {
            var remainingCredit = Number($("#RemainingCredit").val());
            var courseCredit = Number($("#CourseCredit").val());
            if (courseCredit > remainingCredit) {
                remainingCredit = remainingCredit - courseCredit;
                swal({
                    title: 'Are you sure want to add the course?',
                    text: "Remaining Credit: " + remainingCredit,
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes',
                    cancelButtonText: 'No'
                }, function (isConfirmed) {
                    if (isConfirmed) {
                        document.assignCourseForm.submit();
                    }
                });
            }
            else {
                document.assignCourseForm.submit();
            }

        }
    });

});