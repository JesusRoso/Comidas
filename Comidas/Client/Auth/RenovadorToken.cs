using System.Timers;
namespace Comidas.Client.Auth
{
    public class RenovadorToken : IDisposable
    {
        public RenovadorToken(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        System.Timers.Timer timer;
        private readonly ILoginService loginService;

        public void Iniciar()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000*60*4; // 4 minutos
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            loginService.ManejarRenovacionToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
