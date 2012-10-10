using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace trains.tests
{
    [TestClass]
    public class RoutesCalculatorTests
    {
        /* Fazer os GraphNode serem as próprias Cidades.
         * Representar uma Matrix com números dentro dos GraphNode p/ calcular distâncias e outras coisas.
         */

        [TestMethod]
        public void InsertRoute_should_save_the_route()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');

            routesCalculator.InsertRoute(new Route(A, B, 5));

            Assert.IsTrue(1 == routesCalculator.Routes.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertRoute_with_a_duplicate_cities_route_should_throw_a_exception()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');

            routesCalculator.InsertRoute(new Route(A, B, 5));

            try
            {
                A = new City('A');
                B = new City('B');

                routesCalculator.InsertRoute(new Route(A, B, 10));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The route between this cities is already exist.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertRoute_with_a_route_where_the_start_city_and_end_city_are_the_same_should_throw_a_exception()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City B1 = new City('B');
            City B2 = new City('B');

            try
            {
                routesCalculator.InsertRoute(new Route(B1, B2, 5));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("For a given route, the starting and end city could not be the same.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void CalculateDistance_with_a_valid_route_should_return_the_distance()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            routesCalculator.InsertRoute(new Route(A, B, 5));
            routesCalculator.InsertRoute(new Route(B, C, 4));
            routesCalculator.InsertRoute(new Route(C, D, 8));
            routesCalculator.InsertRoute(new Route(D, C, 8));
            routesCalculator.InsertRoute(new Route(D, E, 6));
            routesCalculator.InsertRoute(new Route(A, D, 5));
            routesCalculator.InsertRoute(new Route(C, E, 2));
            routesCalculator.InsertRoute(new Route(E, B, 3));
            routesCalculator.InsertRoute(new Route(A, E, 7));

            Assert.IsTrue(9 == routesCalculator.CalculateDistance(A, B, C));
            Assert.IsTrue(5 == routesCalculator.CalculateDistance(A, D));
            Assert.IsTrue(13 == routesCalculator.CalculateDistance(A, D, C));
            Assert.IsTrue(22 == routesCalculator.CalculateDistance(A, E, B, C, D));
        }

        [TestMethod]
        public void CalculateDistance_with_a_invalid_route_should_return_negative()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            City A = new City('A');
            City B = new City('B');
            City C = new City('C');
            City D = new City('D');
            City E = new City('E');

            routesCalculator.InsertRoute(new Route(A, B, 5));
            routesCalculator.InsertRoute(new Route(B, C, 4));
            routesCalculator.InsertRoute(new Route(C, D, 8));
            routesCalculator.InsertRoute(new Route(D, C, 8));
            routesCalculator.InsertRoute(new Route(D, E, 6));
            routesCalculator.InsertRoute(new Route(A, D, 5));
            routesCalculator.InsertRoute(new Route(C, E, 2));
            routesCalculator.InsertRoute(new Route(E, B, 3));
            routesCalculator.InsertRoute(new Route(A, E, 7));

            Assert.IsTrue(-1 == routesCalculator.CalculateDistance(A, E, D));
        }

        [TestMethod]
        public void PossibleTrips_should_return_the_number_of_possible_trips_between_two_cities()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            GraphNode A = new GraphNode('A');
            GraphNode B = new GraphNode('B');
            GraphNode C = new GraphNode('C');
            GraphNode D = new GraphNode('D');
            GraphNode E = new GraphNode('E');

            A.Nodes.Add(B);
            A.Nodes.Add(D);
            A.Nodes.Add(E);

            B.Nodes.Add(C);

            C.Nodes.Add(D);
            C.Nodes.Add(E);

            D.Nodes.Add(C);
            D.Nodes.Add(E);

            E.Nodes.Add(B);

            Assert.IsTrue(2 == routesCalculator.PossibleTrips(C, C, 3));
            Assert.IsTrue(3 == routesCalculator.PossibleTrips(A, C, 3));
            Assert.IsTrue(6 == routesCalculator.PossibleTrips(A, C, 4));
            Assert.IsTrue(3 == routesCalculator.PossibleTrips(D, C, 3));
            Assert.IsTrue(1 == routesCalculator.PossibleTrips(E, B, 1));
            Assert.IsTrue(2 == routesCalculator.PossibleTrips(E, C, 4));
        }

        [TestMethod]
        public void PossibleTripsWithFixedStops_should_return_in_a_determined_number_of_stops_the_number_of_possible_trips_between_two_cities()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            GraphNode A = new GraphNode('A');
            GraphNode B = new GraphNode('B');
            GraphNode C = new GraphNode('C');
            GraphNode D = new GraphNode('D');
            GraphNode E = new GraphNode('E');

            A.Nodes.Add(B);
            A.Nodes.Add(D);
            A.Nodes.Add(E);

            B.Nodes.Add(C);

            C.Nodes.Add(D);
            C.Nodes.Add(E);

            D.Nodes.Add(C);
            D.Nodes.Add(E);

            E.Nodes.Add(B);

            Assert.IsTrue(3 == routesCalculator.PossibleTripsWithFixedStops(A, C, 4));
        }
    }
}
