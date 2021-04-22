using Autofac;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using EVDS.Services.Abstraction;
using EVDS.Services.Concrete;

namespace BusinessLogic.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();

            builder.RegisterType<CurrencyRatingManager>().As<ICurrencyRatingService>();
            builder.RegisterType<EfCurrencyRatingDal>().As<ICurrencyRatingDal>();

            builder.RegisterType<EvdsService>().As<IEvdsService>();

        }
    }
}
