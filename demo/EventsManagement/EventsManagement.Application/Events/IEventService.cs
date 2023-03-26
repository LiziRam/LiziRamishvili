using EventsManagement.Application.Events.Requests;
using EventsManagement.Application.Events.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Events
{
    public interface IEventService
    {
        Task<EventResponseModel> CreateAsync(CancellationToken cancellationToken,
            EventCreateRequestModel eventCreateRequest, int userId);

        Task<EventAdmittedDetailedResponseModel> GetDetailsAsync(CancellationToken cancellationToken, int id);
        Task<List<EventAdmittedResponseModel>> GetAllAdmittedAsync(CancellationToken cancellationToken);
        Task<EventResponseModel> GetUsersEventAsync(CancellationToken cancellationToken, int id, int userId);
        Task<List<EventResponseModel>> GetUsersAllEventsAsync(CancellationToken cancellationToken, int userId);

        Task UpdateAsync(CancellationToken cancellationToken, EventEditRequestModel eventEditRequest, int userId);
        Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id, int userId);

        Task<EventAdminResponseModel> GetAsync(CancellationToken cancellationToken, int id);

        Task<List<EventAdminResponseModel>> GetAllUnadmittedAsync(CancellationToken cancellationToken);
        Task<List<EventAdminResponseModel>> GetAllArchivedAsync(CancellationToken cancellationToken);
        Task AdmitAsync(CancellationToken cancellationToken, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task UpdateTicketAvailability(CancellationToken cancellationToken, int eventId, int delta);

        Task ArchivePastEventsAsync(CancellationToken cancellationToken);
        Task<bool> AreAvailableTickets(CancellationToken cancellationToken, int id);
    }
}
