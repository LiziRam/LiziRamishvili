using Microsoft.AspNetCore.Identity;

namespace EventsManagement.Web.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole<int>> GetRoles();
    }
}
