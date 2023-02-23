using System;
using Todo.Application.Subtasks.Requests;
using Todo.Domain;

namespace Todo.Application.Todos.Requests
{
	public class ToDoRequestPutModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
    }
}

