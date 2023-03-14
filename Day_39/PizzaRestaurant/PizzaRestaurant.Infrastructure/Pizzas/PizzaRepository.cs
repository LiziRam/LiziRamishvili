using System;
using System.Data.Common;
using PizzaRestaurant.Domain.Pizzas;
using PizzaRestaurant.Infrastructure.CustomExceptions;

namespace PizzaRestaurant.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        private static List<Pizza> _data = new List<Pizza>
        {
            new Pizza{Id = 1, Name = "Pepperoni", Description = "Top rated", Price = 12.5, CaloryCount = 700},
            new Pizza{Id = 2, Name = "Margharita", Description = "Vegetarian", Price = 10.5, CaloryCount = 500},
        };

        public async Task CreateAsync(CancellationToken cancellationToken, Pizza pizza)
        {
            if (_data.Exists(x => x.Id == pizza.Id))
            {
                throw new AlreadyCreatedException();
            }

            pizza.Id = _data.Max(x => x.Id) + 1;
            await Task.Delay(1000, cancellationToken);
            _data.Add(pizza);
        }

        public async Task<List<Pizza>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data);
        }

        public async Task<Pizza> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Pizza pizza, int id)
        { 
            int index = _data.IndexOf(_data.SingleOrDefault(x => x.Id == id));
            pizza.Id = id;
            await Task.Delay(1000, cancellationToken);
            _data[index] = pizza;
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var pizza = await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
            if(pizza == null)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var pizza = await GetByIdAsync(cancellationToken, id);
            
            await Task.Delay(1000, cancellationToken);
            _data.Remove(pizza);
        }
    }
}

