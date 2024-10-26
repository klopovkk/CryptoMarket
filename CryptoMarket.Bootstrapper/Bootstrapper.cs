using System.Windows;
using Autofac;
using CryptoMarket.Domain.Factories;
using CryptoMarket.Infrastructure.Common;
using CryptoMarket.Infrastructure.Settings;
using CryptoMarket.ViewModels.MainWindow;
using CryptoMarket.ViewModels.Windows;

namespace CryptoMarket.Bootstrapper;

public class Bootstrapper : IDisposable
{
    private readonly IContainer _container;

    private IMainWindowViewModel _mainWindowViewModel;

    public Bootstrapper()
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder
            .RegisterModule<Infrastructure.RegistrationModule>()
            .RegisterModule<Views.RegistrationModule>()
            .RegisterModule<ViewModels.RegistrationModule>()
            .RegisterModule<RegistrationModule>();

        _container = containerBuilder.Build();
    }

    public async Task<Window> Run()
    {
        await InitializeDependenciesAsync();

        var mainWindowViewModelFactory = _container.Resolve<IFactory<IMainWindowViewModel>>();
        _mainWindowViewModel = mainWindowViewModelFactory.Create();
        var windowManager = _container.Resolve<IWindowManager>();

        var mainWindow = windowManager.Show(_mainWindowViewModel);

        if (mainWindow is not Window window)
            throw new NotImplementedException();

        return window;
    }

    private async Task InitializeDependenciesAsync()
    {
        _container.Resolve<IPathServiceInitializer>().Initialize();

        var windowMementoWrapperInitializer = _container.Resolve<IEnumerable<IWindowMementoWrapperInitializer>>();
        foreach (var window in windowMementoWrapperInitializer) await window.InitializeAsync();
    }

    public void Dispose()
    {
        _container.Dispose();
    }
}