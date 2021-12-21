
var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:8001/reporthub").build();


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
   
}).catch(function (err) {
    return console.error(err.toString());
})

connection.on("Report", function (report) {
    addReportToTable(report);   
});


document.getElementById("sendButton").addEventListener("click", function (event) {
    var sendReportRquest = {
        RaporTarihi: "2021-01-01",
        RaporDurum: 1,
        RaporDurumText: "Hazırlanıyor"
    }
    SendReport(sendReportRquest);
    event.preventDefault();
});



function addReportToTable(report) {
    var str = "<tr>";
    str += "<td>" + report.uuid + "</td>";
    str += "<td>" + report.raporDurumText + "</td>";
    str += "</tr>";

    if ($('table > tbody> tr:first').length > 0) {
        $('table > tbody> tr:first').before(str);
    } else {
        $('.bidLine').append(str);
    }

}

function SendReport(report) {
    $.ajax({

        url: "http://localhost:8001/api/v1/Report",
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        contentType: 'application/json',
        data: JSON.stringify(report),
        dataType: 'json',
        success: function (response) {
           
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

