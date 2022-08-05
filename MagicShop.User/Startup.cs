using MagicShop.UserAPI.Contexts;
using MagicShop.UserAPI.Repositories;
using MagicShop.UserAPI.Repositories.Interfaces;
using MagicShop.UserAPI.UseCases;
using MagicShop.UserAPI.UseCases.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace MagicShop.UserAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection"),
                x => x.MigrationsAssembly("MagicShop.UserAPI")));
            services.AddMemoryCache();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IRegisterNewUserUseCase, RegisterNewUserUseCase>();
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
                var context = services.GetRequiredService<UserContext>();
                UserContextSeed.SeedAsync(context);
            }
        }
    }
}
