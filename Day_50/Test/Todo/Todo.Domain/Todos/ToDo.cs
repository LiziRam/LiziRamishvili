using System;
using Todo.Domain.Base;
using Todo.Domain.Subtasks;
using Todo.Domain.Users;

namespace Todo.Domain.Todos
{
	public class ToDo : BaseEntity
    {
        public ToDo()
        {
            CreatedAt = DateTime.Now;
            Status = Status.Active;
            ModifiedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int UserId { get; set; }

        //Navigation Prop
        public User User { get; set; }
        public List<Subtask> Subtasks { get; set; }
    }
}

