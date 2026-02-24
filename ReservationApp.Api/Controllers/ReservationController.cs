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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _reservationServices.GetByIdAsync(id);
            if (reservation == null)
                return NotFound();
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTOs)
        {
            await _reservationServices.CreateReservationAsync(createReservationDTOs);
            return Created("", null); // se supone con esto devuelvo con codigo 201, pero no se como devolver el id del nuevo recurso creado 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, CreateReservationDTO updateReservationDTOs)
        {
            var updated = await _reservationServices.UpdateReservationAsync(id, updateReservationDTOs);
            if (!updated)
                return NotFound();
            return NoContent(); // estu un codigo 204 standar REST
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var deleted = await _reservationServices.DeleteReservationAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent(); // estu un codigo 204 standar REST
        }
    }
}
