using System;
using Mapster;
using PizzaRestaurant.Application.ExceptionHandling.CustomExceptions;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Domain.RankHistories;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.RankHistories;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.Application.RankHistories
{
	public class RankHistoryService : IRankHistoryService
	{
        private IRankHistoryRepository _rankRepo;
        private IPizzaRepository _pizzaRepo;
        private IUserRepository _userRepo;
        private IOrderRepository _orderRepo;

        public RankHistoryService(IRankHistoryRepository rankRepo, IPizzaRepository pizzaRepo, IUserRepository userRepo, IOrderRepository orderRepo)
        {
            _rankRepo = rankRepo;
            _pizzaRepo = pizzaRepo;
            _userRepo = userRepo;
            _orderRepo = orderRepo;
        }

        public async Task CreateAsync(CancellationToken cancellationToken, RankHistoryRequestModel rankHistory)
        {
            var rankHistoryToInsert = rankHistory.Adapt<RankHistory>();

            //არსებობს თუ არა პიცა აიდი
            var existsPizza = await _userRepo.Exists(cancellationToken, rankHistoryToInsert.PizzaId);
            if (!existsPizza)
            {
                throw new PizzaIdNotFoundException();
            }
            //არსებობს თუ არა იუზერ აიდი
            var existsUser = await _userRepo.Exists(cancellationToken, rankHistoryToInsert.UserId);
            if (!existsUser)
            {
                throw new UserIdNotFoundException();
            }

            //შეუკვეთავს თუ არა ამ აიდის იუზერს ამ აიდის პიცა
            var existsOrder = await _orderRepo.Exists(cancellationToken, rankHistoryToInsert.UserId, rankHistoryToInsert.PizzaId);
            if (!existsOrder)
            {
                throw new OrderNotFoundException();
            }

            await _rankRepo.CreateAsync(cancellationToken, rankHistoryToInsert);
        }

        public async Task<RankHistoryResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var res = await _rankRepo.GetByIdAsync(cancellationToken, id);
            if (res == null)
                throw new NotFoundException();
            else
                return res.Adapt<RankHistoryResponseModel>();
        }

        public async Task<List<RankHistoryResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res = await _rankRepo.GetAllAsync(cancellationToken);
            return res.Adapt<List<RankHistoryResponseModel>>();
        }
    }
}

