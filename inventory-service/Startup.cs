using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Logging;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace InventoryService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Log = logger;
        }

        public IConfiguration Configuration { get; }
        public ILogger<Startup> Log { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var optionsBuilder = ConfigurePostgreSQLConnection();

            services.AddSingleton<InventoryContext>(_ => new InventoryContext(optionsBuilder.Options));
            services.AddScoped<IInventorySvc, InventorySvc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private DbContextOptionsBuilder<InventoryContext> ConfigurePostgreSQLConnection() {
            string db_service_prefix_mapping = Environment.GetEnvironmentVariable("APPLICATION_NAME"); // in coolstuff-store this is "${APPLICATION_NAME}-posgresql=DB"
            string db_jndi = Environment.GetEnvironmentVariable("DB_JNDI"); //in coolstuff-store this is set to "java:jboss/datasources/InventoryDS";
            string db_username = Environment.GetEnvironmentVariable("DB_USERNAME");
            string db_password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string db_database = Environment.GetEnvironmentVariable("DB_DATABASE");

            string db_host = db_jndi;
            if (string.IsNullOrWhiteSpace(db_jndi)) {
                db_host = "localhost";
                Log.LogInformation("DB_JNDI environmental variable is not set, using {0}", db_host);
            }

            if(string.IsNullOrWhiteSpace(db_database)) {
                db_database = "inventory";
                Log.LogInformation("DB_DATABASE environment variable is empty, using : {0}", db_database);
            }

            if (string.IsNullOrWhiteSpace(db_username) || string.IsNullOrWhiteSpace(db_password)) {
                db_username = "swarm";
                db_password = "password";
                Log.LogInformation("DB_USERNAME or DB_PASSWORD environment variable is empty, using User:{0} and Password:[redacted]", db_username);
            }

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            return optionsBuilder.UseNpgsql(string.Format("Host={0};Database={1};Username={2};Password={3}", db_host, db_database, db_username, db_password));
        }
    }
}
