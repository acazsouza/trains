using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public class Trip
    {
        private IList<City> cities;

        public IList<City> Cities { get { return cities ?? (cities = new List<City>()); } }
    }
}
