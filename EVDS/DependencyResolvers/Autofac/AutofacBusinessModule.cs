using Autofac;
using EVDS.Services.Concrete;

namespace BusinessLogic.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
        }
    }
}
