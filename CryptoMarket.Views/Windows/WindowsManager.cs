using CryptoMarket.ViewModels.Windows;
using CryptoMarket.Views.Factories;

namespace CryptoMarket.Views.Windows;

public class WindowsManager : IWindowManager
{
    private readonly Dictionary<IWindowViewModel, IWindow> _viewModelToWindowMap = new();
    private readonly IWindowFactory _windowFactory;

    public WindowsManager(IWindowFactory windowFactory)
    {
        _windowFactory = windowFactory;
    }

    public IWindow Show<TWindowViewModel>(TWindowViewModel viewModel)
        where TWindowViewModel : IWindowViewModel
    {
        var window = _windowFactory.Create(viewModel);

        _viewModelToWindowMap.Add(viewModel, window);

        window.Show();

        return window;
    }

    public void Close<TWindowViewModel>(TWindowViewModel viewModel)
        where TWindowViewModel : IWindowViewModel
    {
        if (_viewModelToWindowMap.TryGetValue(viewModel, out var window))
        {
            window.Close();
            _viewModelToWindowMap.Remove(viewModel);
        }
    }
}