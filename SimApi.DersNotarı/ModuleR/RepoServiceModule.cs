//using Autofac;
//using Autofac.Core;
//using SimApi.Data.Context;
//using SimApi.Data.Repository;
//using SimApi.Data.Repository.Dapper;
//using SimApi.Data.UnitOfWork;
//using SimApi.Schema.Mapper;
//using System;
//using System.Reflection;
//using Module = Autofac.Module;

//namespace SimApi.sDersNotarı.ModuleR
//{
//    public class RepoServiceModule:Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
//            builder.RegisterGeneric(typeof(DapperRepository<>)).As(typeof(IDapperRepository<>)).InstancePerLifetimeScope();


//            //builder.RegisterGeneric(typeof(DapperService<>)).As(typeof(IDapperService<>)).InstancePerLifetimeScope();
//            //builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
//            //services.AddScoped<IUnitofWork, UnitOfWork>();
            
//            builder.RegisterType<UnitOfWork>().As<IUnitofWork>();

           
            
//            var apiAssembly=Assembly.GetExecutingAssembly();

//            var repoAssembly = Assembly.GetAssembly(typeof(AppContext));
//            var repoAssembly2 = Assembly.GetAssembly(typeof(SimDapperDbContext));            
//            var serviceAssembly=Assembly.GetAssembly(typeof(MapperProfile));


//            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, repoAssembly2).Where(x => x.FullName.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();



//            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, repoAssembly2).Where(x => x.FullName.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            



            
//        }
//    }
//}
