using System;
using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localisations;
using PizzaRestaurant.Application.Users.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserRequestModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20)
                .WithMessage((nameof(UserRequestModel.FirstName) + " -> " + ErrorMessages.FirstNameValidationError));

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30)
                .WithMessage((nameof(UserRequestModel.LastName) + " -> " + ErrorMessages.LastNameValidationError));

            RuleFor(u => u.Email)
               .NotEmpty()
               .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
               .WithMessage((nameof(UserRequestModel.Email) + " -> " + ErrorMessages.EmailValidationError));

            RuleFor(u => u.PhoneNumber)
              .NotEmpty()
              .Matches("^\\+?[1-9][0-9]{7,14}$")
              .WithMessage((nameof(UserRequestModel.PhoneNumber) + " -> " + ErrorMessages.PhoneNumberValidationError));
        }
    }
}

