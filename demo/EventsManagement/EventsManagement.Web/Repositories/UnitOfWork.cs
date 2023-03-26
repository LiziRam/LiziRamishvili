using EventsManagement.Application.Users.Repositories;
using EventsManagement.Web.Core.Repositories;

namespace EventsManagement.Web.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }

        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
    }
}
