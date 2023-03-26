using EventsManagement.Application.Users.Requests;
using FluentValidation;

namespace EventsManagement.API.Infrastructure.Validations
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequestModel>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username field can't be empty.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password field can't be empty.");
        }
    }
}
