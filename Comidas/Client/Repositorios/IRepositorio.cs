using Comidas.Shared.Entidades;

namespace Comidas.Client.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        List<ComidasRapidas> ObtenerComidas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
