using EventsManagement.Application.Events;
using EventsManagement.Application.Periods;
using EventsManagement.Application.Periods.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.Web.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class ManagerController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IPeriodService _periodService;

        public ManagerController(IEventService eventService, IPeriodService periodService)
        {
            _eventService = eventService;
            _periodService = periodService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var admittedEvents = await _eventService.GetAllUnadmittedAsync(cancellationToken).ConfigureAwait(false);
            return View(admittedEvents);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPeriods(CancellationToken cancellationToken)
        {
            var editDays = await _periodService.GetEditDaysAsync(cancellationToken).ConfigureAwait(false);
            var bookingDays = await _periodService.GetBookingDaysAsync(cancellationToken).ConfigureAwait(false);

            var editRequest = new PeriodEditRequestModel { Id = 1, EditPeriod = editDays, BookingPeriod = bookingDays };

            return View(editRequest);
        }


        [HttpPost]
        public async Task<IActionResult> EditPeriods(CancellationToken cancellationToken,
            PeriodEditRequestModel editRequestModel)
        {
            if (!ModelState.IsValid) return View(editRequestModel);

            var editDays = editRequestModel.EditPeriod;
            var bookingDays = editRequestModel.BookingPeriod;
            await _periodService.UpdateEditDaysAsync(cancellationToken, editDays).ConfigureAwait(false);
            await _periodService.UpdateBookingDaysAsync(cancellationToken, bookingDays).ConfigureAwait(false);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DetailArchived(CancellationToken cancellationToken, int id)
        {
            var currEvent = await _eventService.GetAsync(cancellationToken, id).ConfigureAwait(false);
            return View(currEvent);
        }

        public async Task<IActionResult> DetailUnadmitted(CancellationToken cancellationToken, int id)
        {
            var currEvent = await _eventService.GetAsync(cancellationToken, id).ConfigureAwait(false);
            return View(currEvent);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Archive(CancellationToken cancellationToken)
        {
            var archivedEvents = await _eventService.GetAllArchivedAsync(cancellationToken).ConfigureAwait(false);
            return View(archivedEvents);
        }

        [HttpPost]
        public async Task<IActionResult> Admit(CancellationToken cancellationToken, int eventId)
        {
            await _eventService.AdmitAsync(cancellationToken, eventId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, int eventId)
        {
            await _eventService.DeleteAsync(cancellationToken, eventId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
