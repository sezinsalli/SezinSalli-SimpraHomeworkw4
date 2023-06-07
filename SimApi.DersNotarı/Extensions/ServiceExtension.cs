﻿using Microsoft.Extensions.DependencyInjection;
using SimApi.Operation.DapperS;
using SimApi.Operation.Services;
using SimApi.Operation.Token;

namespace SimApi.sDersNotarı.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServiceExtension(this IServiceCollection services)
        {

            services.AddScoped<IUserLogService, UserLogService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAccountService, AccountService>();
            //services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped(typeof(IDapperService<,,>), typeof(DapperService<,,>));







        }
    }
}
