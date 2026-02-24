namespace ReservationApp.Api.DTOs
{
    public class ReservationDTO
    {
        public string Paciente { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
    }
}
