using System.ComponentModel.DataAnnotations;

namespace ReservationApp.Models
{
    public class CreateReservationViewModel
    {
        [Required]
        public string Paciente { get; set; } = string.Empty;
        [Required]
        public DateOnly Fecha { get; set; }
        [Required]
        public string Medico { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
       
    }
}
