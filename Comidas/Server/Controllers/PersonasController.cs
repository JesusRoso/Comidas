using Comidas.Server.Helpers;
using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comidas.Shared.DTO;

namespace Comidas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Persona>>> Get()
        //{
        //    return await context.Persona.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Persona.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var persona = await context.Persona.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null) { return NotFound(); }

            return persona;
        }
        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            context.Attach(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Persona.AnyAsync(x => x.Id == id);
            if (!existe) { return NotFound(); }
            context.Remove(new Persona { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
