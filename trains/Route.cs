using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public struct Route
    {
        public char StartPoint { get; private set; }

        public char FinalPoint { get; private set; }

        public int Distance { get; private set; }

        public Route(char startPoint, char finalPoint, int distance) : this()
        {
            this.StartPoint = startPoint;
            this.FinalPoint = finalPoint;
            this.Distance = distance;
        }
    }
}
