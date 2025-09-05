namespace PropostaService.Api.Responses
{
    public class PropostaResponse
    {
        public Guid Id { get; set; }
        public string NomeCliente { get; set; }
        public string TipoSeguro { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }

}
