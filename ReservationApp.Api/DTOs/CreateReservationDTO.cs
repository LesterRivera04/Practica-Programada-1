using System.ComponentModel.DataAnnotations;

namespace ReservationApp.Api.DTOs
{
    public class CreateReservationDTO
    {
        [Required]
        public string Paciente { get; set; } = string.Empty;
        [Required]
        public string Medico { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        [Required]
        public DateOnly Fecha { get; set; }
    }
}
