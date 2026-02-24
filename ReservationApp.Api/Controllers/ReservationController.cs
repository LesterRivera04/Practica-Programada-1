using Microsoft.AspNetCore.Mvc;
using ReservationApp.Api.DTOs;
using ReservationApp.Api.Services;

namespace ReservationApp.Api.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationServices;

        public ReservationController(IReservationService reservationServices)
        {
            _reservationServices = reservationServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _reservationServices.GetReservationsAsync();
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTOs)
        {
            await _reservationServices.CreateReservationAsync(createReservationDTOs);
            return Ok();
        }
    }
}
