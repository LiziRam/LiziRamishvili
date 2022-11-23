using System;
namespace Practice_16
{
	public interface IMathOperation<T>
	{
		T Add(T object1, T object2);
		T Subtract(T object1, T object2);
		T Multiply(T object1, T object2);
	}
}

