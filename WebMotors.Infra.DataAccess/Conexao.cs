using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain;

namespace WebMotors.Infra.DataAccess
{
    public class Conexao : DbContext
    {
        public Conexao() { }

        public Conexao(DbContextOptions<Conexao> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<AnuncioWebMotors> Anuncio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Conexao).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
