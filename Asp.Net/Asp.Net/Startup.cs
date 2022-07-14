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
            services.AddMvc(); //��������� ������� mvc
            services.AddTransient<ITime, SimpleTime>(); //��������� � DI �� ����� ������ ���� ��� ����
            //AddSingleton->  �������� ���� ��� (SimpleTime ������) ��� ������� ����������, � ��� ���� �������� � ���������� ��� ���������� ���� � ��� �� singleton-������
            //AddTransient  ��������� ������ ��� ��� ������
            //AddScoped �������� ������ ���� �� ������ ������ 
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/errorcode", "?code={0}"); //��������������� ������ ���� ��������� http ������ �� �������
            //errorcode ��� ������ �������� � ������ ������� �������� ����������� {0} ��� ��� ������ http ���������
            env.EnvironmentName = "Gensokyo"; //������ ������ ��������� ���������� � ����� ������ � �������� ����� ������������� http ������ 500
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(end => end.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"));

        }
    }
}
