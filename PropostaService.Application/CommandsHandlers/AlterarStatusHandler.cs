using PropostaService.Domain.Enums;
using PropostaService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Application.CommandsHandlers
{
    public class AlterarStatusHandler
    {
        private readonly IPropostaRepository _repository;

        public AlterarStatusHandler(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(Guid propostaId, PropostaStatus novoStatus)
        {
            var proposta = await _repository.ObterPorIdAsync(propostaId);
            proposta.AlterarStatus(novoStatus);
            await _repository.AtualizarAsync(proposta);
        }
    }
}
