using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class DinnerReservations : Entity <ReservationId>
    {
        public int GuestCount { get; }
        public string ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private DinnerReservations(ReservationId reservationId, int guestCount, string reservationStatus, GuestId guestId, BillId billId, DateTime? arrivalDateTime, DateTime createdDateTime, DateTime updatedDateTime) : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static DinnerReservations Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId)
        {
            return new(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, null, DateTime.UtcNow, DateTime.UtcNow);
        }

    }
}
