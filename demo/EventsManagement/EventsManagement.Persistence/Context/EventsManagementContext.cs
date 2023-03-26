using EventsManagement.Domain.Events;
using EventsManagement.Domain.Periods;
using EventsManagement.Domain.Transactions;
using EventsManagement.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsManagement.Persistence.Context
{
    public class EventsManagementContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public EventsManagementContext(DbContextOptions<EventsManagementContext> options) : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Period> Periods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventsManagementContext).Assembly);
        }
    }
}
