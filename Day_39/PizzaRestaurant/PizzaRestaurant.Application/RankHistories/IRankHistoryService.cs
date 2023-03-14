using System;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;

namespace PizzaRestaurant.Application.RankHistories
{
	public interface  IRankHistoryService
	{
        Task<List<RankHistoryResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<RankHistoryResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, RankHistoryRequestModel rankHistory);
    }
}

