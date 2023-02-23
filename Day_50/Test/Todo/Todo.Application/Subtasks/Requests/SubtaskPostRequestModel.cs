using System;
namespace Todo.Application.Subtasks.Requests
{
	public class SubtaskPostRequestModel
	{
        public string Title { get; set; }
        public int ToDoId { get; set; }
    }
}

