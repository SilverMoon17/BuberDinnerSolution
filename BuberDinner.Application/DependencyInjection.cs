using BuberDinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BuberDinner.Application.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Command;
using BuberDinner.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using System.Reflection;

namespace BuberDinner.Application.Services.Authentication.Commands;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}