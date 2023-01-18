using Mapster;
using PersonManagement.Services.Models;
using PersonManagement.Web.Models;
using PersonManagement.Web.Models.DTO;

namespace PersonManagement.Web.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<PersonDTO, PersonServiceModel>
                .NewConfig()
                .Map(dest => dest.City, src => new CityServiceModel { Name = src.CityName })
                .Map(dest => dest.PersonIdentifier, src => src.Identifier);
            
            TypeAdapterConfig<PersonServiceModel, PersonDTO>
                .NewConfig()
                .Map(dest => dest.CityName, src => src.City)
                .Map(dest => dest.Identifier, src => src.PersonIdentifier);

            TypeAdapterConfig<PersonServiceModel, CreatePersonRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}
