function generateCalendar(courses) {
    $("#calendar").fullCalendar({
        defaultView: 'month',
        businessHours: true,
        timeFormat: "h(:mm)a",
        events: courses,
        eventClick: function (courses) {
            console.log(courses);
            $("#coursesName").text(courses.title);
            $("#coursesDesc").text(courses.description);
            $("#startTime").text("Start time: " + moment(courses.start).format("DD-MMM-YYYY HH:mm"));
            if (courses.start < $.now()) {
                $('#bookLink').text("Courses finished");
                $('#bookLink').attr("onclick", "return false");
            } else {
                $('#bookLink').text("Book Now");
                var newUrl = "/BookCourses/Book/" + courses.coursesId;
                $('#bookLink').attr("href", newUrl );
            }

        }
    });
}