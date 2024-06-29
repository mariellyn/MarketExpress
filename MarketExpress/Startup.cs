using System.Collections.Generic;
using System.Globalization;
using MarketExpress.Data;
using MarketExpress.Helper;
using MarketExpress.Repository;
using MarketExpress.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MarketExpress
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
            services.AddControllersWithViews()
                    .AddViewLocalization(); // Adiciona suporte para localização de views

            // Configuração do banco de dados
            services.AddDbContext<BancoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            // Registro dos serviços de repositório
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Registro dos serviços de helpers
            services.AddScoped<ISection, Section>();
            services.AddScoped<IEmail, Email>();

            // Registro do HttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Registro do SharedResourceService
            services.AddSingleton<SharedResource>();

            // Configuração da sessão
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Configuração da localização e internacionalização
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("pt-BR")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR")
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

