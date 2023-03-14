using PersonManagement.Services.Abstractions;
using PersonManagement.Services.Implementations;

namespace PersonManagement.Web.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
