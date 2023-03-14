using System;
using PizzaRestaurant.Domain.RankHistories;

namespace PizzaRestaurant.Infrastructure.RankHistories
{
	public interface IRankHistoryRepository
	{
        Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken);
        Task<RankHistory> GetByIdAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, RankHistory rankHistory);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        Task<double> AverageRank(CancellationToken cancellationToken, int pizzaId);
    }
}

