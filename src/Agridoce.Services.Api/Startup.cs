using Agridoce.Services.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Agridoce.Services.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", true, true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration);

            // ASP.NET Identity Settings
            services.AddIdentityConfiguration();

            // JWT
            services.AddTokenConfiguration(Configuration);

            // Claim
            services.AddClaimConfiguration(Configuration);

            // WebAPI Config
            services.AddControllers();

            // Swagger Config
            services.AddSwaggerConfiguration();

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // MediatR config
            services.AddMediatRConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();


            //Filter
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));

            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }


    }
}
