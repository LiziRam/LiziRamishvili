using System;
namespace Practice_19._1
{
	public class City : GeographicEntity 
	{
		private string _name;
		private double _area;
		private int _population;
		private string _country;
		private bool _isCapital;

		public City(string name, double area, int population, string country, bool isCapital)
		{
			_name = name;
			_area = area;
			_population = population;
			_country = country;
			_isCapital = isCapital;
		}

		public override string Name { get { return _name; } }
        public override double Area { get { return _area; } }
        public override int Population { get { return _population; } }
        public string Country { get { return _country; } }
        public bool isCapital { get { return _isCapital; } }
    }
}

