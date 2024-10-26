using System.Net.Http;
using Autofac;
using CryptoMarket.Bootstrapper.Factories;
using CryptoMarket.Domain.Factories;
using CryptoMarket.Views.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoMarket.Bootstrapper;

public class RegistrationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterType<WindowFactory>().As<IWindowFactory>().SingleInstance();
        builder.Register(context =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddHttpClient()
                    .BuildServiceProvider();

                var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

                return httpClientFactory;
            })
            .SingleInstance();
        builder.RegisterGeneric(typeof(Factory<>)).As(typeof(IFactory<>)).SingleInstance();
    }
}