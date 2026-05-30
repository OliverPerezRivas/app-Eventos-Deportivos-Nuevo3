
function validarGuardado() {
    let respuesta = "";
    if ($("#descripcion").val().trim() == "")
        respuesta += "\n{descripcion]";
 

    if (respuesta != "")
        alert("Los siguientes campos no pueden quedar vacios:" + respuesta);
}