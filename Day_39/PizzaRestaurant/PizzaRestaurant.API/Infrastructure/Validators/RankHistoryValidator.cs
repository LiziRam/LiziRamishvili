using System;
using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localisations;
using PizzaRestaurant.Application.RankHistories.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
	public class RankHistoryValidator : AbstractValidator<RankHistoryRequestModel>
	{
		public RankHistoryValidator()
		{
			RuleFor(rk => rk.Rank)
				.GreaterThanOrEqualTo(1)
				.LessThanOrEqualTo(10)
				.WithMessage((nameof(RankHistoryRequestModel.Rank) + " -> " + ErrorMessages.RankValidationError));
		}
	}
}

