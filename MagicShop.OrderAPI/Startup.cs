using MagicShop.OrderAPI.Contexts;
using MagicShop.OrderAPI.Repositories;
using MagicShop.OrderAPI.Repositories.Interfaces;
using MagicShop.OrderAPI.UseCases;
using MagicShop.OrderAPI.UseCases.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services) { 


            services.AddControllers();
            services.AddMemoryCache();
            services.AddDbContext<OrderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection"),
                x => x.MigrationsAssembly("MagicShop.OrderAPI")));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<ICreateNewOrderUseCase, CreateNewOrderUseCase>();
            services.AddTransient<IOrderCompletedUseCase, OrderCompletedUseCase>();
            services.AddTransient<IMatchOrderWithSaleUseCase, MatchOrderWithSaleUseCase>();
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

            SeedDatabase(app);
        }
        private static void SeedDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<OrderContext>();
                OrderContextSeed.SeedAsync(context);
            }
        }
    }
}
