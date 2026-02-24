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
                Paciente = r.Paciente,
                Medico = r.Medico,
                Especialidad = r.Especialidad,
                Fecha = r.Fecha
            }).ToList();
        }

        public async Task<ReservationDTO?> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
                return null;

            return new ReservationDTO
            {
                Paciente = reservation.Paciente,
                Medico = reservation.Medico,
                Especialidad = reservation.Especialidad,
                Fecha = reservation.Fecha
            };
        }
        public async Task CreateReservationAsync(CreateReservationDTO createReservation)
        {
            DateValidation(createReservation.Fecha);
            var reservation = new Models.Reservation
            {
                Paciente = createReservation.Paciente,
                Medico = createReservation.Medico,
                Especialidad = createReservation.Especialidad,
                Fecha = createReservation.Fecha,
                FechaCreacion = DateTime.UtcNow
            };
            await _reservationRepository.CreateAsync(reservation);
        }

        public async Task<bool> UpdateReservationAsync(int id, CreateReservationDTO updateReservation)
        {
            var existing = await _reservationRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            DateValidation(updateReservation.Fecha);

            existing.Paciente = updateReservation.Paciente;
            existing.Medico = updateReservation.Medico;
            existing.Especialidad = updateReservation.Especialidad;
            existing.Fecha = updateReservation.Fecha;

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
