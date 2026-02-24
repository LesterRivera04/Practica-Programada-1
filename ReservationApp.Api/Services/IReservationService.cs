namespace ReservationApp.Api.Services
{
    public interface IReservationService
    {
        Task<List<DTOs.ReservationDTO>> GetReservationsAsync();
        Task CreateReservationAsync(DTOs.CreateReservationDTO createReservation);
    }
}
