using System;
using Microsoft.AspNetCore.JsonPatch;
using Todo.Application.Todos.Requests;
using Todo.Application.Todos.Responses;
using Todo.Domain;

namespace Todo.Application.Todos
{
    public interface IToDoService
    {
        Task CreateAsync(CancellationToken cancellationToken, ToDoRequestModel todoCreateRequest, int userId);
        Task DeleteAsync(CancellationToken cancellationToken, int id, int userId);
        Task<List<ToDoResponseModel>> GetAllAsync(CancellationToken cancellationToken, int userId, Status status);
        Task<ToDoResponseModel> GetAsync(CancellationToken cancellationToken, int id, int userId);
        Task UpdateAsync(CancellationToken cancellationToken, ToDoRequestPutModel todoPutRequest, int userId);
        Task UpdateStatusAsync(CancellationToken cancellationToken, TodoStatusRequestModel todoStatusRequest, int userId);
        Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id, int userId);
        
    }

}

