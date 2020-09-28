using Agridoce.Infra.Data.Configurations;
using Agridoce.Infra.Data.Context;
using Agridoce.Services.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<AgridoceContext>(options =>
                  options.UseSqlServer(ConnectionStringConfiguration.ConnectionString()));

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }

       
    }
}
