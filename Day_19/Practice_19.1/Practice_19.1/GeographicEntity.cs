using System;
namespace Practice_19._1
{
	public abstract class GeographicEntity
	{
		private string _name;
		private double _area;
		private int _population;

		public virtual string Name { get{ return _name; } set { _name = value; } }
        public virtual double Area { get { return _area; } set { _area = value; } }
        public virtual int Population { get { return _population; } set { _population = value; } }
	}
}

