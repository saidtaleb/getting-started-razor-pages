namespace WiredBrainCoffee
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Diagnostics;
    using WiredBrainCoffee.Services;

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
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/index", "home");
                options.Conventions.AddPageRoute("/index", "wired");
            });

            services.Configure<RouteOptions>(config =>
            {
                config.ConstraintMap.Add("promo", typeof(PromoConstraint));
            });

            // register services
            services.AddScoped<IMenuService, MenuService>();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("alive"))
                {
                    await context.Response.WriteAsync("the application is alive");
                }
                else
                {
                    Debug.WriteLine("Before Razor pages");
                    await next.Invoke();
                    Debug.WriteLine("After Razor pages");
                }
            });

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
