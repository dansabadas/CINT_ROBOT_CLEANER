using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaningLogic;

namespace RobotCleaningLogicUnitTests
{
    [TestClass]
    public class GridNavigatorUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invalid_HorizontalCoordinates_Fail()
        {
            GridNavigator sut = new GridNavigator();
            sut.InitializeCoordinates(new Point2D(-100001, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Invalid_VerticalCoordinates_Fail()
        {
            try
            {
                GridNavigator sut = new GridNavigator();
                sut.InitializeCoordinates(new Point2D(-100000, 100001));
            }
            catch(InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NavigateWest_Invalid_HorizontalCoordinates_Fail()
        {
            GridNavigator sut = new GridNavigator();
            sut.InitializeCoordinates(new Point2D(-100000, 2));
            sut.NavigateTo(NavigationDirections.West);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NavigateNorth_Invalid_VerticalCoordinates_Fail()
        {
            GridNavigator sut = new GridNavigator();
            sut.InitializeCoordinates(new Point2D(-1, 100000));
            sut.NavigateTo(NavigationDirections.North);
        }
    }
}
