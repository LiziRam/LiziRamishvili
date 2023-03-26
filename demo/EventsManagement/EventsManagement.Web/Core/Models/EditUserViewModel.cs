using EventsManagement.Domain.Users;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventsManagement.Web.Core.Models
{
    public class EditUserViewModel
    {
        public User User { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}
