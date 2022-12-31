using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice_19._1
{
	public class Country : GeographicEntity 
	{
		private List<City> _cities;
		private double _area;
        private int _population;
        private string _name;

		public Country(string name, List<City> cities)
		{
            _name = name;
			_cities = cities;

		}

        public string this[int index]
        {
            get
            {
                return _cities[index].Name;
            }
        }

        public override string Name { get { return _name; } }

		public override double Area
		{
			get
			{
                foreach (var elem in _cities)
                {
                    _area += elem.Area;
                }
                return _area;
            }
		}

        public override int Population
        {
            get
            {
                foreach (var elem in _cities)
                {
                    _population += elem.Population;
                }
                return _population;
            }
        }

        public int Count { get { return _cities.Count; } }
    }
}

