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

            builder.RegisterType<EfStateRepository>().As<IStateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfCalendarDayRepository>().As<ICalendarDayRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfEmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfDiseaseBulletenRepository>().As<IDiseaseBulletenRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfVacationRepository>().As<IVacationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfOvertimeRepository>().As<IOvertimeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfPermissionRepository>().As<IPermissionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfRewardRepository>().As<IRewardRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfEmployeeRewardRepository>().As<IEmployeeRewardRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserKeyRepository>().As<IUserKeyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfContractRepository>().As<IContractRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfNotificationRepository>().As<INotificationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EfDutyRepository>().As<IDutyRepository>().InstancePerLifetimeScope();

            #endregion

            #region Business

            builder.RegisterType<StateManager>().As<IStateService>().InstancePerLifetimeScope();
            builder.RegisterType<CalendarDayManager>().As<ICalendarDayService>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<DiseaseBulletenManager>().As<IDiseaseBulletenService>().InstancePerLifetimeScope();
            builder.RegisterType<VacationManager>().As<IVacationService>().InstancePerLifetimeScope();
            builder.RegisterType<OvertimeManager>().As<IOvertimeService>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionManager>().As<IPermissionService>().InstancePerLifetimeScope();
            builder.RegisterType<RewardManager>().As<IRewardService>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRewardManager>().As<IEmployeeRewardService>().InstancePerLifetimeScope();
            builder.RegisterType<UserKeyManager>().As<IUserKeyService>().InstancePerLifetimeScope();
            builder.RegisterType<ContractManager>().As<IContractService>().InstancePerLifetimeScope();
            builder.RegisterType<NotificationManager>().As<INotificationService>().InstancePerLifetimeScope();
            builder.RegisterType<DutyManager>().As<IDutyService>().InstancePerLifetimeScope();
            builder.RegisterType<NotificationHelperManager>().As<INotificationHelperService>().InstancePerLifetimeScope();

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                    .EnableInterfaceInterceptors(new ProxyGenerationOptions
                    {
                        Selector = new AspectInterceptorSelector()
                    }).InstancePerLifetimeScope();
        }
    }
}
