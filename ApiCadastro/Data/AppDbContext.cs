using ApiCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastro.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
