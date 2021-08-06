using System.Collections.Generic;
using caixaEletronico.model;
using Microsoft.EntityFrameworkCore;


namespace caixaEletronico.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<TipoConta> TipoContas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Transferecia> transferecias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TipoConta>()
            .HasData(
                new List<TipoConta>() {
                   new TipoConta() {
                       TipoContaId = 1,
                       Tipo = "Conta Corrente"
                   },
                   new TipoConta() {
                       TipoContaId = 2,
                       Tipo = "Poupança"
                   }
                }
            );

            builder.Entity<Pessoa>()
                .HasOne(a => a.Endereco)
                .WithOne(b => b.Pessoa)
                .HasForeignKey<Endereco>(b => b.EnderecoId);

            builder.Entity<Pessoa>()
              .HasOne(a => a.Conta)
              .WithOne(b => b.Pessoa)
              .HasForeignKey<Conta>(b => b.ContaId);
        }
    }
}
