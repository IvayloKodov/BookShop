using System;
using AutoMapper;
using BookShop.Api.Configurations;
using BookShop.Api.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using BookShop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace BookShop.Api
{
    public class Startup
    {
        private const string ApiName = "BookShop Api";
        private const string ApiVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookShopDbContext>(options => 
                options.UseInMemoryDatabase(nameof(BookShop)));
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure(
            //            maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null);
            //    }));

            services.Configure<SmtpConfiguration>(Configuration.GetSection("Smtp"));

            services.AddAutoMapper();

            services.AddDomainServices();

            services.AddSession();

            services.AddMemoryCache();

            services.AddResponseCaching();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddMvc();

            services.AddSwaggerApp(ApiName, ApiVersion, "Ivaylo Kodov");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();


            app.UseResponseCaching();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
                app.UseDeveloperExceptionPage();
            }

            //Uncomment when you are using real database.
            //app.UseDatabaseMigration();

            app.UseSession();

            app.UseCors("AllowAll");

            app.UseSwaggerApp(ApiName, ApiVersion);

            app.UseMvc(); 

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }
    }
}