using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<DinnerReservations> _reservations = new();

        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime StartedDateTime { get; }
        public DateTime EndedDateTime { get; }
        public string Status { get; }
        public bool IsPublic { get; }
        public int MaxGuests { get; }
        public Price Price { get; }
        public HostId HostId { get; }
        public MenuId MenuId { get; }
        public string ImageUrl { get; }
        public Location Location { get; }

        public IReadOnlyList<DinnerReservations> Reservations => _reservations.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public Dinner(DinnerId dinnerId,string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, string status, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location) : base(dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
        }

        public static Dinner Create(string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime startedDateTime, DateTime endedDateTime, string status, bool isPublic, int maxGuests, Price price, HostId hostId, MenuId menuId, string imageUrl, Location location)
        {
            return new(DinnerId.CreateUnique(), name, description, DateTime.UtcNow, DateTime.UtcNow, null, null, status, isPublic, maxGuests, price, hostId, menuId, imageUrl, location);
        }

    }
}
