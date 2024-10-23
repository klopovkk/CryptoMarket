using CryptoMarket.ViewModels.Windows;

namespace CryptoMarket.Views.Factories;

public interface IWindowFactory
{
    IWindow Create<TWindowViewModel>(TWindowViewModel viewModel)
        where TWindowViewModel : IWindowViewModel;
}