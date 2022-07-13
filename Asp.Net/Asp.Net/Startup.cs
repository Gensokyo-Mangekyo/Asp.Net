using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asp.Net
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IRepository, Repository>(); //Нужен для хранения данных он создаётся только один раз!
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(end => end.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));

        }
    }
}
