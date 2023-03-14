using System;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using Todo.Domain.Users;
using Todo.Domain.Todos;
using Todo.Domain.Subtasks;

namespace Todo.Persistence.Context
{
	public class TodoContext : DbContext
	{
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

		}

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> Todos { get; set; } 
        public DbSet<Subtask> Subtasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
        }
    }
}

