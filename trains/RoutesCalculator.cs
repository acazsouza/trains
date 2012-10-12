using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace trains
{
    public class RoutesCalculator
    {
        public int CalculateDistance(params City[] cities)
        {
            int distance = 0;

            for (int i = 0; (i + 1) < cities.Length; i++)
            {
                KeyValuePair<City, int> nextCity = cities[i].Connections.Where(x => x.Key.Id == cities[i + 1].Id).FirstOrDefault();
                if (null != nextCity.Key)
                    distance += nextCity.Value;
                else
                    return -1;
            }

            return distance;
        }

        //Breadth first search
        public IList<Trip> PossibleTrips(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            City current;

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }

        //Breadth first search
        public IList<Trip> PossibleTripsWithFixedNumberOfStops(City startCity, City endCity, int numberOfStops)
        {
            IList<Trip> trips = new List<Trip>();
            IList<Trip> possibleTrips = new List<Trip>();

            Queue<City> searchQueue = new Queue<City>();
            searchQueue.Enqueue(startCity);

            City current;

            int[] lastLevels = new int[numberOfStops + 1];
            int level = 0;
            lastLevels[level] = 1;

            int tripPointer = 0;
            int index = 0;

            trips.Add(new Trip());

            while (searchQueue.Count != 0)
            {
                lastLevels[level]--;
                current = searchQueue.Dequeue();

                trips[tripPointer].Cities.Add(current);

                if (current.Id == endCity.Id && index > 0 && level == numberOfStops)
                {
                    possibleTrips.Add(trips[tripPointer]);
                }

                if ((level + 1) <= numberOfStops)
                {
                    foreach (KeyValuePair<City, int> node in current.Connections)
                    {
                        searchQueue.Enqueue(node.Key);
                    }

                    lastLevels[level + 1] += current.Connections.Count;

                    while (trips.Count < lastLevels[level + 1])
                    {
                        trips.Add(new Trip());
                    }
                }

                tripPointer++;

                if (lastLevels[level] == 0)
                {
                    level++;
                    tripPointer = 0;
                }

                index++;
            }

            return possibleTrips;
        }
    }
}
