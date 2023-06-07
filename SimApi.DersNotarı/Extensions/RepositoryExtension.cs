using Microsoft.Extensions.DependencyInjection;
using SimApi.Data.Repository;
using SimApi.Data.Repository.Dapper;

namespace SimApi.sDersNotarı.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositoryExtension(this IServiceCollection services)
        {
            
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionReportRepository, TransactionReportRepository>();

            
            


            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            

        }
    }
}
