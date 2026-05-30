
function validarGuardado() {
    let respuesta = "";
    if ($("#idParticipante").val().trim() == "")
        respuesta += "\n{idParticipante]";
    if ($("#idEvento").val().trim() == "")
        respuesta += "\n{idEvento]";
    if ($("#idFormaPago").val().trim() == "")
        respuesta += "\n{idFormaPago]";
    if ($("#fechaInscripcion").val().trim() == "")
        respuesta += "\n{fechaInacripcion]";
    if ($("#montoPagado").val().trim() == "")
        respuesta += "\n{montoPagado]";

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}