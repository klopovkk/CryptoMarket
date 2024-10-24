using System.Configuration;
using System.Data;
using System.Windows;
namespace CryptoMarket
{
    public partial class App 
    {
        private Bootstrapper.Bootstrapper _bootstrapper;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

           _bootstrapper = new Bootstrapper.Bootstrapper();
           MainWindow = await _bootstrapper.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _bootstrapper.Dispose();

            base.OnExit(e);
        }
    }
}
