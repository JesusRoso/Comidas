using Comidas.Server.Helpers;
using Comidas.Shared.DTO;
using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comidas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComidasRapidasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ComidasRapidasController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //paginación
        [HttpGet]
        public async Task<ActionResult<List<ComidasRapidas>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.ComidasRapidas.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }
        //filtrar info
        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<ComidasRapidas>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<ComidasRapidas>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.ComidasRapidas.Where(x => x.titulo.ToLower().Contains(textoBusqueda)).ToListAsync(); //filta el resultado del titulo y revisa si contiene algo del string de textoBusqueda
        }


        //editar info
        [HttpGet("{id}")]
        public async Task<ActionResult<ComidasRapidas>> Get(int id)
        {
            return await context.ComidasRapidas.FirstOrDefaultAsync(x => x.Id == id); //obtener una comida a través de su Id
        }
        [HttpPut]
        public async Task<ActionResult> Put(ComidasRapidas comidasRapidas)
        {
            context.Attach(comidasRapidas).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        //agg info
        [HttpPost]
        public async Task<ActionResult<int>> Post(ComidasRapidas comidasRapidas)
        {
            context.Add(comidasRapidas);
            await context.SaveChangesAsync();
            return comidasRapidas.Id;
        }
        //eliminar info
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.ComidasRapidas.AnyAsync(x => x.Id == id);
            if(!existe){ return NotFound(); }
            context.Remove(new ComidasRapidas { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
