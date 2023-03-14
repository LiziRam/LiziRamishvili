using System;
using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Domain.Orders;
using PizzaRestaurant.Domain.Pizzas;
using PizzaRestaurant.Domain.RankHistories;
using PizzaRestaurant.Domain.Users;

namespace PizzaRestaurant.API.Infrastructure.Mappings
{
	public static class MapsterConfiguration
	{
		public static void RegisterMaps(this IServiceCollection services)
		{
            TypeAdapterConfig<AddressRequestModel, Address>
                .NewConfig().TwoWays();

            TypeAdapterConfig<Address, AddressResponseModel>
                .NewConfig().TwoWays();

            TypeAdapterConfig<OrderRequestModel, Order>
               .NewConfig().TwoWays();

            TypeAdapterConfig<Order, OrderResponseModel>
                .NewConfig().TwoWays();

            TypeAdapterConfig<PizzaRequestModel, Pizza>
                .NewConfig().TwoWays();

            TypeAdapterConfig<Pizza, PizzaResponseModel>
                .NewConfig().TwoWays();

            TypeAdapterConfig<RankHistoryRequestModel, RankHistory>
                .NewConfig().TwoWays();

            TypeAdapterConfig<RankHistory, RankHistoryResponseModel>
                .NewConfig().TwoWays();

            TypeAdapterConfig<UserRequestModel, User>
				.NewConfig().TwoWays();

            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig().TwoWays();
        }
	}
}

