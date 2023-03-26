using EventsManagement.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EvenetsManagement.Infrastructure
{
    public class ContextWrapper : IContextWrapper
    {
        protected readonly DbContext _context;

        public ContextWrapper(DbContext context) => _context = context;

        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        public async Task SaveChanges(CancellationToken token) => await _context.SaveChangesAsync(token);
    }
}
