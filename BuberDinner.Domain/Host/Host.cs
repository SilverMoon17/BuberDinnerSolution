using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string profileImage { get; }
        public float averageRating { get; }
        public UserId UserId { get; }
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Host(HostId hostId, string firstName, string lastName, string profileImage, float averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime) : base(hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            this.profileImage = profileImage;
            this.averageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(string firstName, string lastName, string profileImage, float averageRating, UserId userId, DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(HostId.CreateUnique(), firstName, lastName, profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
