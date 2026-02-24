using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservationApp.Api.Models;

namespace ReservationApp.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Reservation> Reservas { get; set; }
        public DbSet<Models.User> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuramos el ValueConverter para DateOnly
            var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),  // DateOnly -> DateTime para la DB
                d => DateOnly.FromDateTime(d)          // DateTime de la DB -> DateOnly
            );

            modelBuilder.Entity<Reservation>()
                .Property(r => r.Fecha)
                .HasConversion(dateOnlyConverter);

            base.OnModelCreating(modelBuilder);
        }
    }
}
