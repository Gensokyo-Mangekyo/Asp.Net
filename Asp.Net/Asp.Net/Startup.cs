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
            services.AddMvc(); //Добавялем сервесы mvc
            services.AddTransient<ITime, SimpleTime>(); //Подробнее о DI не будем просто знай что есть
            //AddSingleton->  создаётся один раз (SimpleTime объект) при запуске приложения, и при всех запросах к приложению оно использует один и тот же singleton-объект
            //AddTransient  создаются каждый раз при вызове
            //AddScoped создаётся только один на каждый запрос 
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/errorcode", "?code={0}"); //Перенаправление статус кода протокола http ошибки на маршрут
            //errorcode это первый параметр а второй передаёт параметр контроллеру {0} это код ошибки http протокола
            env.EnvironmentName = "Gensokyo"; //Теперь вместо генерации исключения и показ ошибки в браузере будет генерироватся http статус 500
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(end => end.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));

        }
    }
}
