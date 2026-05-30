
function validarGuardado() {
    let respuesta = "";
    if ($("#nombre").val().trim() == "")
        respuesta += "\n{nombre]";
    if ($("#fecha").val().trim() == "")
        respuesta += "\n{fecha]";
    if ($("#lugar").val().trim() == "")
        respuesta += "\n{lugar]";
    if ($("#idDeporte").val().trim() == "")
        respuesta += "\n{idDeporte]";
    if ($("#costo").val().trim() == "")
        respuesta += "\n{costo]";

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}