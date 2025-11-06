using Microsoft.EntityFrameworkCore;
using CadastroDeEstudantes.Models;

namespace CadastroDeEstudantes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Estudante> Estudantes { get; set; }
    }
}