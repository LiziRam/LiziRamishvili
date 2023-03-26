using EventsManagement.Domain.Users;
using EventsManagement.Web.Core.Constants;
using EventsManagement.Web.Core.Models;
using EventsManagement.Web.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventsManagement.Web.Controllers
{
    [Authorize(Roles = $"{Constants.Roles.Admin}")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.User.GetAllActiveAsync(cancellationToken).ConfigureAwait(false);
            return View(users);
        }

        public async Task<IActionResult> Edit(CancellationToken cancellationToken, int id)
        {
            var user = await _unitOfWork.User.GetByIdAsync(cancellationToken, id).ConfigureAwait(false);
            var roles = _unitOfWork.Role.GetRoles(); 

            var userRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false); 

            var roleItems = roles.Select(role =>
                new SelectListItem(
                    role.Name,
                    role.Id.ToString(), 
                    userRoles.Any(ur => ur.Contains(role.Name)))).ToList();

            var vm = new EditUserViewModel { User = user, Roles = roleItems };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken, EditUserViewModel data)
        {
            var user = await _unitOfWork.User.GetByIdAsync(cancellationToken, data.User.Id).ConfigureAwait(false);
            if (user == null) return NotFound();

            var userRolesInDb = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            //Loop through the roles in ViewModel
            //Check if the Role is Assigned In DB
            //If Assigned -> Do Nothing
            //If Not Assigned -> Add Role

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null) rolesToAdd.Add(role.Text);
                }
                else
                {
                    if (assignedInDb != null) rolesToDelete.Add(role.Text);
                }
            }

            if (rolesToAdd.Any()) await _userManager.AddToRolesAsync(user, rolesToAdd).ConfigureAwait(false);

            if (rolesToDelete.Any()) await _userManager.RemoveFromRolesAsync(user, rolesToDelete).ConfigureAwait(false);

            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Email = data.User.Email;

            _unitOfWork.User.UpdateAsync(cancellationToken, user);

            return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}
