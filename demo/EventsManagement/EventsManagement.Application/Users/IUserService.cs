using EventsManagement.Application.Events.Responses;
using EventsManagement.Application.Users.Requests;
using EventsManagement.Application.Users.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace EventsManagement.Application.Users
{
    public interface IUserService
    {
        Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken,
            UserCreateRequestModel userCreateRequest);

        Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id);

        Task<int> GetIdByUsername(CancellationToken cancellationToken, string username);
        Task<string> AuthenticateAsync(CancellationToken cancellationToken, string username, string password);

        Task UpdateAsync(CancellationToken cancellationToken, UserEditRequestModel eventEditRequest, int id);

        Task<UserResponseForAdminModel> GetUserByIdAsync(CancellationToken cancellationToken, int id);
        Task<List<UserResponseForAdminModel>> GetAllActiveUsersAsync(CancellationToken cancellationToken);
        
    }
}
