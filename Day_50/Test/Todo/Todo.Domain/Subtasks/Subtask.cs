using System;
using Todo.Domain.Base;
using Todo.Domain.Todos;

namespace Todo.Domain.Subtasks
{
	public class Subtask : BaseEntity
    {
		public int Id { get; set; }
        public string Title { get; set; }
        public int ToDoId { get; set; }

        //Navigation Prop
        public ToDo ToDo { get; set; }
    }
}

