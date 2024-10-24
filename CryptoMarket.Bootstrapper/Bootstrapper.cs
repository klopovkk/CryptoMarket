using System.Windows;
using Autofac;
using CryptoMarket.Infrastructure.Settings;
using CryptoMarket.ViewModels.MainWindow;
using CryptoMarket.ViewModels.Windows;
using CryptoMarket.Views.MainWindow;

namespace CryptoMarket.Bootstrapper;

public class Bootstrapper : IDisposable
{
    private readonly IContainer _container;

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

    public void Dispose()
    {
        _container.Dispose();
    }

    public async Task<Window> Run()
    {
        await InitializeDependenciesAsync();

        var mainWindowViewModel = _container.Resolve<IMainWindowViewModel>();
        var windowManager = _container.Resolve<IWindowManager>();

       var mainWindow = windowManager.Show(mainWindowViewModel);

        if (mainWindow is not Window window)
            throw new NotImplementedException();

        return window;
    }

    private async Task InitializeDependenciesAsync()
    {
       await _container.Resolve<IMainWindowMementoWrapperInitializer>().InitializeAsync();
    }
}