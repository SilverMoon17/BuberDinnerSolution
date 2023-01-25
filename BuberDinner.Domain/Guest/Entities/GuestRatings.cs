using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Guest.Entities
{
    public sealed class GuestRatings : Entity<GuestRatingId>
    {
        

        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public float Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public GuestRatings(GuestRatingId guestRatingId, HostId hostId, DinnerId dinnerId, float rating, DateTime createdDateTime, DateTime updatedDateTime) : base(guestRatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public GuestRatings Create(HostId hostId, DinnerId dinnerId, float rating, DateTime createdDateTime, DateTime updatedDateTime)
        {
            return new(GuestRatingId.CreateUnique(), hostId, dinnerId, rating, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
