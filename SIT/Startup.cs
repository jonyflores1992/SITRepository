using SIT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIT.IService;
using SIT.Service;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SIT
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
            services.AddControllers().AddNewtonsoftJson(options => {
              options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
            
            services.AddScoped<SIT.Models.UserContext>();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDIzNzU0QDMxMzkyZTMxMmUzMGlPRjlSc1ZuRWIvVWh6Q2I5MGM5NW84UFAwRVFhczZaNDR6MExaK25YUlU9;NDIzNzU1QDMxMzkyZTMxMmUzMGY2NGNPbis4b29xd2p3NGRwb3ZZRTN3SFVGWHJlUHgzNEVBU3lseGo1c2s9;NDIzNzU2QDMxMzkyZTMxMmUzMGNMNzd5K2JuOVlYcHJPUmhBNzVxT1RjZlpOM3JlQUtvN3lsWGdPMmVPNnc9");
            services.AddControllersWithViews();
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddSession();
            services.AddDbContext<SIT.Models.UserContext>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddControllersWithViews().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            // Make sure a JS engine is registered, or you will get an error!
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
              .AddV8();

            services.AddSwaggerGen();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                config
                  .AddScript("~/js/Componente.jsx")
                  .AddScript("~/React/Components/AddProduccion.tsx")
                .AddScript("~/React/Components/FetchProduccion.tsx");
                //  .AddScript("~/js/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            });
    
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseSwagger();
            //app.UseSwaggerUi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
