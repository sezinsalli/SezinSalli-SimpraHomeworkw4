using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SimApi.Base.Jwt;
using SimApi.Base.Logger;
using SimApi.Data.UnitOfWork;
using SimApi.DersNotarı.Extensions;
using SimApi.Operation.Services;
using SimApi.sDersNotarı.Extensions;
using SimApi.sDersNotarı.Middleware;
using SimApi.Service.Middleware;
using System;


namespace SimApi.DersNotarı
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        public IConfiguration Configuration { get; }
        public static JwtConfig JwtConfig { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            //1.adım için
            services.AddSwaggerGen();
            services.AddDbContextExtension(Configuration);

            

            //services.AddScoped<IUnitofWork,UnitOfWork>();
            services.AddMapperExtension();
            
            //services.AddRepositoryExtension();
            //services.AddServiceExtension();
            
            services.AddJwtExtension();
            services.AddCustomSwaggerExtension();

            //services.AddScoped<ITransactionService, TransactionService>();
            //services.AddScoped<ITransactionReportService, TransactionReportService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimApi.DersNotarı v1"));
            }

            
            //DI

            

            app.UseMiddleware<HeartBeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            

            Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
            {
                Log.Information("-------------Request-Begin------------");
                Log.Information(requestProfilerModel.Request);
                Log.Information(Environment.NewLine);
                Log.Information(requestProfilerModel.Response);
                Log.Information("-------------Request-End------------");
            };
            app.UseMiddleware<RequestLoggingMiddleware>(requestResponseHandler);

            app.UseHttpsRedirection();

            // add auth 
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
