using System;
namespace PizzaRestaurant.Application.RankHistories.Responses
{
    public class RankHistoryResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public double Rank { get; set; }
    }
}

