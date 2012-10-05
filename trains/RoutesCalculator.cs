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

        /*private IEnumerable<Route> GetPossibleRoutesEndIn(City city)
        {
            return Routes.Where(x =>  x.EndCity.Id == city.Id);
        }

        private IEnumerable<Route> GetPossibleRoutesStartIn(City city)
        {
            return Routes.Where(x => x.StartCity.Id == city.Id);
        }*/

        public int? NumberOfPossibleTrips(City startCity, City endCity, int numberOfStops)
        {
            IList<IEnumerable<Route>> possibleTrips = new List<IEnumerable<Route>>();
            IList<Route> trip = new List<Route>();

            foreach (Route route in Routes.Where(x => x.EndCity.Id == endCity.Id))
            {
                trip.Add(route);

                if (route.StartCity.Id == startCity.Id)
                {
                    trip = new List<Route>();
                    possibleTrips.Add(trip);
                } else
                {
                    foreach (Route route2 in Routes.Where(x => x.EndCity.Id == route.StartCity.Id))
                    {
                        trip.Add(route2);

                        if (route2.StartCity.Id == startCity.Id)
                        {
                            trip = new List<Route>();
                            possibleTrips.Add(trip);
                        }
                        else
                        {
                            foreach (Route route3 in Routes.Where(x => x.EndCity.Id == route2.StartCity.Id))
                            {
                                trip.Add(route3);

                                if (route3.StartCity.Id == startCity.Id)
                                {
                                    trip = new List<Route>();
                                    possibleTrips.Add(trip);
                                }
                                else
                                {
                                    foreach (Route route4 in Routes.Where(x => x.EndCity.Id == route3.StartCity.Id))
                                    {
                                        trip.Add(route4);

                                        if (route4.StartCity.Id == startCity.Id)
                                        {
                                            trip = new List<Route>();
                                            possibleTrips.Add(trip);
                                        }
                                        else
                                        {
                                            foreach (Route route5 in Routes.Where(x => x.EndCity.Id == route4.StartCity.Id))
                                            {
                                                trip.Add(route5);

                                                if (route5.StartCity.Id == startCity.Id)
                                                {
                                                    trip = new List<Route>();
                                                    possibleTrips.Add(trip);
                                                }
                                                else
                                                {

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return possibleTrips.Count();
        }

        public string Teste(string teste)
        {
            return Teste(teste);
        }
    }
}
