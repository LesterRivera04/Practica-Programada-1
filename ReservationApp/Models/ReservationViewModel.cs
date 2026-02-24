namespace ReservationApp.Models
{
    public class ReservationViewModel
    {
        public string Paciente { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public string Medico { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        
    }
}
