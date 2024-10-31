using Microsoft.EntityFrameworkCore;
using ReceitasApi.Models;

namespace ReceitasApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>()
                .HasOne(r => r.Categoria)
                .WithMany(c => c.Receitas)
                .HasForeignKey(r => r.CategoriaId);
        }
    }
}
