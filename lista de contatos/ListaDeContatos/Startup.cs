using ListaDeContatos.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using ListaDeContatos.Repositorio; 

namespace ListaDeContatos
{
    public class Startup // Classe responsável pela configuração inicial da aplicação
    {
        // Construtor que recebe a configuração da aplicação (appsettings.json)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configura os serviços utilizados pela aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona serviços para manipulação de views Razor e ativa compilação em tempo de execução (opcional para desenvolvimento)
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            // Adiciona serviços do Entity Framework Core para SQL Server e configura o contexto do banco de dados
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            // Registra a implementação da interface IContatoRepositorio como serviço acessível em toda a aplicação
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        // Configura o pipeline de requisições HTTP da aplicação
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Define o comportamento da aplicação em ambiente de desenvolvimento
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Exibe páginas detalhadas de erro durante o desenvolvimento
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Redireciona para uma página de erro específica em ambiente de produção
            }

            // Define como a aplicação servirá arquivos estáticos (CSS, JavaScript, imagens)
            app.UseStaticFiles();

            // Configura o roteamento de requisições HTTP para controllers e actions específicos
            app.UseRouting();

            // Define como a aplicação realizará autorização de usuários (ainda não implementado neste exemplo)
            app.UseAuthorization();

            // Define os padrões de roteamento para mapear URLs a controllers e actions
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Define o padrão de rota padrão
            });
        }
    }
}
