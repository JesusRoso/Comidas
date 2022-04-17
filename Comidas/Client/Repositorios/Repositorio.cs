using System.Text;
using System.Text.Json;
using Comidas.Shared.Entidades;

namespace Comidas.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient; //sirve para tener una calse especializada para realizar peticiones http

        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        private JsonSerializerOptions OpcionesPorDefectoJSON => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };//Proporciona funcionalidad para serializar objetos o tipos de valores en JSON y para deserializar JSON en objetos o tipos de valores
        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if(responseHTTP.IsSuccessStatusCode)
            {
                var response = await DeserializarRespuesta<T>(responseHTTP, OpcionesPorDefectoJSON);
                return new HttpResponseWrapper<T>(response, false, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, true, responseHTTP);
            }
        }
        private async Task<T> DeserializarRespuesta<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }

        //método para crear
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        //Método para editar
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PutAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        //Método para borrar
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, !responseHTTP.IsSuccessStatusCode, responseHTTP);
        }
        public List<ComidasRapidas> ObtenerComidas()
        {
            return new List<ComidasRapidas>()
            {
                //new ComidasRapidas(){titulo = "Perro Caliente",precio = 2500},
                //new ComidasRapidas(){titulo = "Hamburguesa",precio = 8500},
                //new ComidasRapidas(){titulo = "Pizza",precio = 4500},
                //new ComidasRapidas(){titulo = "Salchipapa",precio = 6500}
            };
        }
    }
}
