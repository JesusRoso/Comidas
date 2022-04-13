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
        [HttpGet]
        public async Task<ActionResult<List<ComidasRapidas>>> Get()
        {
            return await context.ComidasRapidas.ToListAsync();
        }
        [HttpGet("buscar/{textoBusqueda}")]
        public async Task<ActionResult<List<ComidasRapidas>>> Get(string textoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<ComidasRapidas>(); }
            textoBusqueda = textoBusqueda.ToLower();
            return await context.ComidasRapidas.Where(x => x.titulo.ToLower().Contains(textoBusqueda)).ToListAsync(); //filta el resultado del titulo y revisa si contiene algo del string de textoBusqueda
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(ComidasRapidas comidasRapidas)
        {
            context.Add(comidasRapidas);
            await context.SaveChangesAsync();
            return comidasRapidas.Id;
        }
    }
}
