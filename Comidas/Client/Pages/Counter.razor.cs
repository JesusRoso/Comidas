using Microsoft.AspNetCore.Components;
using MathNet.Numerics.Statistics;
using Microsoft.JSInterop;
using static Comidas.Client.Shared.MainLayout;
using Microsoft.AspNetCore.Components.Authorization;

namespace Comidas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServiciosSingleton singleton { get; set; }
        [Inject] ServiciosTrancient trancient { get; set; }
        [Inject] protected IJSRuntime JS { get; set; }
        [CascadingParameter] protected AppState appState { get; set; }
        [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
        IJSObjectReference modulo; // IJSObjectReference es el tipo de dato para guardar módulos de js
        private int currentCount = 0;
        static int currentCountStatic = 0;
        protected async Task IncrementCount()
        {
            var authState = await authenticationState;
            var usuario = authState.User;
            if(usuario.Identity.IsAuthenticated) // con IsAuthenticated está diciendo si está autenticado o no
            {
                currentCount++;
                currentCountStatic++;
            }
            else
            {
                currentCount--;
                currentCountStatic--;
            }
            modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await modulo.InvokeVoidAsync("mostrarAlerta");

            var arreglo = new double[] { 1, 2, 3, 4, 5 };
            var max = arreglo.Maximum();
            var min = arreglo.Minimum();
            Console.WriteLine($"El valor max es: {max} y el valor min es {min}");
            singleton.Valor = currentCount;
            trancient.Valor = currentCount;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }
        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
		{
            return Task.FromResult(currentCountStatic);
		}
    }
}
