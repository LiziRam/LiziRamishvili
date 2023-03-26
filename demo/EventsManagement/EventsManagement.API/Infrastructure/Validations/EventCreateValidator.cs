using EventsManagement.Application.Events.Requests;
using FluentValidation;

namespace EventsManagement.API.Infrastructure.Validations
{
    public class EventCreateValidator : AbstractValidator<EventCreateRequestModel>
    {
        public EventCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Event title can't be empty and it's length can't be more than 50.");

            RuleFor(x => x.Description)
                .MaximumLength(300)
                .WithMessage("Event description can't be longer than 300 characters.");

            RuleFor(x => x.StartDateTime)
                .NotEmpty()
                .Must(date => date >= DateTime.Today)
                .WithMessage("Start date must be in the future");

            RuleFor(x => x.EndDateTime)
                .NotEmpty()
                .Must(date => date >= DateTime.Today)
                .WithMessage("End date must be in the future");

            RuleFor(x => x.Location)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Event location field can't be empty and it's length can't be more than 50.");

            RuleFor(x => x.Tickets)
                .NotEmpty()
                .WithMessage("Number of tickets field can't be empty.");

            RuleFor(x => x.TicketPrice)
                .NotEmpty()
                .WithMessage("Price field can't be empty.");
        }
    }
}
