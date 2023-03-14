using System;
using Mapster;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Domain.Orders;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.Application.Orders
{
	public class OrderService : IOrderService 
	{
        private IOrderRepository _orderRepo;
        private IPizzaRepository _pizzaRepo;
        private IUserRepository _userRepo;
        private IAddressRepository _addressRepo;

        public OrderService(IOrderRepository orderRepo, IPizzaRepository pizzaRepo, IUserRepository userRepo, IAddressRepository addressRepo)
        {
            _orderRepo = orderRepo;
            _pizzaRepo = pizzaRepo;
            _userRepo = userRepo;
            _addressRepo = addressRepo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, OrderRequestModel order)
        {
            var orderToInsert = order.Adapt<Order>();

            //არსებობს თუ არა პიცა აიდი
            var existsPizza = await _userRepo.Exists(cancellationToken, orderToInsert.PizzaId);
            if (!existsPizza)
            {
                throw new PizzaIdNotFoundException();
            }
            //არსებობს თუ არა იუზერ აიდი
            var existsUser = await _userRepo.Exists(cancellationToken, orderToInsert.UserId);
            if (!existsUser)
            {
                throw new UserIdNotFoundException();
            }
            //არსებობს თუ არა მისამართის აიდი
            var existsAddress = await _userRepo.Exists(cancellationToken, orderToInsert.AddressId);
            if (!existsAddress)
            {
                throw new AddressIdNotFoundException();
            }

            //მისამართის აიდი ეკუთვნის თუ არა იუზერის აიდის
            var address = await _addressRepo.GetByIdAsync(cancellationToken, orderToInsert.AddressId);
            if(address.UserId != orderToInsert.UserId)
            {
                throw new WrongAddressException();
            }
            
            await _orderRepo.CreateAsync(cancellationToken, orderToInsert);
        }

        public async Task<OrderResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var res = await _orderRepo.GetByIdAsync(cancellationToken, id);
            if (res == null)
                throw new NotFoundException();
            else
                return res.Adapt<OrderResponseModel>();
        }

        public async Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res = await _orderRepo.GetAllAsync(cancellationToken);
            return res.Adapt<List<OrderResponseModel>>();
        }
    }
}

