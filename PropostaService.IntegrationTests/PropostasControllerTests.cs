using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

public class PropostasControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public PropostasControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task DeveCriarPropostaViaApi()
    {
        var proposta = new
        {
            nomeCliente = "Luiz",
            tipoSeguro = "Auto"
        };

        var response = await _client.PostAsJsonAsync("/api/propostas", proposta);

        response.EnsureSuccessStatusCode();
    }
}

