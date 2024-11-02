namespace CadastroLivros.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; } // propriedade  generica que aceita qualquer tipo, que pode ser nulo
        public string Message { get; set; } = string.Empty; // Inicia com uma string vazia se nao marcar nada
        public bool Status { get; set; } = true; // inicia como true se nao marcar nada

    }
}
