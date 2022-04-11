using Microsoft.AspNetCore.Components;
using MathNet.Numerics.Statistics;
using Microsoft.JSInterop;
using static Comidas.Client.Shared.MainLayout;

namespace Comidas.Client.Pages
{
    public partial class Counter
    {

        [Inject] ServiciosSingleton singleton { get; set; }
        [Inject] ServiciosTrancient trancient { get; set; }
        [Inject] protected IJSRuntime JS { get; set; }
        [CascadingParameter] protected AppState appState { get; set; }
        IJSObjectReference modulo; // IJSObjectReference es el tipo de dato para guardar módulos de js
        private int currentCount = 0;
        static int currentCountStatic = 0;
        protected async Task IncrementCount()
        {
            modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await modulo.InvokeVoidAsync("mostrarAlerta");
            var arreglo = new double[] { 1, 2, 3, 4, 5 };
            var max = arreglo.Maximum();
            var min = arreglo.Minimum();
            Console.WriteLine($"El valor max es: {max} y el valor min es {min}");
            currentCount++;
            singleton.Valor = currentCount;
            trancient.Valor = currentCount;
            currentCountStatic++;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }
        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
		{
            return Task.FromResult(currentCountStatic);
		}
    }
}
