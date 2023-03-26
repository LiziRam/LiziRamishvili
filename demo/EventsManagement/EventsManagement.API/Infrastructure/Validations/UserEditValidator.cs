using EventsManagement.Application.Users.Requests;
using FluentValidation;

namespace EventsManagement.API.Infrastructure.Validations
{
    public class UserEditValidator : AbstractValidator<UserEditRequestModel>
    {
        public UserEditValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Username length can't be less than 2 and more than 50.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .MaximumLength(100)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Wrong email format.");

            RuleFor(u => u.FirstName)
                .MaximumLength(50)
                .WithMessage("First Name length more than 50.");

            RuleFor(u => u.LastName)
                .MaximumLength(50)
                .WithMessage("Last Name length more than 50.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100)
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{5,}$")
                .WithMessage("Password must be at least 5 characters long, contain at least one lowercase letter, one uppercase letter, one digit, and one special character");
        }
    }
}
