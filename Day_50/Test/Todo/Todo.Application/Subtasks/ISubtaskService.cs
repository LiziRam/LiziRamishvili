using System;
using Todo.Application.Subtasks.Requests;
using Todo.Application.Subtasks.Responses;

namespace Todo.Application.Subtasks
{
    public interface ISubtaskService
    {
        Task CreateAsync(CancellationToken cancellationToken, SubtaskPostRequestModel subPostRequest, int userId);
        Task DeleteAsync(CancellationToken cancellationToken, int id, int userId);
        Task<List<SubtaskResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId, int todoId);
        Task<SubtaskResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId);
        Task UpdateAsync(CancellationToken cancellationToken, SubtaskPutRequestModel subPutRequest, int userId);
    }
}

