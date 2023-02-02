using System;
namespace PizzaRestaurant.Domain.RankHistories
{
	public class RankHistory
	{
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int PizzaId { get; set; }
        public double Rank { get; set; } 
    }
}

