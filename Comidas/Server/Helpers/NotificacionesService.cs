using System.Text.Json;
using Comidas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;
using WebPush;

namespace Comidas.Server.Helpers
{
    public class NotificacionesService
    {
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;

        public NotificacionesService(IConfiguration configuration, ApplicationDbContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public async Task EnviarNotificacionPeliculaEnCartelera(ComidasRapidas comidasRapidas)
        {
            var notificaciones = await context.Notificaciones.ToListAsync();

            var llavePublica = configuration.GetValue<string>("notificaciones:llave_publica");
            var llavePrivada = configuration.GetValue<string>("notificaciones:llave_privada");
            var email = configuration.GetValue<string>("notificaciones:email");

            var vapidDetails = new VapidDetails(email, llavePublica, llavePrivada);

            foreach (var notificacion in notificaciones)
            {
                var pushSubscription = new PushSubscription(notificacion.URL,
                    notificacion.P256dh, notificacion.Auth);

                var webPushClient = new WebPushClient();

                try
                {
                    Console.WriteLine("");
                    var payload = JsonSerializer.Serialize(new
                    {
                        titulo = comidasRapidas.titulo,
                        precio = comidasRapidas.precio,
                        url = $"alimentos"
                    });

                    await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // ...
                }
            }

        }
    }
}
