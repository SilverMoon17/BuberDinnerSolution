using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BuberDinner.API.Common.Mapping;

namespace BuberDinner.Application.Services.Authentication.Commands;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        return services;
    }
}