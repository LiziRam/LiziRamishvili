using EvenetsManagement.Infrastructure;
using EvenetsManagement.Infrastructure.Events;
using EvenetsManagement.Infrastructure.Periods;
using EvenetsManagement.Infrastructure.Transactions;
using EvenetsManagement.Infrastructure.Users;
using EventsManagement.Application;
using EventsManagement.Application.Events;
using EventsManagement.Application.Events.Repositories;
using EventsManagement.Application.Periods;
using EventsManagement.Application.Periods.Repositories;
using EventsManagement.Application.Transactions;
using EventsManagement.Application.Transactions.Repositories;
using EventsManagement.Application.Users;
using EventsManagement.Application.Users.Repositories;

namespace EventsManagement.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();

            services.AddScoped<IContextWrapper, ContextWrapper>();
        }
    }
}
