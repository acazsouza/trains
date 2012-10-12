using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public class City
    {
        public char Id { get; set; }

        private Dictionary<City, int> connections;
        public Dictionary<City, int> Connections { get { return connections ?? (connections = new Dictionary<City, int>()); } }

        public City(char id)
        {
            Id = id;
        }
    }
}
