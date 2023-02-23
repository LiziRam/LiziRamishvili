using System;
using Todo.Application.Subtasks.Responses;
using Todo.Domain;
using Todo.Domain.Subtasks;

namespace Todo.Application.Todos.Responses
{
	public class ToDoResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public List<SubtaskResponseModel> Subtasks { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; } 
    }
}

