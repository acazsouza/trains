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
    }
}
