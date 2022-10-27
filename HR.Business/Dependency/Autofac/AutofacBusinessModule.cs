using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Business.Abstract;
using Core.Business.Concrete;
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
            builder.RegisterType<EfEmployeeRepository>().As<IEmployeeRepository>().SingleInstance();
            builder.RegisterType<EfDiseaseBulletenRepository>().As<IDiseaseBulletenRepository>().SingleInstance();
            builder.RegisterType<EfVacationRepository>().As<IVacationRepository>().SingleInstance();
            builder.RegisterType<EfOvertimeRepository>().As<IOvertimeRepository>().SingleInstance();
            builder.RegisterType<EfPermissionRepository>().As<IPermissionRepository>().SingleInstance();
            builder.RegisterType<EfRewardRepository>().As<IRewardRepository>().SingleInstance();
            builder.RegisterType<EfEmployeeRewardRepository>().As<IEmployeeRewardRepository>().SingleInstance();
            builder.RegisterType<EfUserKeyRepository>().As<IUserKeyRepository>().SingleInstance();

            #endregion

            #region Business

            builder.RegisterType<StateManager>().As<IStateService>().SingleInstance();
            builder.RegisterType<CalendarDayManager>().As<ICalendarDayService>().SingleInstance();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<DiseaseBulletenManager>().As<IDiseaseBulletenService>().SingleInstance();
            builder.RegisterType<VacationManager>().As<IVacationService>().SingleInstance();
            builder.RegisterType<OvertimeManager>().As<IOvertimeService>().SingleInstance();
            builder.RegisterType<PermissionManager>().As<IPermissionService>().SingleInstance();
            builder.RegisterType<RewardManager>().As<IRewardService>().SingleInstance();
            builder.RegisterType<EmployeeRewardManager>().As<IEmployeeRewardService>().SingleInstance();
            builder.RegisterType<UserKeyManager>().As<IUserKeyService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

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
