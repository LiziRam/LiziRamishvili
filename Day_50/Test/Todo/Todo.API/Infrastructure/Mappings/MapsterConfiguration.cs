using System;
using System.Net;
using Mapster;
using Todo.Application.Subtasks.Requests;
using Todo.Application.Subtasks.Responses;
using Todo.Application.Todos.Requests;
using Todo.Application.Todos.Responses;
using Todo.Application.Users.Requests;
using Todo.Application.Users.Responses;
using Todo.Domain.Subtasks;
using Todo.Domain.Todos;
using Todo.Domain.Users;

namespace Todo.API.Infrastructure.Mappings
{
	public static class MapsterConfiguration
	{
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<UserCreateRequestModel, User>
            .NewConfig().Map(x => x.PasswordHash, y => y.Password);

            TypeAdapterConfig<UserLoginRequestModel, User>
            .NewConfig().Map(x => x.PasswordHash, y => y.Password);

            TypeAdapterConfig<User, UserResponseModel>
               .NewConfig().Map(x => x.Password, y => y.PasswordHash);
        }
    }
}

