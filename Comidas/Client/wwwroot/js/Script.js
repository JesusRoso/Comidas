function pruebaPuntoNetStatic()
{
    DotNet.invokeMethodAsync("Comidas.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log("Conteo desde js "+resultado)
        });
}