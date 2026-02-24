namespace ReservationApp.Api.DTOs
{
    public class ReservationDTO
    {
        public string Patient { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
    }
}
