using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace trains
{
    public class RoutesCalculator
    {
        private IList<Route> routes;

        public IList<Route> Routes { get { return routes ?? (routes = new List<Route>()); } }

        public void InsertRoute(Route route)
        {
            if (0 == Routes.Where(x => x.InitialPoint == route.InitialPoint && x.FinalPoint == route.FinalPoint).Count())
                Routes.Add(route);
            else
                throw new Exception("The route between this points is already exist.");
        }
    }
}
