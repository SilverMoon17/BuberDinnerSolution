using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Command
{
    public record AuthenticationResult(
        User User,
        string Token);
}
