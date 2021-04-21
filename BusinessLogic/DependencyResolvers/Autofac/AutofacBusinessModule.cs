using Autofac;
using BusinessLogic.Abstract;
using BusinessLogic.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts.EntityFramework;
using EVDS.Services.Abstraction;
using EVDS.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrencyManager>().As<ICurrencyService>();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>();
            builder.RegisterType<EvdsService>().As<IEvdsService>();

        }
    }
}
