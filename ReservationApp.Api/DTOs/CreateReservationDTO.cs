using System.ComponentModel.DataAnnotations;

namespace ReservationApp.Api.DTOs
{
    public class CreateReservationDTO
    {
        [Required]
        public string Patient { get; set; } = string.Empty;
        [Required]
        public string Doctor { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        [Required]
        public DateOnly Date { get; set; }
    }
}
