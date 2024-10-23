using Autofac;
using CryptoMarket.Domain.Settings;
using CryptoMarket.Infrastructure.Settings;

namespace CryptoMarket.Infrastructure
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MainWindowMementoWrapper>()
                .As<IMainWindowMementoWrapper>()
                .As<IMainWindowMementoWrapperInitializer>()
                .SingleInstance();
        }
    }
}
