$("#btn").click(function () {
    var ReservationModel = {
        status: "onay beklenyior",
        HowmanyPapel: $("#kk").val(),
        Userid: 1,
        Destintionid: 1,
        ReservDate: Date.now,
        ReservStart: $("#gt").val(),
        ReservEnd: $("#du").val(),
        Guidid: 3
    };
    $.ajax({
        url: "/Member/Reservation/AddReservation",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(ReservationModel),
        success: function (response) {
            $("#den").text(response + "kayit Basarili");
        },
        beforeSend: function () {
            $("#den").text("Cevap bekleniyor");
        },
        error: function (error) {
            console.log(error);
            $("#den").text(error + "kayit yapilamadi")
        }
    })
});