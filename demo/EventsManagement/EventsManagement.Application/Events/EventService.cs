using EventsManagement.Application.Events.Repositories;
using EventsManagement.Application.Events.Requests;
using EventsManagement.Application.Events.Responses;
using EventsManagement.Application.ExceptionHandling.CustomExceptions;
using EventsManagement.Application.Periods;
using EventsManagement.Domain.Events;
using Mapster;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Events
{
    public class EventService : IEventService
    {
        private readonly IPeriodService _periodService;

        private readonly IEventRepository _repository;

        public EventService(IEventRepository repo, IPeriodService periodService)
        {
            _repository = repo;
            _periodService = periodService;
        }

        //1. ------------------------------მომხმარებლისთვის---------------------------------

        public async Task<EventResponseModel> CreateAsync(CancellationToken cancellationToken,
            EventCreateRequestModel eventCreateRequest, int userId)
        {
            var eventExists = await _repository.Exists(cancellationToken, eventCreateRequest.Title).ConfigureAwait(false);
            if (eventExists)
                throw new EventNotFoundException();

            var eventToInsert = eventCreateRequest.Adapt<Event>();
            eventToInsert.TicketsAvailable = eventToInsert.Tickets;
            eventToInsert.UserId = userId;

            var newEvent = await _repository.CreateAsync(cancellationToken, eventToInsert).ConfigureAwait(false);
            return newEvent.Adapt<EventResponseModel>();
        }

        public async Task<EventAdmittedDetailedResponseModel> GetDetailsAsync(CancellationToken cancellationToken,
            int id)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException(); 

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            return eventToGet.Adapt<EventAdmittedDetailedResponseModel>();
        }

        public async Task<List<EventAdmittedResponseModel>> GetAllAdmittedAsync(CancellationToken cancellationToken)
        {
            var eventsToGet = await _repository.GetAllAdmittedAsync(cancellationToken).ConfigureAwait(false);
            var eventsResponse = eventsToGet.Adapt<List<EventAdmittedResponseModel>>();
            return eventsResponse;
        }

        public async Task<EventResponseModel> GetUsersEventAsync(CancellationToken cancellationToken, int id,
            int userId)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException();

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            if (eventToGet.UserId != userId)
                throw new WrongUserException();

            return eventToGet.Adapt<EventResponseModel>();
        }

        public async Task<List<EventResponseModel>> GetUsersAllEventsAsync(CancellationToken cancellationToken,
            int userId)
        {
            var eventsToGet = await _repository.GetUsersAllAsync(cancellationToken, userId).ConfigureAwait(false);
            var eventsResponse = eventsToGet.Adapt<List<EventResponseModel>>();
            return eventsResponse;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, EventEditRequestModel eventEditRequest,
            int userId)
        {
            var eventId = eventEditRequest.Id;
            var eventExists = await _repository.Exists(cancellationToken, eventId).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException();

            var eventToUpdate = await _repository.GetAsync(cancellationToken, eventId).ConfigureAwait(false);

            if (eventToUpdate.UserId != userId)
                throw new WrongUserException();

            var period = await _periodService.GetEditDaysAsync(cancellationToken).ConfigureAwait(false);
            var daysSinceCreation = (DateTime.UtcNow - eventToUpdate.CreatedAt).Days;
            if (daysSinceCreation >= period) throw new PastEditingDeadlineException();

            _repository.Detach(eventToUpdate);

            var updatedEvent = eventEditRequest.Adapt<Event>();
            updatedEvent.UserId = userId;
            updatedEvent.Tickets = Math.Max(eventToUpdate.TicketsAvailable, updatedEvent.Tickets);
            updatedEvent.TicketsAvailable = eventToUpdate.TicketsAvailable;
            updatedEvent.CreatedAt = eventToUpdate.CreatedAt;
            await _repository.UpdateAsync(cancellationToken, updatedEvent).ConfigureAwait(false);
        }

        public async Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id,
            int userId)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException(); 

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            if (eventToGet.UserId != userId)
                throw new WrongUserException();

            await _repository.PatchAsync(cancellationToken, patchDocument, id).ConfigureAwait(false);
        }


        //2. ------------------------------ადმინისთვის---------------------------------

        public async Task<EventAdminResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException();

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            return eventToGet.Adapt<EventAdminResponseModel>();
        }

        public async Task<List<EventAdminResponseModel>> GetAllUnadmittedAsync(CancellationToken cancellationToken)
        {
            var eventsToGet = await _repository.GetAllUnadmittedAsync(cancellationToken).ConfigureAwait(false);
            var eventsResponse = eventsToGet.Adapt<List<EventAdminResponseModel>>();
            return eventsResponse;
        }

        public async Task<List<EventAdminResponseModel>> GetAllArchivedAsync(CancellationToken cancellationToken)
        {
            var eventsToGet = await _repository.GetAllArchivedAsync(cancellationToken).ConfigureAwait(false);
            var eventsResponse = eventsToGet.Adapt<List<EventAdminResponseModel>>();
            return eventsResponse;
        }


        public async Task AdmitAsync(CancellationToken cancellationToken, int id)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException();

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            eventToGet.IsAdmitted = true;
            await _repository.UpdateAsync(cancellationToken, eventToGet).ConfigureAwait(false);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var eventExists = await _repository.Exists(cancellationToken, id).ConfigureAwait(false);
            if (!eventExists)
                throw new EventNotFoundException();

            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);

            eventToGet.IsDeleted = true;
            await _repository.UpdateAsync(cancellationToken, eventToGet).ConfigureAwait(false);
        }

        //3. ------------------------------------------------------------------------------

        public async Task UpdateTicketAvailability(CancellationToken cancellationToken, int id, int delta)
        {
            var eventToGet = await _repository.GetAsync(cancellationToken, id).ConfigureAwait(false);
            eventToGet.TicketsAvailable += delta;
            await _repository.UpdateAsync(cancellationToken, eventToGet).ConfigureAwait(false);
        }

        public async Task<bool> AreAvailableTickets(CancellationToken cancellationToken, int id) =>
            await _repository.AreAvailableTickets(cancellationToken, id).ConfigureAwait(false);


        //3. ------------------------------ვორქერისთვის---------------------------------

        public async Task ArchivePastEventsAsync(CancellationToken cancellationToken)
        {
            var eventsEnded = await _repository.GetEndedEvents(cancellationToken).ConfigureAwait(false);
            foreach (var currEvent in eventsEnded)
            {
                currEvent.IsArchived = true; 
                await _repository.UpdateAsync(cancellationToken, currEvent).ConfigureAwait(false);
            }
        }
    }
}
