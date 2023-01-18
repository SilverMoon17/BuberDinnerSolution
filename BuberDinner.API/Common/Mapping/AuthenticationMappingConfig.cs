using BuberDinner.Application.Services.Authentication.Command;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>().Map(dest => dest, src => src.User);
        }
    }
}
