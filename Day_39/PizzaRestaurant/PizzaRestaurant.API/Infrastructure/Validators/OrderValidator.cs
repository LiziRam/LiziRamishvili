using System;
using System.Collections.Generic;
using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localisations;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Domain.Pizzas;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class OrderValidator : AbstractValidator<OrderRequestModel>
    {
        public OrderValidator()
        {
            RuleFor(a => a.PizzaId)
                .NotEmpty()
                .WithMessage((nameof(OrderRequestModel.PizzaId) + " -> " + ErrorMessages.PizzaIdValidationError));

            RuleFor(a => a.UserId)
                .NotEmpty()
                .WithMessage((nameof(OrderRequestModel.UserId) + " -> " + ErrorMessages.UserIdValidationError));

            RuleFor(a => a.AddressId)
                .NotEmpty()
                .WithMessage((nameof(OrderRequestModel.AddressId) + " -> " + ErrorMessages.AddressIdValidationError));
        }
    }
}

