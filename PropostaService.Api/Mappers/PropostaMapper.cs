using PropostaService.Api.Responses;
using PropostaService.Application.Commands;
using PropostaService.Domain.Entities;

namespace PropostaService.Api.Requests
{
    public static class PropostaMapper
    {
        public static PropostaResponse ToResponse(Proposta proposta) => new PropostaResponse
        {
            Id = proposta.Id,
            NomeCliente = proposta.NomeCliente,
            TipoSeguro = proposta.TipoSeguro,
            Status = proposta.Status.ToString(),
            DataCriacao = proposta.DataCriacao
        };

        public static CriarPropostaCommand ToCommand(CriarPropostaRequest request) =>
            new CriarPropostaCommand(request.NomeCliente, request.TipoSeguro);
    }

}
