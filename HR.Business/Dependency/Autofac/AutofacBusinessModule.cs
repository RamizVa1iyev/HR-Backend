using Autofac;
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
            builder.RegisterType<EfCalendarDayRepository>().As<ICalendarDayRepository>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<EfDiseaseBulletenRepository>().As<IDiseaseBulletenRepository>().SingleInstance();

            #endregion

            #region Business

            builder.RegisterType<StateManager>().As<IStateService>().SingleInstance();
            builder.RegisterType<CalendarDayManager>().As<ICalendarDayService>().SingleInstance();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<DiseaseBulletenManager>().As<IDiseaseBulletenService>().SingleInstance();

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
