using Microsoft.EntityFrameworkCore;

namespace Comidas.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnRespuesta<T>(this HttpContext context,
                                                                            IQueryable<T> queryable, int cantidadRegistrosMostrar) //se va a encargar de insertar la información de paginación en la cabecera de una respuesta http                                                                          
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            double conteo = await queryable.CountAsync(); //con esto se hace un conteo de todos los registros de la tabla
            double totalPaginas = Math.Ceiling(conteo / cantidadRegistrosMostrar);
            context.Response.Headers.Add("conteo", conteo.ToString());
            context.Response.Headers.Add("totalPaginas", totalPaginas.ToString());
        }
    }
}
