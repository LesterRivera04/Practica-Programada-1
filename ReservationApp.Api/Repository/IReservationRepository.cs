using ReservationApp.Api.Models;

namespace ReservationApp.Api.Repository
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<bool> UpdateAsync(Reservation reservation);
        Task<bool> DeleteAsync(int id);
    }
}
