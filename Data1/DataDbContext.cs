using CadastroLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Data1
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> option) : base(option) { } 
        
        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<AutorModel> Autor { get; set; }
    }
}
