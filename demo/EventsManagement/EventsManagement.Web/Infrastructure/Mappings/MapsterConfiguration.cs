using EventsManagement.Application.Users.Requests;
using EventsManagement.Domain.Users;
using Mapster;

namespace EventsManagement.Web.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<UserCreateRequestModel, User>
                .NewConfig().Map(x => x.PasswordHash, y => y.Password);

            TypeAdapterConfig<UserLoginRequestModel, User>
                .NewConfig().Map(x => x.PasswordHash, y => y.Password);

            //რისფონსმოდელში წავშალე პაროლი
            //TypeAdapterConfig<User, UserResponseModel>
            //   .NewConfig().Map(x => x.Password, y => y.PasswordHash);
        }
    }
}
