using ReservationApp.Api.DTOs;
using ReservationApp.Api.Exceptions;
using ReservationApp.Api.Repository;

namespace ReservationApp.Api.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _reservationRepository.GetReservationsAsync();

            return reservations.Select(r => new ReservationDTO
            {
                Patient = r.Patient,
                Doctor = r.Doctor,
                Specialty = r.Specialty,
                Date = r.Date
            }).ToList();
        }

        public async Task CreateReservationAsync(CreateReservationDTO createReservation)
        {
            DateValidation(createReservation.Date);
            var reservation = new Models.Reservation
            {
                Patient = createReservation.Patient,
                Doctor = createReservation.Doctor,
                Specialty = createReservation.Specialty,
                Date = createReservation.Date,
                CreatedAt = DateTime.UtcNow
            };
            await _reservationRepository.CreateReservationAsync(reservation);
        }

        private void DateValidation(DateOnly date)
        {
            if (date < DateOnly.FromDateTime(DateTime.Today))
                throw new BusinessException("Reservation date cannot be in the past.");
        }
    }
}
