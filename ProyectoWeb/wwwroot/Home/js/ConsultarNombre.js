


// Esperar 5 segundos y luego ocultar el mensaje
setTimeout(function () {
    var mensajeDiv = document.getElementById('Msj');
    mensajeDiv.style.display = 'none';

}, 5000); // 5000 milisegundos = 5 segundos


function ConsultPeopleInfo() {

    let PersonalID = $("#PersonalId").val();

    if (PersonalID.length > 0) {
        $.ajax({
            type: "GET",
            url: "https://apis.gometa.org/cedulas/" + PersonalID,
            dataType: "json",
            success: function (result) {
                $("#nombre").val(result.results[0].firstname1);
                $("#pApellido").val(result.results[0].lastname1),
                    $("#sApellido").val(result.results[0].lastname2);
            }
        });
    }
    else {
        $("#nombre").val("");
        $("#pApellido").val("");
        $("#sApellido").val("");
    }
}