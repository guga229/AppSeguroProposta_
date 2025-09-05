using PropostaService.Api.Responses;
using PropostaService.Application.Commands;
using PropostaService.Domain.Entities;

namespace PropostaService.Api.Requests
{
    public class CriarPropostaRequest
    {
        public string NomeCliente { get; set; }
        public string TipoSeguro { get; set; }
    }

}
