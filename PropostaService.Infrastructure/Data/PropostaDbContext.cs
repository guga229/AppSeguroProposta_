using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Entities;
namespace PropostaService.Infrastructure.Data
{
    public class PropostaDbContext : DbContext
    {
        public DbSet<Proposta> Propostas { get; set; }

        public PropostaDbContext(DbContextOptions<PropostaDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proposta>().HasKey(p => p.Id);
            modelBuilder.Entity<Proposta>().Property(p => p.NomeCliente).IsRequired();
            modelBuilder.Entity<Proposta>().Property(p => p.TipoSeguro).IsRequired();
            modelBuilder.Entity<Proposta>().Property(p => p.Status).HasConversion<string>();
        }
    }
}
