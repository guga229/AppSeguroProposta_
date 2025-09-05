using PropostaService.Application.Commands;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Application.CommandsHandlers
{
    public class CriarPropostaHandler
    {
        private readonly IPropostaRepository _repository;

        public CriarPropostaHandler(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(CriarPropostaCommand command)
        {
            var proposta = new Proposta(command.NomeCliente, command.TipoSeguro);
            await _repository.CriarAsync(proposta);
            return proposta.Id;
        }
    }

}
