using Microsoft.AspNetCore.Mvc;
using ReservationApp.Api.DTOs;
using ReservationApp.Api.Services;

namespace ReservationApp.Api.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
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
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO)
        {
            // El servicio ahora retorna un ReservationDTO (que contiene el nuevo ID)
            var newReservation = await _reservationServices.CreateReservationAsync(createReservationDTO);

            // Devuelve 201 Created. 
            // El primer parámetro es el nombre del método GET para consultar este recurso.
            // El segundo es el objeto anónimo con el ID para la ruta.
            // El tercero es el objeto completo creado.
            return CreatedAtAction(nameof(GetById), new { id = newReservation.Id }, newReservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, CreateReservationDTO updateReservationDTO)
        {
            // Validamos que el registro exista y lo actualizamos
            var updated = await _reservationServices.UpdateReservationAsync(id, updateReservationDTO);

            if (!updated)
                return NotFound();

            // 204 No Content: La operación fue exitosa pero no hay contenido que devolver
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var deleted = await _reservationServices.DeleteReservationAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}