using System;
using Mapster;
using PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Domain.Pizzas;
using PizzaRestaurant.Application.Pizzas;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Domain.Addresses;
using PizzaRestaurant.Infrastructure.RankHistories;

namespace PizzaRestaurant.Application.Pizzas
{
	public class PizzaService : IPizzaService 
	{
        private IPizzaRepository _pizzaRepo;
        private IRankHistoryRepository _rankRepo;

        public PizzaService(IPizzaRepository repo, IRankHistoryRepository rankRepo)
        {
            _pizzaRepo = repo;
            _rankRepo = rankRepo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, PizzaRequestModel pizza)
        {
            var pizzaToInsert = pizza.Adapt<Pizza>(); 
            await _pizzaRepo.CreateAsync(cancellationToken, pizzaToInsert);
        }

        public async Task<PizzaResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var res = await _pizzaRepo.GetByIdAsync(cancellationToken, id);
            if (res == null)
                throw new NotFoundException();
            else
            {
                var responsePizza = await Task.FromResult(res.Adapt<PizzaResponseModel>());
                responsePizza.Rank = await _rankRepo.AverageRank(cancellationToken, id);
                return responsePizza;
            }
        }

        public async Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res = await _pizzaRepo.GetAllAsync(cancellationToken);
            if (res == null)
                throw new EmptyListException();
            else
            {
                var responsePizzaModel =  res.Adapt<List<PizzaResponseModel>>();
                foreach (var elem in responsePizzaModel)
                {
                    elem.Rank = await _rankRepo.AverageRank(cancellationToken, elem.Id);
                }
                return responsePizzaModel;
            }
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, PizzaRequestModel pizza, int id)
        {
            if (!await _pizzaRepo.Exists(cancellationToken, id))
                throw new NotFoundException();

            var pizzaToUpdate = pizza.Adapt<Pizza>();
            await _pizzaRepo.UpdateAsync(cancellationToken, pizzaToUpdate, id);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (!await _pizzaRepo.Exists(cancellationToken, id))
                throw new NotFoundException();

            await _pizzaRepo.DeleteAsync(cancellationToken, id);
        }
    }
}

