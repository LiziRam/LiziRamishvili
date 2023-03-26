using System.ComponentModel.DataAnnotations;

namespace EventsManagement.Application.Users.Requests
{
    public class UserCreateRequestModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}
