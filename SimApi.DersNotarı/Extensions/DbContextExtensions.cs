using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimApi.Data.Context;

namespace SimApi.DersNotarı.Extensions
{
    //1adım CUstom Swagger Extensions
    public static class DbContextExtensions
    {
        //tek bır dbcontext'ı hem mssql hemde postgresql ıcın kullanabılırız.
       public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<SimDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            else if (dbType == "PostgreSql")
            {
                var dbConfig = Configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<SimDbContext>(opts =>
                  opts.UseNpgsql(dbConfig));
            }

            services.AddScoped<SimDapperDbContext>();
        }
    }
}
