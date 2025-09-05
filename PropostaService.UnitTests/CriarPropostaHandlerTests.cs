using PropostaService.Domain.Entities;
using PropostaService.Domain.Enums;
using FluentAssertions;

public class CriarPropostaHandlerTests
{
    [Fact]
    public void DeveCriarPropostaComStatusEmAnalise()
    {
        var proposta = new Proposta("Luiz", "Auto");

        proposta.Status.Should().Be(PropostaStatus.EmAnalise);
    }
}
