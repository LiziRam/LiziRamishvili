using System;
using Microsoft.AspNetCore.JsonPatch;
using Todo.Domain;
using Todo.Domain.Todos;

namespace Todo.Application.Todos.Repositories
{
    public interface IToDoRepository
    {
        Task<int> CreateAsync(CancellationToken cancellationToken, ToDo todoToInsert, int userId);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        Task<List<ToDo>> GetAllAsync(CancellationToken cancellationToken, int userId, Status status);
        Task<ToDo> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, ToDo taskToUpdate);
        Task UpdateStatusAsync(CancellationToken cancellationToken, ToDo taskToUpdateStatus);
        Task PatchAsync(CancellationToken cancellationToken, JsonPatchDocument patchDocument, int id);
       
    }
}

