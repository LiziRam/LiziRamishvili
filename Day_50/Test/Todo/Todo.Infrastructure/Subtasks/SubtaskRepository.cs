using System;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Subtasks.Repositories;
using Todo.Domain.Subtasks;
using Todo.Domain.Todos;
using Todo.Persistence.Context;

namespace Todo.Infrastructure.Subtasks
{
	public class SubtaskRepository : BaseRepository<Subtask>, ISubtaskRepository
	{
		public SubtaskRepository(TodoContext context) : base(context)
        {

		}

        public async Task CreateAsync(CancellationToken cancellationToken, Subtask subToInsert, ToDo todo)
        {
            subToInsert.ModifiedAt = DateTime.Now;
            subToInsert.CreatedAt = DateTime.Now;
            subToInsert.Status = Domain.Status.Active;
            todo.ModifiedAt = DateTime.Now;
            await AddAsync(cancellationToken, subToInsert);
        }

        
        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await AnyAsync(cancellationToken, x => x.Id == id);
        }

        public async Task<Subtask> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _context.Set<Subtask>().SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Subtask subToUpdate)
        {
            var currSub = await _context.Set<Subtask>().SingleOrDefaultAsync(x => x.Id == subToUpdate.Id, cancellationToken);
            currSub.Title = subToUpdate.Title;
            currSub.ModifiedAt = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await RemoveAsync(cancellationToken,id);
        }

    }
}

