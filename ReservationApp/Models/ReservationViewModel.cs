namespace ReservationApp.Models
{
    public class ReservationViewModel
    {
        public string Patient { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public string Doctor { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        
    }
}
