$(document).ready(function () {
    $("#StudentId").change(function () {
        ClearFields();
        var studentId = $(this).val();
        if (studentId !== "") {
            var jsonData = { studentId: studentId };
            $.ajax({
                type: "POST",
                url: '/Student/GetStudentCourseResultByStudentId',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(jsonData),
                success: function (response) {
                    $("#StudentName").val(response.student.StudentName);
                    $("#StudentEmail").val(response.student.StudentEmail);
                    $("#StudentDepartment").val(response.student.StudentDepartment);
                    if (!$.isEmptyObject(response.courses)) {
                        $.each(response.courses, function (key, value) {
                            $("#tableBody").append(
                                '<tr>' +
                                    '<td>' + value.CourseCode + '</td>' +
                                    '<td>' + value.CourseName + '</td>' +
                                    '<td>' + value.GradeLetter + '</td>' +
                                '</tr>'
                            );
                        });
                    } else {
                        $("#tableBody").append(
                            '<tr>' +
                                '<td colspan="3">No result found.</td>' +
                            '</tr>'
                        );
                    }

                }
            });
        }
    });

    var pdfCanvas = $("#pdfCanvas"), cacheWidth = pdfCanvas.width, a4 = [595.28, 841.89], studentId;
    $("#makePdfButton").on("click", function () {
        studentId = $("#StudentId").val();
        if (studentId !== "") {
            $("body").scrollTop(0);
            $("#makePdfButton").hide();
            $("#viewResultForm").before(
                '<h3 id="pdfHeading" style="text-align:center;">' +
                'UCRMS | University Course and Result Management System<br/>' +
                'Student Result<br/><br/></h3>'
            );
            CreatePDF();
        }
    });

    function ClearFields() {
        $("#StudentName").val('');
        $("#StudentEmail").val('');
        $("#StudentDepartment").val('');
        $("#tableBody").empty();
    }

    function CreatePDF() {
        getCanvas().then(function (canvas) {
            var img = canvas.toDataURL("image/png");
            var doc = new jsPDF({
                unit: "px",
                format: "a4"
            });
            doc.addImage(img, "JPEG", 20, 20);
            var id = studentId + $("#StudentName").val() + Math.floor(Date.now() / 1000);
            $("#makePdfButton").show();
            $("#pdfHeading").remove();
            doc.save(id);
            pdfCanvas.width(cacheWidth);
        });
    }

    function getCanvas() {
        pdfCanvas.width((a4[0] * 1.33333) - 80).css('max-width', 'none');
        return html2canvas(pdfCanvas, {
            imageTimeout: 2000,
            removeContainer: true
        });
    }

}());