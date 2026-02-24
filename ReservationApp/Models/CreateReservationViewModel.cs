using System.ComponentModel.DataAnnotations;

namespace ReservationApp.Models
{
    public class CreateReservationViewModel
    {
        [Required]
        public string Patient { get; set; } = string.Empty;
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Doctor { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
       
    }
}
