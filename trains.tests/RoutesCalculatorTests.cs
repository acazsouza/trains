using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace trains.tests
{
    [TestClass]
    public class RoutesCalculatorTests
    {
        [TestMethod]
        public void InsertRoute_should_save_the_route()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            routesCalculator.InsertRoute(new Route('A', 'B', 5));

            Assert.IsTrue(1 == routesCalculator.Routes.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertRoute_with_a_duplicate_route_should_throw_a_exception()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            routesCalculator.InsertRoute(new Route('A', 'B', 5));

            try
            {
                routesCalculator.InsertRoute(new Route('A', 'B', 10));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("The route between this points is already exist.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertRoute_with_a_route_where_the_start_and_final_point_are_the_same_should_throw_a_exception()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            try
            {
                routesCalculator.InsertRoute(new Route('B', 'B', 5));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("For a given route, the starting and final point could not be the same.", ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void CalculateDistance_with_a_valid_route_should_return_the_distance()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            routesCalculator.InsertRoute(new Route('A', 'B', 5));
            routesCalculator.InsertRoute(new Route('B', 'C', 4));
            routesCalculator.InsertRoute(new Route('C', 'D', 8));
            routesCalculator.InsertRoute(new Route('D', 'C', 8));
            routesCalculator.InsertRoute(new Route('D', 'E', 6));
            routesCalculator.InsertRoute(new Route('A', 'D', 5));
            routesCalculator.InsertRoute(new Route('C', 'E', 2));
            routesCalculator.InsertRoute(new Route('E', 'B', 3));
            routesCalculator.InsertRoute(new Route('A', 'E', 7));

            Assert.IsTrue(9 == routesCalculator.CalculateDistance('A', 'B', 'C'));
            Assert.IsTrue(5 == routesCalculator.CalculateDistance('A', 'D'));
            Assert.IsTrue(13 == routesCalculator.CalculateDistance('A', 'D', 'C'));
            Assert.IsTrue(22 == routesCalculator.CalculateDistance('A', 'E', 'B', 'C', 'D'));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateDistance_with_a_invalid_route_should_throw_a_exception()
        {
            RoutesCalculator routesCalculator = new RoutesCalculator();

            routesCalculator.InsertRoute(new Route('A', 'B', 5));
            routesCalculator.InsertRoute(new Route('B', 'C', 4));
            routesCalculator.InsertRoute(new Route('C', 'D', 8));
            routesCalculator.InsertRoute(new Route('D', 'C', 8));
            routesCalculator.InsertRoute(new Route('D', 'E', 6));
            routesCalculator.InsertRoute(new Route('A', 'D', 5));
            routesCalculator.InsertRoute(new Route('C', 'E', 2));
            routesCalculator.InsertRoute(new Route('E', 'B', 3));
            routesCalculator.InsertRoute(new Route('A', 'E', 7));

            try
            {
                Assert.IsTrue(9 == routesCalculator.CalculateDistance('A', 'E', 'D'));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("NO SUCH ROUTE", ex.Message);
                throw;
            }
        }
    }
}
