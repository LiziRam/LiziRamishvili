using System;
using Todo.Application.Users.Requests;
using Todo.Application.Users.Responses;

namespace Todo.Application.Users
{
    public interface IUserService
    {
        Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken, UserCreateRequestModel userCreateRequest);
        Task<string> AuthenticateAsync(CancellationToken cancellationToken, string username, string password);
        Task<int> GetIdByUsername(CancellationToken cancellationToken, string username);
    }
}

