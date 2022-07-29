using MagicShop.SaleAPI.Contexts;
using MagicShop.SaleAPI.Repositories;
using MagicShop.SaleAPI.Repositories.Interfaces;
using MagicShop.SaleAPI.UseCases;
using MagicShop.SaleAPI.UseCases.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MagicShop.SaleAPI
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
            services.AddDbContext<SaleContext>(opt => opt.UseInMemoryDatabase("MagicShopSaleDB"));
            services.AddMemoryCache();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IMatchSaleWithOrderUseCase, MatchSaleWithOrderUseCase>();
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
