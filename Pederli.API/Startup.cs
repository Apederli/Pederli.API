using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pederli.Core.DataAccess.EntityFreamwork;
using Pederli.Data.Abstract;
using Pederli.Data.Concrete.EntityFreamwork;
using Pederli.Data.DataAccess;
using Pederli.Data.UnitOfWork;
using Pederli.Service.Abstract;
using Pederli.Service.Concrete;

namespace Pederli.API
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, DatabaseContext>();
           // services.AddScoped(typeof(IEntityRepositoryQ<>), typeof(EntityFreamworkBaseQ<>));
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityFreamworkBase<>));
            services.AddScoped(typeof(IService<>), typeof(ServiceManager<>));
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddAutoMapper(typeof(Startup));




            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("Pederli.Data");
                });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
