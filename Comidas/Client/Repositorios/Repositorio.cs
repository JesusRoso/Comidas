using System.Text;
using System.Text.Json;
using Comidas.Shared.Entidades;

namespace Comidas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }
        public List<ComidasRapidas> ObtenerComidas()
        {
            return new List<ComidasRapidas>()
        {
            new ComidasRapidas(){titulo = "Perro Caliente",precio = 2500},
            new ComidasRapidas(){titulo = "Hamburguesa",precio = 8500},
            new ComidasRapidas(){titulo = "Pizza",precio = 4500},
            new ComidasRapidas(){titulo = "Salchipapa",precio = 6500}
        };
        }
    }
}
