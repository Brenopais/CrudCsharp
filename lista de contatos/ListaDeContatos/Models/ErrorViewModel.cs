namespace ListaDeContatos.Models
{
    // Defini��o da classe 'ErrorViewModel' que representa o modelo de erro
    public class ErrorViewModel
    {
        // Propriedade 'RequestId' do tipo 'string?' (nullable string) com atributos 'get' e 'set'
        // Esta propriedade armazena o ID da requisi��o, que pode ser nulo
        public string? RequestId { get; set; }

        // Propriedade 'ShowRequestId' que retorna um booleano
        // Esta propriedade verifica se 'RequestId' n�o � nulo ou vazio
        // Se 'RequestId' n�o for nulo ou vazio, 'ShowRequestId' retorna 'true', caso contr�rio, retorna 'false'
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
