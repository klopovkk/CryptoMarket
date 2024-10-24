using Autofac;
using CryptoMarket.Domain.Rest;
using CryptoMarket.Domain.Settings;
using CryptoMarket.Infrastructure.Common;
using CryptoMarket.Infrastructure.Rest;
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
                .As<IWindowMementoWrapperInitializer>()
                .SingleInstance();

            builder.RegisterType<PathService>()
                .As<IPathService>()
                .As<IPathServiceInitializer>()
                .SingleInstance();

            builder.RegisterType<ApiRequestExecutor>().As<IApiRequestExecutor>().SingleInstance();
        }
    }
}