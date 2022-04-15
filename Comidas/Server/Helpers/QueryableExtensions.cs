using Comidas.Shared.DTO;

namespace Comidas.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacion paginacion)
        {
            return queryable.Skip(((paginacion.Pagina) - 1) * paginacion.CantidadRegistros).Take(paginacion.CantidadRegistros);
        }
    }
}
