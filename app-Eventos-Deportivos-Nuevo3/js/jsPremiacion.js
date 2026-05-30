function validarGuardado() {
    let respuesta = "";
    if ($("#idEvento").val().trim() == "")
        respuesta += "\n{idEvento]";
    if ($("#idParticipante").val().trim() == "")
        respuesta += "\n{idParticipante]";
    if ($("#puesto").val().trim() == "")
        respuesta += "\n{puesto]";
    if ($("#premio").val().trim() == "")
        respuesta += "\n{premio]";

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}