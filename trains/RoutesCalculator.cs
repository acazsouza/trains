using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace trains
{
    public class RoutesCalculator
    {
        private IList<Route> routes;

        private IList<GraphNode> GraphNodes { get; set; }

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

        public int PossibleTrips(GraphNode startCity, GraphNode endCity, int numberOfStops)
        {
            int possibleTrips = 0;

            Queue<GraphNode> searchStack = new Queue<GraphNode>();
            GraphNode current;
            searchStack.Enqueue(startCity);

            int[] lastLevels = new int[99];
            int level = 0;
            int index = 0;
            lastLevels[level] = 1;

            while (searchStack.Count != 0)
            {
                lastLevels[level]--;

                if (level <= numberOfStops) {
                    current = searchStack.Dequeue();
                    if (current.Id == endCity.Id && index > 0/* && level == numberOfStops*/)
                    {
                        possibleTrips++;
                    }

                    foreach (GraphNode node in current.Nodes)
                    {
                        searchStack.Enqueue(node);
                    }

                    lastLevels[level + 1] += current.Nodes.Count;
                    if (lastLevels[level] == 0) level++;
                } else
                {
                    break;
                }

                index++;
            }

            return possibleTrips;
        }
    }
}
