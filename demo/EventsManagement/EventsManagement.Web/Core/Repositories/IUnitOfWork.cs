using EventsManagement.Application.Users.Repositories;

namespace EventsManagement.Web.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }

        IRoleRepository Role { get; }
    }
}
