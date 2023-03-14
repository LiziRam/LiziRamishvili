using System;
using Todo.Domain.Base;
using Todo.Domain.Todos;

namespace Todo.Domain.Users
{
	public class User : BaseEntity
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        //Navigation Prop
        public List<ToDo> ToDos { get; set; }
    }
}

