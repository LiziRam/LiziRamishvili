using System;
namespace Todo.Application.Subtasks.Responses
{
	public class SubtaskResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public int ToDoId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

