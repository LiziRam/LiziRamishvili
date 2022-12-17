using System;
namespace Practice_24._1
{
	public class Customer
	{
		private int _customerId;
		private string _customerName;

		public Customer(int id, string name)
		{
			_customerId = id;
			_customerName = name;
		}

		public int CustomerId { get { return _customerId; }  }
        public string CustomerName { get { return _customerName; } }
    }
}

