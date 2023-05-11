using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ShootingGalleryAPI.Data;

namespace ShootingGalleryAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShootingGalleryAPI", Version = "v1" });
            });

            //my DB servicies 
            services.AddDbContext<CalibersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserDb")));
            services.AddDbContext<DimCustomerLevelDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserWarehouse")));
            services.AddDbContext<DimGalleryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserWarehouse")));
            services.AddDbContext<DimDateDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserWarehouse")));
            services.AddDbContext<DimGunDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserWarehouse")));
            services.AddDbContext<FactSessionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserWarehouse")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShootingGalleryAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}