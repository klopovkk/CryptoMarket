using Autofac;
using Autofac.Core;
using CryptoMarket.Bootstrapper.Factories;
using CryptoMarket.ViewModels.Windows;
using CryptoMarket.Views.Factories;

namespace CryptoMarket.Bootstrapper;

public class RegistrationModule :Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<WindowFactory>().As<IWindowFactory>().SingleInstance();
    }
}