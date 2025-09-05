using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Interfaces;
using PropostaService.Infrastructure.Data;
using PropostaService.Domain.Repository;
using PropostaService.Application.CommandsHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PropostaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<CriarPropostaHandler>();
builder.Services.AddScoped<AlterarStatusHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
