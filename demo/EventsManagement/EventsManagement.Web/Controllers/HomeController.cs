using System.Diagnostics;
using EventsManagement.Application.Events;
using EventsManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var admittedEvents = await _eventService.GetAllAdmittedAsync(cancellationToken);
            return View(admittedEvents);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
