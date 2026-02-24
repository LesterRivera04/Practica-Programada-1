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
        public async Task<IActionResult> Create(CreateReservationViewModel createReservationViewModel) { 
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
    }
}
