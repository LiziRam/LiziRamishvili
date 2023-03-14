using System;
using Todo.Application.Subtasks.Requests;

namespace Todo.Application.Todos.Requests
{
	public class ToDoRequestModel
	{
		public string Title { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
		public List<SubtaskRequestModel> Subtasks { get; set; }
	}
}

