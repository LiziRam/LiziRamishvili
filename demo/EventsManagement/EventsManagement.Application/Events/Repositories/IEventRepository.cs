using EventsManagement.Domain.Events;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Events.Repositories
{
    public interface IEventRepository
    {
        Task<Event> CreateAsync(CancellationToken cancellationToken, Event eventToInsert);
        Task UpdateAsync(CancellationToken cancellationToken, Event eventToUpdate);
        Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id);
        Task<Event> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<Event>> GetAllAdmittedAsync(CancellationToken cancellationToken);
        Task<List<Event>> GetUsersAllAsync(CancellationToken cancellationToken, int userId);

        Task<List<Event>> GetAllUnadmittedAsync(CancellationToken cancellationToken);
        Task<List<Event>> GetAllArchivedAsync(CancellationToken cancellationToken);

        Task<bool> Exists(CancellationToken cancellationToken, string title);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        void Detach(Event eventToUpdate);
        Task<List<Event>> GetEndedEvents(CancellationToken cancellationToken);
        Task<bool> AreAvailableTickets(CancellationToken cancellationToken, int id);
    }
}
