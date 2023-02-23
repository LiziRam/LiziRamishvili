using System;
using FluentValidation;
using Todo.Application.Users.Requests;

namespace Todo.API.Infrastructure.Validations
{
	public class UserLoginValidator : AbstractValidator<UserLoginRequestModel>
    {
		public UserLoginValidator()
		{
            RuleFor(u => u.Username)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Username length can't be less than 2 and more than 50.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100)
                .WithMessage("Password length can't be less than 5 and more than 100.");
        }
	}
}

