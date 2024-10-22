using CryptoMarket.Views;
using System.Windows;
using System.Windows.Automation.Peers;

namespace CryptoMarket.Bootstrapper
{
    public class Bootstrapper : IDisposable
    {
        public Window  Run ()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            return mainWindow;
        }
        public void Dispose() { }
    }
}
