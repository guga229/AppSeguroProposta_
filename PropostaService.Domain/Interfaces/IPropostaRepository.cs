using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaService.Domain.Entities;

namespace PropostaService.Domain.Interfaces
{
    public interface IPropostaRepository
    {
        Task<Proposta> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Proposta>> ListarAsync();
        Task CriarAsync(Proposta proposta);
        Task AtualizarAsync(Proposta proposta);
    }

}
