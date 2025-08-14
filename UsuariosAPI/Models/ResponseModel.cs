namespace UsuariosAPI.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; } // UsuarioModel no tipo ou generico?
        public string Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}

// Usando um modelo de resposta genérico para padronizar as respostas da API
