﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Location
    {
        public string Name { get; }
        public string Address { get; }
        public float Latitude { get; }
        public float Longitude { get; }
    }
}
