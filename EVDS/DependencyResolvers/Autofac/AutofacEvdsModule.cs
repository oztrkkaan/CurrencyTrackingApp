using Autofac;
using EVDS.Services.Abstraction;
using EVDS.Services.Concrete;

namespace EVDS.DependencyResolvers.Autofac
{
    public class AutofacEvdsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EvdsCurrencyManager>().As<IEvdsCurrencyService>();
        }
    }
}
