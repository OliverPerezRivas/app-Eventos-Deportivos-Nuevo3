function validarGuardado() {
    let respuesta = "";
    if ($("#nombres").val().trim() == "")
        respuesta += "\n{nombre]";
    if ($("#apellidos").val().trim() == "")
        respuesta += "\n{apellidos]";
    if ($("#documento").val().trim() == "")
        respuesta += "\n{documento]";
    if ($("#fechaNacimiento").val().trim() == "")
        respuesta += "\n{fechaNacimiento]";
    if ($("#email").val().trim() == "")
        respuesta += "\n{email]";
    if ($("#idDeportes").val().trim() == "")
        respuesta += "\n{idDeporte]";

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}