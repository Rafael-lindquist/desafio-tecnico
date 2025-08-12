namespace UsuariosAPI.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}

// Esse é o modelo de resposta genérico que será utilizado para padronizar as respostas da API
