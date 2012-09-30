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
            if (Routes.Where(x => x.StartPoint == route.StartPoint && x.FinalPoint == route.FinalPoint).Count() > 0)
                throw new Exception("The route between this points is already exist.");

            if (route.StartPoint == route.FinalPoint)
                throw new Exception("For a given route, the starting and final point could not be the same.");

            Routes.Add(route);
        }
    }
}
