using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.User;

namespace BuberDinner.Infrastructure.Persistence
{
    internal class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
