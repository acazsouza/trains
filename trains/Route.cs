using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public struct Route
    {
        public City StartCity { get; private set; }

        public City EndCity { get; private set; }

        public int Distance { get; private set; }

        public Route(City startCity, City endCity, int distance) : this()
        {
            this.StartCity = startCity;
            this.EndCity = endCity;
            this.Distance = distance;
        }
    }
}
