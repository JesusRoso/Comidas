using Microsoft.JSInterop;

namespace Comidas.Client.Helpers
{
    public class MostrarMensajes : IMostrarMensajes
    {
        private IJSRuntime js;
        public MostrarMensajes(IJSRuntime js)
        {
            this.js = js;
        }
        public async Task MostrarMensajeError(string mensaje)
        {
            await MostrarMensaje("Error", mensaje, "error");
        }
        public async Task MostrarMensajeExitoso(string mensaje)
        {
            await MostrarMensaje("Exitoso", mensaje, "success");
        }
        private async ValueTask MostrarMensaje(string titulo, string mensaje, string tipoMensaje)
        {
            await js.InvokeVoidAsync("Swal.fire", titulo, mensaje, tipoMensaje);
        }

    }
}

