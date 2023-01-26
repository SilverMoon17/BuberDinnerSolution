using BuberDinner.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        private AverageRating(double value, int numRatings)
        {
            Value = value;
            NumRatings = numRatings;
        }
        public double Value { get; private set; }
        public int NumRatings { get; private set; }

        public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
        {
            return new AverageRating(rating, numRatings);
        }

        public void AddNewRating(double rating)
        {
            Value = ((Value * NumRatings) + rating) / ++NumRatings;
        }

        public void RemoveRating(double rating)
        {
            Value = ((Value * NumRatings) - rating) / --NumRatings;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
