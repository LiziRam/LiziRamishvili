using EventsManagement.Application.Transactions;
using EventsManagement.Application.Transactions.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly int _userId;

        public TransactionController(ITransactionService transactionService, IHttpContextAccessor accessor)
        {
            _transactionService = transactionService;
            var IdClaim = accessor.HttpContext.User.Claims.Single(x => x.Type == "UserId");
            _userId = int.Parse(IdClaim.Value);
        }

        /// <summary>
        /// Book a ticket
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/Book")]
        public async Task<TransactionResponseModel> PostBooking(CancellationToken cancellationToken, int id) =>
            await _transactionService.CreateBookingAsync(cancellationToken, id, _userId).ConfigureAwait(false);

        /// <summary>
        /// Purchase a ticket
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/Purchase")]
        public async Task<TransactionResponseModel> PostPurchase(CancellationToken cancellationToken, int id) =>
            await _transactionService.CreatePurchaseAsync(cancellationToken, id, _userId).ConfigureAwait(false);

        /// <summary>
        /// Cancel Booking
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/CancelBooking")]
        public async Task CancelBooking(CancellationToken cancellationToken, int id) =>
            await _transactionService.CancelAsync(cancellationToken, id, _userId).ConfigureAwait(false);

        /// <summary>
        /// Get a transaction
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TransactionResponseModel> Get(CancellationToken cancellationToken, int id) =>
            await _transactionService.GetAsync(cancellationToken, id, _userId).ConfigureAwait(false);

        /// <summary>
        /// Get all transactions
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<TransactionResponseModel>> GetAll(CancellationToken cancellationToken) =>
            await _transactionService.GetAllAsync(cancellationToken, _userId).ConfigureAwait(false);
    }
}
