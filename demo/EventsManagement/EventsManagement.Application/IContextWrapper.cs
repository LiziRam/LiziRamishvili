using Microsoft.EntityFrameworkCore.Storage;

namespace EventsManagement.Application
{
    public interface IContextWrapper
    {
        Task SaveChanges(CancellationToken token);

        IDbContextTransaction BeginTransaction();
    }
}
