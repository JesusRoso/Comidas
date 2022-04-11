using Comidas.Shared.Entidades;

namespace Comidas.Client.Repositorios
{
    public interface IRepositorio
    {
        List<ComidasRapidas> ObtenerComidas();
        Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
    }
}
