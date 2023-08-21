using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPi.Data.Models;

namespace HolaMundoAPi.Data
{
    public class HolaMundoDbContext : DbContext
    {
        public HolaMundoDbContext (DbContextOptions<HolaMundoDbContext> options)
            : base(options)
        {
        }

        public DbSet<HolaMundoAPi.Data.Models.Client> Clients { get; set; }
        public DbSet<HolaMundoAPi.Data.Models.UserRole> UserRoles { get; set; }
        public DbSet<HolaMundoAPi.Data.Models.User> Users { get; set; }
        public DbSet<HolaMundoAPi.Data.Models.ClasificacionGastos> ClasificacionGastos { get; set; }
        public DbSet<HolaMundoAPi.Data.Models.GastosViaje> GastosViaje { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<ClasificacionGastos>().ToTable(nameof(ClasificacionGastos));
            modelBuilder.Entity<GastosViaje>().ToTable(nameof(GastosViaje));

            base.OnModelCreating(modelBuilder);
        }
    }
}
