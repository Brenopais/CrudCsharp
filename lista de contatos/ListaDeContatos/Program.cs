namespace ListaDeContatos

{
    public class Program 
    {
        public static void Main(string[] args) // M�todo de entrada da aplica��o
        {
            // Cria o host da aplica��o e inicia a execu��o
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => // M�todo est�tico para criar o construtor do host
            Host.CreateDefaultBuilder(args) // Cria um construtor padr�o do host
                .ConfigureWebHostDefaults(webBuilder => // Configura o host para uma aplica��o web
                {
                    // Define a classe Startup para configurar a aplica��o
                    webBuilder.UseStartup<Startup>(); // Informa ao host que a classe Startup ser� respons�vel pela configura��o
                });
    }
}
