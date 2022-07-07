using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductsAndServices.Entities;
using System;
using ProductsAndServices.Interfaces;
using ProductsAndServices.Repositories;
using System.Reflection;
using System.IO;

namespace ProductsAndServices
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setupAction => 
            {
                setupAction.SwaggerDoc("ProductsAndServicesOpenApiSpecification", 
                    new Microsoft.OpenApi.Models.OpenApiInfo() 
                    { 
                        Title = "Products and services Open API",
                        Version = "1"
                    });

                var xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

                setupAction.IncludeXmlComments(xmlCommentsPath);
            });

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductsAndServices", Version = "v1" });
            });

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAndServices"));

            }

            app.UseSwagger();
            app.UseSwaggerUI(setupAction => 
            {
                setupAction.SwaggerEndpoint("/swagger/ProductsAndServicesOpenApiSpecification/swagger.json", "Products and services Open API");
                //setupAction.RoutePrefix = "";
            });

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
