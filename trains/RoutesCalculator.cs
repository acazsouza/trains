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
            if (Routes.Where(x => x.StartCity.Id == route.StartCity.Id && x.EndCity.Id == route.EndCity.Id).Count() > 0)
                throw new Exception("The route between this cities is already exist.");

            if (route.StartCity.Id == route.EndCity.Id)
                throw new Exception("For a given route, the starting and end city could not be the same.");

            Routes.Add(route);
        }

        public int? CalculateDistance(params City[] cities)
        {
            int distance = 0;

            for (int i = 0; i < (cities.Count() - 1); i++)
            {
                Route route;

                try
                {
                    route = Routes.Where(x => x.StartCity.Id == cities[i].Id && x.EndCity.Id == cities[i + 1].Id).First();
                }
                catch (Exception ex)
                {
                    return -1;
                }

                distance += route.Distance;
            }

            return distance;
        }

        public int? NumberOfPossibleTrips(City startCity, City endCity, int numberOfStops)
        {
            int possibleTrips = 0;

            for (int i = 0; i < (cities.Count() - 1); i++)
            {
                Route route;

                try
                {
                    route = Routes.Where(x => x.StartCity.Id == cities[i].Id && x.EndCity.Id == cities[i + 1].Id).First();
                }
                catch (Exception ex)
                {
                    return -1;
                }

                distance += route.Distance;
            }

            return possibleTrips;
        }

        /*public int NumberOfTrips(char )
        {
        }*/
    }
}
