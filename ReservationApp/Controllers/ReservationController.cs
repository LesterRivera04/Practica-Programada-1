using Microsoft.AspNetCore.Mvc;
using ReservationApp.Services;
using ReservationApp.Models;

namespace ReservationApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationApiServices _reservationApiServices;

        public ReservationController(ReservationApiServices reservationApiServices)
        {
            _reservationApiServices = reservationApiServices;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationApiServices.GetReservationsAsync();
            return View(reservations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationViewModel createReservationViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _reservationApiServices.CreateReservationAsync(createReservationViewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred while creating the reservation: {ex.Message}");
                    return View(createReservationViewModel);
                }
            }
            return View(createReservationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _reservationApiServices.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();

            // Mapeamos de ReservationViewModel a CreateReservationViewModel
            var model = new CreateReservationViewModel
            {
                Paciente = reservation.Paciente,
                Medico = reservation.Medico,
                Especialidad = reservation.Especialidad,
                Fecha = reservation.Fecha
            };

            ViewBag.Id = id; // Lo necesitamos para el post
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateReservationViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await _reservationApiServices.UpdateReservationAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _reservationApiServices.DeleteReservationAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al eliminar: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}