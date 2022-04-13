using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Persona.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }
    }
}
