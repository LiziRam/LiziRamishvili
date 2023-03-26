using System.Security.Claims;
using EventsManagement.Application.Events;
using EventsManagement.Application.Events.Requests;
using EventsManagement.Application.Transactions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ITransactionService _transactionService;
        private int _userId;

        public EventController(IEventService eventService, ITransactionService transactionService)
        {
            _eventService = eventService;
            _transactionService = transactionService;
        }


        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var admittedEvents = await _eventService.GetUsersAllEventsAsync(cancellationToken, _userId).ConfigureAwait(false);
            return View(admittedEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(CancellationToken cancellationToken, int id)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.IsBooked = await _transactionService.BookingExists(cancellationToken, id, _userId).ConfigureAwait(false);
            ViewBag.AreAvailableTickets = await _eventService.AreAvailableTickets(cancellationToken, id).ConfigureAwait(false);
            var currEvent = await _eventService.GetDetailsAsync(cancellationToken, id).ConfigureAwait(false);
            return View(currEvent);
        }

        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create(CancellationToken cancellationToken,
            EventCreateRequestModel createRequestModel)
        {
            if (!ModelState.IsValid) return View(createRequestModel);

            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _eventService.CreateAsync(cancellationToken, createRequestModel, _userId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(CancellationToken cancellationToken, int id)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var eventToUpdate = await _eventService.GetUsersEventAsync(cancellationToken, id, _userId);

            var oldInfoEvent = eventToUpdate.Adapt<EventEditRequestModel>();
            return View(oldInfoEvent);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CancellationToken cancellationToken,
            EventEditRequestModel editRequestModel)
        {
            if (!ModelState.IsValid) return View(editRequestModel);

            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _eventService.UpdateAsync(cancellationToken, editRequestModel, _userId).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}
