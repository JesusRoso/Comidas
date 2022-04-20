function pruebaPuntoNetStatic()
{
    DotNet.invokeMethodAsync("Comidas.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log("Conteo desde js "+resultado)
        });
}

function mostrarAlerta(mensaje) {
    return alert(mensaje);
}

function timerInactivo(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 5000);
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}