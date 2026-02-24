using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReservationApp.Api.Data;
using ReservationApp.Api.Models;

namespace ReservationApp.Api.Repository
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {            
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reservation?> GetByIdAsync(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            _context.Reservas.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public async Task<bool> UpdateAsync(Reservation reservation)
        {
            _context.Reservas.Update(reservation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reservation = await _context.Reservas.FindAsync(id);
            if (reservation == null)
                return false;

            _context.Reservas.Remove(reservation);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
