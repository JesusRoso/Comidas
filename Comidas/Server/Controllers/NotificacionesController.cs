
using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Comidas.Server.Controllers
{
    [Route("api/notificaciones")]
    [ApiController]
    public class NotificacionesController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public NotificacionesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost("suscribir")]
        public async Task<ActionResult> Suscribir(Notificacion notificacion)
        {
            context.Add(notificacion);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("desuscribir")]
        public async Task<ActionResult> Desuscribir(Notificacion notificacion)
        {
            var notificacionDB = context.Notificaciones
                .FirstOrDefault(x => x.Auth == notificacion.Auth && x.P256dh == notificacion.P256dh);

            if (notificacionDB == null) { return NotFound(); }

            context.Remove(notificacionDB);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
