namespace ReservationApp.Api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Paciente { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
