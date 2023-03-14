using System;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Domain.Orders;
using PizzaRestaurant.Infrastructure.CustomExceptions;

namespace PizzaRestaurant.Infrastructure.Orders
{
	public class OrderRepository : IOrderRepository
	{
        private static List<Order> _data = new List<Order>
        {
            new Order{Id = 1, UserId = 1, AddressId = 1, PizzaId = 1 },
            new Order{Id = 2, UserId = 2, AddressId = 2, PizzaId = 2 },
        };

        public async Task CreateAsync(CancellationToken cancellationToken, Order order)
        {
            if (_data.Exists(x => x.Id == order.Id))
                throw new AlreadyCreatedException();

            order.Id = _data.Max(x => x.Id) + 1;
            await Task.Delay(1000, cancellationToken);
            _data.Add(order);
        }

        public async Task<Order> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data);
        }

        public async Task<bool> ExistsById(CancellationToken cancellationToken, int id)
        {
            var order = await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
            if (order == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int userId, int pizzaId)
        {
            foreach(var order in _data)
            {
                if(order.UserId == userId && order.PizzaId == pizzaId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

