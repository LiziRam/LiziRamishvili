using System.Security.Claims;
using EventsManagement.Application.Transactions;
using EventsManagement.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly UserManager<User> _userManager;
        private int _userId;

        public TransactionController(ITransactionService transactionService, UserManager<User> userManager) =>
            _transactionService = transactionService;

        [HttpPost]
        public async Task<IActionResult> Book(CancellationToken cancellationToken, int eventId)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _transactionService.CreateBookingAsync(cancellationToken, eventId, _userId).ConfigureAwait(false);

            ViewData["IsBooked"] = true;
            return RedirectToAction("Detail", "Event", new { id = eventId });
        }

        [HttpPost]
        public async Task<IActionResult> Buy(CancellationToken cancellationToken, int eventId)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _transactionService.CreatePurchaseAsync(cancellationToken, eventId, _userId).ConfigureAwait(false);
            return RedirectToAction("Detail", "Event", new { id = eventId });
        }

        [HttpPost]
        public async Task<IActionResult> CancelBooking(CancellationToken cancellationToken, int eventId)
        {
            _userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _transactionService.CancelAsync(cancellationToken, eventId, _userId).ConfigureAwait(false);
            return RedirectToAction("Detail", "Event", new { id = eventId });
        }
    }
}
