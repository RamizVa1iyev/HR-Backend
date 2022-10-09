﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Features.Interceptors;
using HR.Business.Abstract;
using HR.Business.Concrete;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework;

namespace HR.Business.Dependency.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region DataAccess

            builder.RegisterType<EfStateRepository>().As<IStateRepository>().SingleInstance();

            #endregion

            #region Business

            builder.RegisterType<StateManager>().As<IStateService>().SingleInstance();

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                    .EnableInterfaceInterceptors(new ProxyGenerationOptions
                    {
                        Selector = new AspectInterceptorSelector()
                    }).SingleInstance();
        }
    }
}
