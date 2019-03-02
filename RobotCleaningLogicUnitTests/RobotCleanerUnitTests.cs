using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotCleaningLogic;

namespace RobotCleaningLogicUnitTests
{
    [TestClass]
    public class RobotCleanerUnitTests
    {
        [TestMethod]
        public async Task UseValidCoordinates_CalculatesUniqueSteps_Success()
        {
            var sut = new RobotCleaner(new GridNavigator());

            var originPoint = new Point2D(0, 0);
            var fullAtomicOperationsList = new List<NavigationDirections>()
            {
                NavigationDirections.East, NavigationDirections.East, NavigationDirections.North
            };

            var uniqueSteps = await sut.StartWithInput(new CleaningInputCommand(originPoint, fullAtomicOperationsList));

            Assert.IsTrue(uniqueSteps == 4);
        }

        [TestMethod]
        public async Task UseInvalidCoordinates_RobotNeverGoesOutside_Stops_RightAway()
        {
            var sut = new RobotCleaner(new GridNavigator());

            var originPoint = new Point2D(-100000, 22);
            var fullAtomicOperationsList = new List<NavigationDirections>
            {
                NavigationDirections.East,
                NavigationDirections.East,
                NavigationDirections.North,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.North
            };

            var uniqueSteps = await sut.StartWithInput(new CleaningInputCommand(originPoint, fullAtomicOperationsList));

            Assert.IsTrue(uniqueSteps == 6);
            Assert.IsTrue(uniqueSteps <= fullAtomicOperationsList.Count);
        }

        [TestMethod]
        public async Task Robot_RunsInCircles_FewUniquePoints()
        {
            var sut = new RobotCleaner(new GridNavigator());

            var originPoint = new Point2D(10, 22);
            var fullAtomicOperationsList = new List<NavigationDirections>
            {
                NavigationDirections.East,
                NavigationDirections.East,
                NavigationDirections.North,
                NavigationDirections.North,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.South,
                NavigationDirections.South,
                NavigationDirections.East,
                NavigationDirections.East,
                NavigationDirections.North,
                NavigationDirections.North,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.South,
                NavigationDirections.South,
                NavigationDirections.East,
                NavigationDirections.East,
                NavigationDirections.North,
                NavigationDirections.North,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.South,
                NavigationDirections.South,
                NavigationDirections.East,
                NavigationDirections.East,
                NavigationDirections.North,
                NavigationDirections.North,
                NavigationDirections.West,
                NavigationDirections.West,
                NavigationDirections.South,
                NavigationDirections.South
            };

            var uniqueSteps = await sut.StartWithInput(new CleaningInputCommand(originPoint, fullAtomicOperationsList));

            Assert.IsTrue(uniqueSteps == 8);
        }
    }
}
