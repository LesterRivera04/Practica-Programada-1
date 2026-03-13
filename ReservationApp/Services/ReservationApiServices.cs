using ReservationApp.Models;

namespace ReservationApp.Services
{
    public class ReservationApiServices
    {
        private readonly HttpClient _httpClient;

        public ReservationApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReservationViewModel>> GetReservationsAsync()
        {
            var reservations = await _httpClient.GetAsync("reservations");
            reservations.EnsureSuccessStatusCode();

            return await reservations.Content.ReadFromJsonAsync<List<ReservationViewModel>>();

        }

        public async Task CreateReservationAsync(CreateReservationViewModel createReservationViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("reservations", createReservationViewModel);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error creating reservation: {errorMessage}");
            }
        }

        public async Task DeleteReservationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"reservations/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error deleting reservation: {errorMessage}");
            }
        }

        // Obtener una sola reserva para llenar el formulario de edición
        public async Task<ReservationViewModel?> GetReservationByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"reservations/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReservationViewModel>();
            }
            return null;
        }

        // Enviar el PUT a la API
        public async Task UpdateReservationAsync(int id, CreateReservationViewModel updateModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"reservations/{id}", updateModel);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar en la API: {error}");
            }
        }
    }
}
