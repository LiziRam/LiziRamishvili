using System;
using Azure;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Todos.Repositories;
using Todo.Domain;
using Todo.Domain.Todos;
using Todo.Persistence.Context;
using Microsoft.AspNetCore.JsonPatch;

namespace Todo.Infrastructure.Todos
{

    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(TodoContext context) : base(context)
        {

        }

        public async Task<int> CreateAsync(CancellationToken cancellationToken, ToDo todoToInsert, int userId)
        {
            todoToInsert.CreatedAt = DateTime.Now;
            todoToInsert.ModifiedAt = DateTime.Now;
            todoToInsert.Status = Domain.Status.Active;
            todoToInsert.UserId = userId;

            await AddAsync(cancellationToken, todoToInsert);
            return todoToInsert.Id;
        }

        public async Task<List<ToDo>> GetAllAsync(CancellationToken cancellationToken, int userId, Status status)
        {
            if(status == null)
            {
                return await _context.Set<ToDo>().Where(x => x.UserId == userId).Include(x => x.Subtasks).ToListAsync();
            }
            else
            {
                return await _context.Set<ToDo>().Where(x => x.UserId == userId && x.Status == status).Include(x => x.Subtasks).ToListAsync();
            }
            
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await AnyAsync(cancellationToken, x => x.Id == id);
        }

        public async Task<ToDo> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _context.Set<ToDo>().Include(x => x.Subtasks).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ToDo taskToUpdate)
        {
            var currTask = await _context.Set<ToDo>().Include(x => x.Subtasks).SingleOrDefaultAsync(x => x.Id == taskToUpdate.Id, cancellationToken);
            currTask.Title = taskToUpdate.Title;
            currTask.TargetCompletionDate = taskToUpdate.TargetCompletionDate;
            currTask.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStatusAsync(CancellationToken cancellationToken, ToDo taskToUpdateStatus)
        {
            var currTask = await _context.Set<ToDo>().Include(x => x.Subtasks).SingleOrDefaultAsync(x => x.Id == taskToUpdateStatus.Id, cancellationToken);
            currTask.Status = taskToUpdateStatus.Status;

            currTask.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task PatchAsync(CancellationToken cancellationToken, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument patchDocument, int id)
        {
            var taskToPatch = await _context.Set<ToDo>().FindAsync(id);
            if (taskToPatch != null)
            {
                patchDocument.ApplyTo(taskToPatch);
                taskToPatch.ModifiedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var todoToChangeStatus = await GetAsync(cancellationToken, id);
            todoToChangeStatus.Status = Status.Deleted;
            
            await UpdateAsync(cancellationToken, todoToChangeStatus);
        }
    }
}

