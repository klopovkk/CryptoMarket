using Autofac;
using CryptoMarket.ViewModels.Windows;
using CryptoMarket.Views.MainWindow;
using CryptoMarket.Views.Windows;

namespace CryptoMarket.Views;

public class RegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<MainWindow.MainWindow>().As<IMainWindow>().InstancePerDependency();
        builder.RegisterType<WindowsManager>().As<IWindowManager>().SingleInstance();
    }
}