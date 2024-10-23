using System.Windows.Input;
using CryptoMarket.Domain.Settings;
using CryptoMarket.ViewModels.Commands;
using CryptoMarket.ViewModels.Windows;

namespace CryptoMarket.ViewModels.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    private readonly Command _closeMainWindowCommand;
    private readonly IMainWindowMementoWrapper _mainWindowMementoWrapper;
    private readonly IWindowManager _windowManager;

    public MainWindowViewModel(
        IMainWindowMementoWrapper mainWindowMementoWrapper,
        IWindowManager windowManager)
    {
        _mainWindowMementoWrapper = mainWindowMementoWrapper;
        _windowManager = windowManager;

        _closeMainWindowCommand = new Command(CloseMainWindow);
    }

    public double Left
    {
        get => _mainWindowMementoWrapper.Left;
        set => _mainWindowMementoWrapper.Left = value;
    }

    public double Width
    {
        get => _mainWindowMementoWrapper.Width;
        set => _mainWindowMementoWrapper.Width = value;
    }

    public double Top
    {
        get => _mainWindowMementoWrapper.Top;
        set => _mainWindowMementoWrapper.Top = value;
    }

    public double Height
    {
        get => _mainWindowMementoWrapper.Height;
        set => _mainWindowMementoWrapper.Height = value;
    }

    public bool IsMaximized
    {
        get => _mainWindowMementoWrapper.IsMaximized;
        set => _mainWindowMementoWrapper.IsMaximized = value;
    }

    public string Title => "Crypto Market";

    public ICommand CloseMainWindowCommand => _closeMainWindowCommand;

    private void CloseMainWindow()
    {
        _windowManager.Close(this);
    }
}