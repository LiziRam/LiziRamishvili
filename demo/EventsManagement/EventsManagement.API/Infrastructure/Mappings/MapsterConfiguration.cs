using EventsManagement.Application.Users.Requests;
using EventsManagement.Domain.Users;
using Mapster;

namespace EventsManagement.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<UserCreateRequestModel, User>
                .NewConfig().Map(x => x.PasswordHash, y => y.Password);

            TypeAdapterConfig<UserLoginRequestModel, User>
                .NewConfig().Map(x => x.PasswordHash, y => y.Password);

        }
    }
}
