namespace ListaDeContatos.Models
{
    // Definição da classe 'ErrorViewModel' que representa o modelo de erro
    public class ErrorViewModel
    {
        // Propriedade 'RequestId' do tipo 'string?' (nullable string) com atributos 'get' e 'set'
        // Esta propriedade armazena o ID da requisição, que pode ser nulo
        public string? RequestId { get; set; }

        // Propriedade 'ShowRequestId' que retorna um booleano
        // Esta propriedade verifica se 'RequestId' não é nulo ou vazio
        // Se 'RequestId' não for nulo ou vazio, 'ShowRequestId' retorna 'true', caso contrário, retorna 'false'
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
