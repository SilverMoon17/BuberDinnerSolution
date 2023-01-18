using BuberDinner.Application.Services.Authentication.Command;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Queries
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>
    { }
}
