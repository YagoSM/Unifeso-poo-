using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using unifesopoo.Api.Core.Infrastructure.ClienteAgg.Repositories;
using unifesopoo.Api.Core.Domain.ClienteAgg.Repositories;
using unifesopoo.Api.Core.Application.ClienteAgg.AppServices;
using unifesopoo.Api.Core.Infrastructure.Shared;

namespace Av2.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLogging(builder => builder.AddSeq());
            services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Av2.api", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Av2.api.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddSingleton<IClienteRepositorio,ClienteRepositorio>();
            services.AddTransient<ClienteAppService>();
            services.AddSingleton<IClienteParseFactory, ClienteParseFactory>();
            services.AddDbContext<ClienteDbContext>(options =>{
                options.UseSqlite(Configuration.GetConnectionString("sqlite"));
            });
            services.AddScoped<IUnitOfWork>(provider=> provider.GetService<ClienteDbContext>());


            services.AddAuthentication(options =>
             {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
             {
                options.Authority = "https://unifesopooav2.us.auth0.com/";
                options.Audience = "https://unifeso-poo-api.com.br";
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ClienteDbContext dbContext, ILogger<Startup> logger, IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                logger.LogInformation("Application started");
            });
            
            applicationLifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Application stopping");
            });
            
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                logger.LogInformation("Application stopped");
            });

            if (env.IsDevelopment())
            {
                
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Av2.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors("all");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireAuthorization();
            });
        }
    }

    
}