using Crea.SporHojam.ApplicationProcess.Api.Model.Mapping;
using Crea.SporHojam.ApplicationProcess.Domain.Interfaces;
using Crea.SporHojam.ApplicationProcess.Domain.Services;
using Crea.SporHojam.ApplicationProcess.Infrastructure;
using Crea.SporHojam.ApplicationProcess.Infrastructure.Repositories;
using Crea.SporHojam.Domain.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Crea.SporHojam.ApplicationProcess.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IUnitOfWork, ApplicationContext>(b =>
                 b.UseNpgsql(Configuration["ConnectionString"]));

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    x => x
                        .SetIsOriginAllowed((_) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Crea.SporHojam.Api", Version = "v1" });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Crea.SporHojam.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
