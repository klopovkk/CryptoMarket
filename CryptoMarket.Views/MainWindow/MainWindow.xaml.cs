using CryptoMarket.ViewModels.MainWindow;

namespace CryptoMarket.Views.MainWindow
{
    public partial class MainWindow : IMainWindow
    {
        public MainWindow(IMainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
        }
    }
}