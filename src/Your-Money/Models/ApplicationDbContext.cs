using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Your_Money.Models;

namespace Your_Money.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Conta { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Parcelamento> Parcelamentos { get; set; }
    }
}
