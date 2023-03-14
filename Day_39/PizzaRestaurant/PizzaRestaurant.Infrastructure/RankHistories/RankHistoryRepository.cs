using System;
using PizzaRestaurant.Domain.Orders;
using PizzaRestaurant.Domain.Pizzas;
using PizzaRestaurant.Domain.RankHistories;
using PizzaRestaurant.Infrastructure.CustomExceptions;

namespace PizzaRestaurant.Infrastructure.RankHistories
{
	public class RankHistoryRepository : IRankHistoryRepository 
	{
        private static List<RankHistory> _data = new List<RankHistory>
        {
            new RankHistory{Id = 1, UserId = 1, PizzaId = 1, Rank = 9},
            new RankHistory{Id = 2, UserId = 2, PizzaId = 2, Rank = 7},
        };

        public async Task CreateAsync(CancellationToken cancellationToken, RankHistory rankHistory)
        {
            if (_data.Exists(x => x.Id == rankHistory.Id))
                throw new AlreadyCreatedException();

            rankHistory.Id = _data.Max(x => x.Id) + 1;
            await Task.Delay(10, cancellationToken);
            _data.Add(rankHistory);
        }

        public async Task<RankHistory> GetByIdAsync(CancellationToken cancellationToken, int id)
        {
            return await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
        }

        public async Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(_data);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var rank = await Task.FromResult(_data.SingleOrDefault(x => x.Id == id));
            if (rank == null)
            {
                return false;
            }
            return true;
        }

        public async Task<double> AverageRank(CancellationToken cancellationToken, int pizzaId)
        {
            double sum = 0;
            double count = 0;
            foreach(var rank in _data)
            {
                if(rank.PizzaId == pizzaId)
                {
                    sum += rank.Rank;
                    count++;
                }
            }

            if(count == 0)
            {
                return -1;
            }

            return sum / count;
        }
    }
}

