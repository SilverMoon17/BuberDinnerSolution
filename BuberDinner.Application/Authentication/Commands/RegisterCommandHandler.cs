﻿using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Commands
{
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Validate the user doesn't exists
            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // 2.Create user (generate unique ID) & Persists to DB
            var user = new User { FirstName = command.FirstName, LastName = command.LastName, Email = command.Email, Password = command.Password };

            _userRepository.Add(user);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
