using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Comidas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComidasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ComidasController(ApplicationDbContext context)
        {
            this.context = context;
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
