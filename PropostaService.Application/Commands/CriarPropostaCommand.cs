﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropostaService.Application.Commands
{
    public record CriarPropostaCommand(string NomeCliente, string TipoSeguro);

}
