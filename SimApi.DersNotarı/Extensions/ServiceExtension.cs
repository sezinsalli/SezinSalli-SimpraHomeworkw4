using Microsoft.Extensions.DependencyInjection;
using SimApi.Operation.Services;
using SimApi.Operation.Token;

namespace SimApi.sDersNotarı.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserLogService, UserLogService>();





        }
    }
}
