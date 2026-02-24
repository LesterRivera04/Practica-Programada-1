using ReservationApp.Api.Models;

namespace ReservationApp.Api.Repository
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsAsync();
        Task CreateReservationAsync(Reservation reservation);
    }
}
