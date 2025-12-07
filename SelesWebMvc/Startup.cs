using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelesWebMvc.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using SelesWebMvc.Services;

namespace SelesWebMvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configura os serviços do projeto
        public void ConfigureServices(IServiceCollection services)
        {
            // Pega a connection string do appsettings.json
            var connectionString = Configuration.GetConnectionString("SelesWebMvcContext");

            // Configura o DbContext com MySQL
            services.AddDbContext<SelesWebMvcContext>(options =>
                options.UseMySql(
                    connectionString,
                    mysqlOptions => mysqlOptions.ServerVersion(
                        new Version(8, 0, 32), ServerType.MySql)));

            // Registra o SeedingService para popular o banco
            services.AddScoped<SeedingService>();

            // Registrar SellerService
            services.AddScoped<SellerService>();

            services.AddMvc(); // ou AddControllersWithViews()
        }

        // Configura o pipeline HTTP
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
