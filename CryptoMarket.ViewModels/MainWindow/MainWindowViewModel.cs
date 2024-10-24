using System.Windows.Input;
using CryptoMarket.Domain.Settings;
using CryptoMarket.ViewModels.Commands;
using CryptoMarket.ViewModels.Windows;

namespace CryptoMarket.ViewModels.MainWindow;

public abstract class WindowViewModel
{
}

public class MainWindowViewModel : WindowViewModel<IMainWindowMementoWrapper>, IMainWindowViewModel
{
    private readonly Command _closeMainWindowCommand;
    private readonly IWindowManager _windowManager;

    public MainWindowViewModel(
        IMainWindowMementoWrapper mainWindowMementoWrapper,
        IWindowManager windowManager)
        : base(mainWindowMementoWrapper)
    {
        _windowManager = windowManager;

        _closeMainWindowCommand = new Command(CloseMainWindow);
    }

    public string Title => "Crypto Market";

    public ICommand CloseMainWindowCommand => _closeMainWindowCommand;

    private void CloseMainWindow()
    {
        _windowManager.Close(this);
    }
}