namespace AppExemplo.Models.Command
{
    public class BaseReturnApi
    {
        public BaseReturnApi()
        {

        }

        public BaseReturnApi(bool sucesso, string mensagem, object data = null)
        {
            Success = sucesso;
            Message = mensagem;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
