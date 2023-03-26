using EventsManagement.Persistence.Context;
using EventsManagement.Web.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace EventsManagement.Web.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EventsManagementContext _context;

        public RoleRepository(EventsManagementContext context) => _context = context;

        public ICollection<IdentityRole<int>> GetRoles() => _context.Roles.ToList();
    }
}
