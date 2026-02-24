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

        public async Task<ReservationDTO?> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            return new ReservationDTO
            {
                Patient = reservation.Patient,
                Doctor = reservation.Doctor,
                Specialty = reservation.Specialty,
                Date = reservation.Date
            };
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
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task<bool> UpdateReservationAsync(int id, CreateReservationDTO updateReservation)
        {
            var existing = await _reservationRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            DateValidation(updateReservation.Date);

            existing.Patient = updateReservation.Patient;
            existing.Doctor = updateReservation.Doctor;
            existing.Specialty = updateReservation.Specialty;
            existing.Date = updateReservation.Date;

            return await _reservationRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteReservationAsync(int id)
        {
            return await _reservationRepository.DeleteAsync(id);
        }

        private void DateValidation(DateOnly date)
        {
            if (date < DateOnly.FromDateTime(DateTime.Today))
                throw new BusinessException("Reservation date cannot be in the past.");
        }
    }
}
