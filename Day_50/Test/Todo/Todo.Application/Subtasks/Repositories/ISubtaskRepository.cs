using System;
using Todo.Application.Subtasks.Responses;
using Todo.Domain.Subtasks;

namespace Todo.Application.Subtasks.Repositories
{
    public interface ISubtaskRepository
    {
        Task CreateAsync(CancellationToken cancellationToken, Subtask subToInsert, Domain.Todos.ToDo todo);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);
        Task<Subtask> GetAsync(CancellationToken cancellationToken, int id);
        Task UpdateAsync(CancellationToken cancellationToken, Subtask subToUpdate);
    }
}

