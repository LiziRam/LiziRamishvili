using EventsManagement.Application.Events.Repositories;
using EventsManagement.Domain.Events;
using EventsManagement.Persistence.Context;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EvenetsManagement.Infrastructure.Events
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventsManagementContext context) : base(context)
        {
        }

        public async Task<Event> CreateAsync(CancellationToken cancellationToken, Event eventToInsert)
        {
            await AddAsync(cancellationToken, eventToInsert).ConfigureAwait(false);
            return eventToInsert;
        }

        public async Task<Event> GetAsync(CancellationToken cancellationToken, int id) =>
            await _dbSet.SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken).ConfigureAwait(false);

        public async Task<List<Event>> GetAllAdmittedAsync(CancellationToken cancellationToken) => await _dbSet
            .Where(x => x.IsAdmitted && !x.IsDeleted && !x.IsArchived).ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<List<Event>> GetUsersAllAsync(CancellationToken cancellationToken, int userId) => await _dbSet
            .Where(x => x.UserId == userId && !x.IsDeleted && !x.IsArchived).ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<List<Event>> GetAllUnadmittedAsync(CancellationToken cancellationToken) => await _dbSet
            .Where(x => !x.IsAdmitted && !x.IsDeleted && !x.IsArchived).ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task<List<Event>> GetAllArchivedAsync(CancellationToken cancellationToken) => await _dbSet
            .Where(x => x.IsAdmitted && !x.IsDeleted && x.IsArchived).ToListAsync(cancellationToken).ConfigureAwait(false);

        public async Task UpdateAsync(CancellationToken cancellationToken, Event eventToUpdate)
        {
            eventToUpdate.ModifiedAt = DateTime.UtcNow;
            await base.UpdateAsync(cancellationToken, eventToUpdate).ConfigureAwait(false);
        }

        public async Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id)
        {
            var eventToPatch = await _context.Set<Event>().FindAsync(id).ConfigureAwait(false);
            var eventId = eventToPatch.Id;
            var userId = eventToPatch.UserId;
            var ticketsAvailable = eventToPatch.TicketsAvailable;

            if (eventToPatch != null)
            {
                patchDocument.ApplyTo(eventToPatch);
                eventToPatch.Tickets =
                    Math.Max(ticketsAvailable, eventToPatch.Tickets);
                eventToPatch.Id = eventId;
                eventToPatch.UserId = userId;
                eventToPatch.ModifiedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, string title) =>
            await AnyAsync(cancellationToken, x => x.Title == title && !x.IsDeleted).ConfigureAwait(false);

        public async Task<bool> Exists(CancellationToken cancellationToken, int id) =>
            await AnyAsync(cancellationToken, x => x.Id == id && !x.IsDeleted).ConfigureAwait(false);

        public void Detach(Event eventToUpdate) => base.Detach(eventToUpdate);

        public async Task<bool> AreAvailableTickets(CancellationToken cancellationToken, int id) => await AnyAsync(
            cancellationToken,
            x => x.Id == id && x.IsAdmitted && !x.IsDeleted && !x.IsArchived && x.TicketsAvailable > 0).ConfigureAwait(false);

        public async Task<List<Event>> GetEndedEvents(CancellationToken cancellationToken) =>
            await _dbSet.Where(x => !x.IsDeleted && x.EndDateTime <= DateTime.UtcNow).ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}
