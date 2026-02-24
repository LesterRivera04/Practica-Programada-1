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
    }
}
