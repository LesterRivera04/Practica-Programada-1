namespace ReservationApp.Api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Patient { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
