using System;
namespace Practice_18._1
{
	public class LinkedItem<T>
	{
		private int _elems;
		private Node<T> _firstNode;

		public LinkedItem()
		{
			_firstNode = null;
			_elems = 0;
		}

		public int ElemCount
		{
			get
			{
				return _elems;
			}
		}

		public T this[int index]
		{
			get
			{
				if(index > _elems - 1)
				{
					throw new OutOfLinkedItemBoundsException();
				}
				else
				{
                    Node<T> newNode = _firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        newNode = newNode.NextNode;
                    }
                    return newNode.Value;
                }
			}
			set
			{
				if(_elems != 0)
				{
                    Node<T> temp = _firstNode;
                    for (int i = 0; i < _elems - 1; i++)
                    {
                        temp = temp.NextNode;
                    }
                    temp.NextNode = new Node<T>(value);
                    _elems++;

                    
                }
				else
				{
                    _firstNode = new Node<T>(value);
                    _elems++;
                }
			}
		}
	}
}

