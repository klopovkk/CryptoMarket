using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CryptoMarket.Views.MainWindow;

namespace CryptoMarket.Views
{
    public class RegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MainWindow.MainWindow>().As<IMainWindow>().InstancePerDependency();
        }
    }
}
