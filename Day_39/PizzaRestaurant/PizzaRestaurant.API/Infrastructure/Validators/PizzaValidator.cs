using System;
using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localisations;
using PizzaRestaurant.Application.Pizzas.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
	public class PizzaValidator : AbstractValidator<PizzaRequestModel>
	{
		public PizzaValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.MinimumLength(3)
				.MaximumLength(20)
				.WithMessage((nameof(PizzaRequestModel.Name) + " -> " + ErrorMessages.PizzaNameValidationError));

			RuleFor(p => p.Price)
				.NotEmpty()
				.GreaterThan(0)
				.WithMessage((nameof(PizzaRequestModel.Price) + " -> " + ErrorMessages.PriceValidationError));

			RuleFor(p => p.Description)
				.MaximumLength(100)
				.WithMessage((nameof(PizzaRequestModel.Description) + " -> " + ErrorMessages.DescriptionValidationError));

			RuleFor(p => p.CaloryCount)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage((nameof(PizzaRequestModel.CaloryCount) + " -> " + ErrorMessages.CaloryCountValidationError));
        }
	}
}

