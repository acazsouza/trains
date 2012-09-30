using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public struct Route
    {
        public char InitialPoint { get; private set; }

        public char FinalPoint { get; private set; }

        public int Distance { get; private set; }

        public Route(char initialPoint, char finalPoint, int distance) : this()
        {
            this.InitialPoint = initialPoint;
            this.FinalPoint = finalPoint;
            this.Distance = distance;
        }
    }
}
