using System;
namespace PizzaRestaurant.Application.RankHistories.Requests
{
	public class RankHistoryRequestModel
	{
        public int UserId { get; set; } 
        public int PizzaId { get; set; } 
        public int Rank { get; set; } 
    }
}

