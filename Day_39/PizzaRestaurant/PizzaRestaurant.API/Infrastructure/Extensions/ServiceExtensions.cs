using System;
using PizzaRestaurant.Application.Addresses;
using PizzaRestaurant.Application.Orders;
using PizzaRestaurant.Application.Pizzas;
using PizzaRestaurant.Application.RankHistories;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.RankHistories;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
	public static class ServiceExtensions
	{
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();

            services.AddScoped<IRankHistoryService, RankHistoryService>();
            services.AddScoped<IRankHistoryRepository, RankHistoryRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

