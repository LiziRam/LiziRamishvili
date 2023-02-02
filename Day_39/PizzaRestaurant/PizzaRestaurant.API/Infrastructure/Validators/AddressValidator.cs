using System;
using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localisations;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class AddressValidator : AbstractValidator<AddressRequestModel>
    {
        public AddressValidator()
        {
            RuleFor(a => a.City)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage((nameof(AddressRequestModel.City) + " -> " + ErrorMessages.CityValidationError));

            RuleFor(a => a.Country)
                .NotEmpty()
                .MaximumLength(15)
                .WithMessage((nameof(AddressRequestModel.City) + " -> " + ErrorMessages.CountryValidationError));

            RuleFor(a => a.Region)
               .MaximumLength(15)
               .WithMessage((nameof(AddressRequestModel.City) + " -> " + ErrorMessages.RegionValidationError));

            RuleFor(a => a.Description)
                .MaximumLength(100)
                .WithMessage((nameof(AddressRequestModel.City) + " -> " + ErrorMessages.DescriptionValidationError));
        }
    }
}

