
function validarGuardado(){
    let respuesta = "";
    if ($("#nombre").val().trim() == "")
        respuesta += "\n{nombre]";
    if ($("#nombre").val().trim() == "")
        respuesta += "\n{categoria]";

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}