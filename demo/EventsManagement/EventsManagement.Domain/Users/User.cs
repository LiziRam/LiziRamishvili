using EventsManagement.Domain.Events;
using EventsManagement.Domain.Transactions;
using Microsoft.AspNetCore.Identity;

namespace EventsManagement.Domain.Users
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
        }

        public override string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        //Nav prop
        public List<Event> Events { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
