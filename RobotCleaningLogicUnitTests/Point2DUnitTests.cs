using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaningLogic;

namespace RobotCleaningLogicUnitTests
{
    [TestClass]
    public class Point2DUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invalid_HorizontalCoordinates_Fail()
        {
            Point2D sut = new Point2D(-100001, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invalid_VerticalCoordinates_Fail()
        {
            try
            {
                Point2D sut = new Point2D(-100000, 100001);
            }
            catch(InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
