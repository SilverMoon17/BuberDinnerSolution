using BuberDinner.Domain.User;

namespace BuberDinner.Application.Services.Authentication.Command
{
    public record AuthenticationResult(
        User User,
        string Token);
}
