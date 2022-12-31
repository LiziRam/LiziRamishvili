using System;
namespace Practice_24._1
{
	public class Order
	{
		private int _orderId;
		private string _date;
		private string _product;
		private double _price;
		private int _customerId;

        public Order(int orderId, string date, string product, double price, int customerId)
		{
			_orderId = orderId;
			_date = date;
			_product = product;
			_price = price;
			_customerId = customerId;
		}

		public int OrderId { get { return _orderId; } }
        public string Date { get { return _date; } }
        public string Product { get { return _product; } }
        public double Price { get { return _price; } }
        public int CustomerId { get { return _customerId; } }
    }
}

