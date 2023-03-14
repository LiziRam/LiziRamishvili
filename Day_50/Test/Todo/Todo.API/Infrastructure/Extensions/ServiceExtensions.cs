using System;
using Todo.Application.Subtasks;
using Todo.Application.Subtasks.Repositories;
using Todo.Application.Todos;
using Todo.Application.Todos.Repositories;
using Todo.Application.Users;
using Todo.Application.Users.Repositories;
using Todo.Infrastructure.Subtasks;
using Todo.Infrastructure.Todos;
using Todo.Infrastructure.Users;

namespace Todo.API.Infrastructure.Extensions
{
	public static class ServiceExtensions
	{
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IToDoRepository, ToDoRepository>();

            services.AddScoped<ISubtaskService, SubtaskService>();
            services.AddScoped<ISubtaskRepository, SubtaskRepository>();
        }
    }
}

