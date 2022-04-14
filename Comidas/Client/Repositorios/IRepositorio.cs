using Comidas.Shared.Entidades;

namespace Comidas.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        List<ComidasRapidas> ObtenerComidas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T enviar);
    }
}
