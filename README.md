
# 📄 PropostaService

O **PropostaService** é um microserviço responsável por gerenciar propostas de seguros dentro do ecossistema AppSeguros. Ele permite a criação, atualização, consulta e aprovação de propostas, servindo como fonte de verdade para o status das propostas que serão posteriormente contratadas pelo ContratacaoService.

---

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/)
- [PostgreSQL](https://www.postgresql.org/)
- ASP.NET Core Web API
- xUnit + FluentAssertions (testes)
- RabbitMQ (opcional para eventos)
- Fila em memória (modo simplificado)

---

## 🧱 Arquitetura

```
PropostaService
├── Api           → Camada de apresentação (controllers)
├── Application   → Regras de negócio e validações
├── Infrastructure→ Persistência e mensageria
├── Domain        → Entidades e enums do domínio
```

---

## 📡 Endpoints Principais

| Método | Rota               | Descrição                          |
|--------|--------------------|------------------------------------|
| POST   | /api/propostas     | Cria uma nova proposta             |
| PUT    | /api/propostas/{id}| Atualiza uma proposta existente    |
| GET    | /api/propostas     | Lista todas as propostas           |
| GET    | /api/propostas/{id}| Consulta uma proposta específica   |
| PATCH  | /api/propostas/{id}/aprovar | Aprova uma proposta         |

---

## 🗄️ Banco de Dados

- **Banco**: `proposta_db`
- **Tabela principal**: `Propostas`
- **Migrations**: gerenciadas via EF Core

### Criar Migration Inicial

```bash
dotnet ef migrations add InitialCreate --project PropostaService.Infrastructure --startup-project PropostaService.Api
dotnet ef database update --project PropostaService.Infrastructure --startup-project PropostaService.Api
```

---

## 📬 Integração com Outros Serviços

O PropostaService é consultado pelo ContratacaoService para verificar se uma proposta está **Aprovada** antes de ser contratada. Essa integração é feita via HTTP:

```http
GET https://localhost:44340/api/propostas/{id}
```

---

## 🧪 Testes

Os testes estão organizados nas seguintes pastas:

- `/tests/PropostaService.UnitTests`
- `/tests/PropostaService.IntegrationTests`

### Executar Testes

```bash
dotnet test
```

---

## ⚙️ Configuração Local

1. **PostgreSQL**  
   Certifique-se de que o PostgreSQL está rodando localmente na porta `5432` com o banco `proposta_db` criado.

2. **Connection String**  
   Configure o `appsettings.json` com a string de conexão:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=proposta_db;Username=postgres;Password=postgres"
}
```

Diagrama <img width="1024" height="1024" alt="image" src="https://github.com/user-attachments/assets/eb2019de-c0b9-4487-acf4-46c727a69033" />


