using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropostaService.Domain.Enums;

namespace PropostaService.Domain.Entities
{
    public class Proposta
    {
        public Guid Id { get; private set; }
        public string NomeCliente { get; private set; }
        public string TipoSeguro { get; private set; }
        public PropostaStatus Status { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Proposta(string nomeCliente, string tipoSeguro)
        {
            Id = Guid.NewGuid();
            NomeCliente = nomeCliente;
            TipoSeguro = tipoSeguro;
            Status = PropostaStatus.EmAnalise;
            DataCriacao = DateTime.UtcNow;
        }

        public void AlterarStatus(PropostaStatus novoStatus)
        {
            Status = novoStatus;
        }
    }

}
