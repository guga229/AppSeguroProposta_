using PropostaService.Domain.Entities;
using PropostaService.Domain.Interfaces;
using PropostaService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Domain.Repository
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly PropostaDbContext _context;

        public PropostaRepository(PropostaDbContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(Proposta proposta)
        {
            _context.Propostas.Add(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Proposta proposta)
        {
            _context.Propostas.Update(proposta);
            await _context.SaveChangesAsync();
        }

        public async Task<Proposta> ObterPorIdAsync(Guid id)
        {
            return await _context.Propostas.FindAsync(id);
        }

        public async Task<IEnumerable<Proposta>> ListarAsync()
        {
            return await _context.Propostas.ToListAsync();
        }
    }

}
