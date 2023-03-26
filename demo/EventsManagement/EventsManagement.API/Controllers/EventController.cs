using EventsManagement.Application.Events;
using EventsManagement.Application.Events.Requests;
using EventsManagement.Application.Events.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagement.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly int _userId;

        public EventController(IEventService eventService, IHttpContextAccessor accessor)
        {
            _eventService = eventService;
            var IdClaim = accessor.HttpContext.User.Claims.Single(x => x.Type == "UserId");
            _userId = int.Parse(IdClaim.Value);
        }

        //1. ------------------------------მომხმარებლისთვის---------------------------------

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     POST /Event
        ///     {
        ///       "title": "Primavera 2022",
        ///       "description": "Music festival of the year",
        ///       "startDateTime": "2022-06-30T20:00:00.567Z",
        ///       "endDateTime": "2022-07-03T20:00:00.567Z",
        ///       "location": "Bracelona, Spain"
        ///       "tickets": 1000,
        ///       "ticketPrice": 200
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<EventResponseModel> Post(CancellationToken cancellationToken,
            EventCreateRequestModel eventCreateRequest) =>
            await _eventService.CreateAsync(cancellationToken, eventCreateRequest, _userId).ConfigureAwait(false);

        /// <summary>
        /// Get details about an event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/fromUser")]
        public async Task<EventAdmittedDetailedResponseModel> GetDetails(CancellationToken cancellationToken, int id) =>
            await _eventService.GetDetailsAsync(cancellationToken, id).ConfigureAwait(false);

        /// <summary>
        /// Get all public events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAllAdmitted")]
        [HttpGet]
        public async Task<List<EventAdmittedResponseModel>> GetAllAdmitted(CancellationToken cancellationToken) =>
            await _eventService.GetAllAdmittedAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Get details about my event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/myDetails")]
        public async Task<EventResponseModel> GetMyDetails(CancellationToken cancellationToken, int id) =>
            await _eventService.GetUsersEventAsync(cancellationToken, id, _userId).ConfigureAwait(false);

        /// <summary>
        /// Get all my events
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("UsersEvents")]
        [HttpGet]
        public async Task<List<EventResponseModel>> GetMyEvents(CancellationToken cancellationToken) =>
            await _eventService.GetUsersAllEventsAsync(cancellationToken, _userId).ConfigureAwait(false);

        /// <summary>
        /// Update an event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     PUT /Event
        ///     {
        ///       "title": "Primavera 2022",
        ///       "description": "Music festival of the year",
        ///       "startDateTime": "2023-06-30T20:00:00.567Z",
        ///       "endDateTime": "2023-07-03T20:00:00.567Z",
        ///       "tickets": 2000,
        ///       "ticketPrice": 300
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, EventEditRequestModel eventEditRequest) =>
            await _eventService.UpdateAsync(cancellationToken, eventEditRequest, _userId).ConfigureAwait(false);

        /// <summary>
        /// Patch an event
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// 
        /// <remarks>
        /// Example:
        /// 
        ///     PATCH /Event
        ///     {
        ///       "path": "/title",
        ///       "op": "replace",
        ///       "value": "Primavera 2023"
        ///     }
        /// </remarks>
        [HttpPatch("{id}")]
        public async Task
            Patch(CancellationToken cancellationToken, [FromBody] JsonPatchDocument patchDocument, int id) =>
            await _eventService.PatchAsync(cancellationToken, patchDocument, id, _userId).ConfigureAwait(false);

        //2. ------------------------------ადმინისთვის---------------------------------

        //TODO წასაშლელი
        //[Route("GetAllActive")]
        //[HttpGet]
        //public async Task<List<EventAdminResponseModel>> GetAllActive(CancellationToken cancellationToken) =>
        //    await _eventService.GetAllActiveAsync(cancellationToken).ConfigureAwait(false);


        //TODO ეიპიაიში არასაჭირო
        //[HttpGet("{id}/fromAdmin")]
        //public async Task<EventAdminResponseModel> Get(CancellationToken cancellationToken, int id) =>
        //    await _eventService.GetAsync(cancellationToken, id).ConfigureAwait(false);

        //[Route("GetAllUnadmitted")]
        //[HttpGet]
        //public async Task<List<EventAdminResponseModel>> GetAllUnadmitted(CancellationToken cancellationToken) =>
        //    await _eventService.GetAllUnadmittedAsync(cancellationToken).ConfigureAwait(false);

        //[Route("GetAllArchived")]
        //[HttpGet]
        //public async Task<List<EventAdminResponseModel>> GetAllArchived(CancellationToken cancellationToken) =>
        //    await _eventService.GetAllArchivedAsync(cancellationToken).ConfigureAwait(false);

        //[HttpPost("{id}/admit")]
        //public async Task PutEventStatus(CancellationToken cancellationToken, int id) =>
        //    await _eventService.AdmitAsync(cancellationToken, id).ConfigureAwait(false);

        //[HttpDelete("{id}")]
        //public async Task Delete(CancellationToken cancellationToken, int id) =>
        //    await _eventService.DeleteAsync(cancellationToken, id).ConfigureAwait(false);
    }
}
