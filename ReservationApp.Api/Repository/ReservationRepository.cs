using Microsoft.Data.SqlClient;
using ReservationApp.Api.Models;

namespace ReservationApp.Api.Repository
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly string _connectionString;

        public ReservationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            var reservations = new List<Reservation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT * FROM Reservas", connection);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    reservations.Add(new Models.Reservation
                    {
                        Id = reader.GetInt32(0),
                        Patient = reader.GetString(1),
                        Doctor = reader.GetString(2),
                        Specialty = reader.GetString(3),
                        Date = DateOnly.FromDateTime(reader.GetDateTime(4)),
                        CreatedAt = reader.GetDateTime(5)
                    });
                }
            }
            return reservations;
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Reservas (Paciente, Medico, Especialidad, Fecha, FechaCreacion) VALUES (@Patient, @Doctor, @Specialty, @Date, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@Patient", reservation.Patient);
                command.Parameters.AddWithValue("@Doctor", reservation.Doctor);
                command.Parameters.AddWithValue("@Specialty", reservation.Specialty);
                command.Parameters.AddWithValue("@Date", reservation.Date.ToDateTime(new TimeOnly(0, 0)));
                command.Parameters.AddWithValue("@CreatedAt", reservation.CreatedAt);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
