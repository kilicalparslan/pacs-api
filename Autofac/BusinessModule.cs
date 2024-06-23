using Autofac;
using Autofac.Extras.AggregateService;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using pdksApi.Core.Utilities.Interceptors;
using pdksApi.Factories;
using pdksApi.Services.Interface;
using pdksApi.Services.Methods;
using System.Reflection;
using Module = Autofac.Module;

namespace pdksApi.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterType<AccessPointService>().As<IAccessPointService>().InstancePerLifetimeScope();
			builder.RegisterType<BranchService>().As<IBranchService>().InstancePerLifetimeScope();
			builder.RegisterType<CardService>().As<ICardService>().InstancePerLifetimeScope();
			builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
			builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
			builder.RegisterType<CountyService>().As<ICountyService>().InstancePerLifetimeScope();
			builder.RegisterType<CountryService>().As<ICountryService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeCardService>().As<IEmployeeCardService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeLanguageService>().As<IEmployeeLanguageService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeLeaveService>().As<IEmployeeLeaveService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeReferanceService>().As<IEmployeeReferanceService>().InstancePerLifetimeScope();
			builder.RegisterType<EmployeeTitleService>().As<IEmployeeTitleService>().InstancePerLifetimeScope();
			builder.RegisterType<GroupService>().As<IGroupService>().InstancePerLifetimeScope();
			builder.RegisterType<LanguageService>().As<ILanguageService>().InstancePerLifetimeScope();
			builder.RegisterType<LevelService>().As<ILevelService>().InstancePerLifetimeScope();
			builder.RegisterType<RevisedLeaveService>().As<IRevisedLeaveService>().InstancePerLifetimeScope();
			builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
			builder.RegisterType<SizeService>().As<ISizeService>().InstancePerLifetimeScope();
			builder.RegisterType<TitleService>().As<ITitleService>().InstancePerLifetimeScope();
			builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
			builder.RegisterType<UserRoleService>().As<IUserRoleService>().InstancePerLifetimeScope();  
			

			builder.RegisterAggregateService<IRepositoryFactory>();

            #region Aspect
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance().InstancePerDependency();
            #endregion
        }
    }
}
