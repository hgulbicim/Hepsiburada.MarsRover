using Hepsiburada.MarsRover.Business.Assembler;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Business.OperationService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hepsiburada.MarsRover.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IRoverService, RoverService>();
            services.AddSingleton<IPlateauService, PlateauService>();
            services.AddSingleton<IRoverCommandService, RoverCommandService>();
            services.AddSingleton<IInputModelAssembler, InputModelAssembler>();
            services.AddSingleton<IInputProviderService, InputProviderService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Rover/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Rover}/{action=Input}/{id?}");
            });
        }
    }
}