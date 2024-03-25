using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace SeuNamespace
{
    internal class Startup
    {
        // Configurações da aplicação
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Este método é chamado em tempo de execução. Use para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona serviços necessários para a aplicação.
            services.AddControllersWithViews();
        }

        // Este método é chamado em tempo de execução. Use para configurar o pipeline de requisição HTTP.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
