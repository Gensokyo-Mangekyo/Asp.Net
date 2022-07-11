using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); //Добавялем сервесы mvc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(end => end.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));
            //controller=Home значит что название первого запускаемого контроллера начинается на Home обратим внимание что после Home не стоит Controller
            //Если имя Home то значит должна быть папка которая которая называется этим именем именно там и Asp.Net искать файлы представления а Action
            //Это первое представление которое контроллер обработает
        }
    }
}
