namespace ReservationApp.Api.Services
{
    public interface IReservationService
    {
        Task<List<DTOs.ReservationDTO>> GetReservationsAsync();
        Task<DTOs.ReservationDTO?> GetByIdAsync(int id);
        Task CreateReservationAsync(DTOs.CreateReservationDTO createReservation);
        Task<bool> UpdateReservationAsync(int id, DTOs.CreateReservationDTO updateReservation);
        Task<bool> DeleteReservationAsync(int id);
    }
}
