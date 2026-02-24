using Microsoft.EntityFrameworkCore;
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
    }
}
