using System;
namespace Practice_18._1
{
	public class Node<T>
	{
		public Node(T value)
		{
			Value = value;
		}

		public T Value { get; }
		public Node<T> NextNode { get; set; }
	}
}

