namespace ListaDeContatos

{
    public class Program 
    {
        public static void Main(string[] args) // Método de entrada da aplicação
        {
            // Cria o host da aplicação e inicia a execução
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => // Método estático para criar o construtor do host
            Host.CreateDefaultBuilder(args) // Cria um construtor padrão do host
                .ConfigureWebHostDefaults(webBuilder => // Configura o host para uma aplicação web
                {
                    // Define a classe Startup para configurar a aplicação
                    webBuilder.UseStartup<Startup>(); // Informa ao host que a classe Startup será responsável pela configuração
                });
    }
}
