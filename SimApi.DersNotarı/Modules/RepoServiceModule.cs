using Autofac;
using Autofac.Core;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using SimApi.Data.UnitOfWork;
using SimApi.Operation.Services;
using SimApi.Schema.Mapper;
using System.Reflection;
using Module = Autofac.Module;
namespace SimApi.sDersNotarı.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Generic olduğu için bu şekilde belirttik.
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseService<,,>)).As(typeof(IBaseService<,,>)).InstancePerLifetimeScope();
            //Generic değil o yüzden type olarak ekledik.
            builder.RegisterType<UnitOfWork>().As<IUnitofWork>();

            //Bunun anlamı da bulunduğun klasörde ara demek
            var apiAssembly = Assembly.GetExecutingAssembly();
            //Repo katmanındaki herhangi bir classı typeof içine verebiliriz. Bu şekilde diğerlerini kendisi bulacaktır.
            var repoAssembly = Assembly.GetAssembly(typeof(UserRepository));
            //Service katmanındaki herhangi bir classı typeof içine verebiliriz. Bu şekilde diğerlerini kendisi bulacaktır.
            var serviceAssembly = Assembly.GetAssembly(typeof(UserService));

            //InstancePerLifetimeScope => Scope a karşılık gelir.
            //InstancePerDependency => Transient a karşılık gelir.
            //Burada şunu demek istiyoruz, bu verilen Assembly'lere git ve sonu Repository ile bitenlerin Scope olarak instance'ını al. builder.Services.AddScoped<IProductRepository, ProductRepository>(); => bu yazdığımızı tüm repository yerine tek tek yazmak yerine bu şekilde bütün hepsi için Scope olarak instance alıyoruz.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            






        }

    }

}
