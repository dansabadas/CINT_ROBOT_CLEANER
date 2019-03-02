using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RobotCleaningLogic;

namespace RobotCleaningLogicUnitTests
{
    [TestClass]
    public class ConsoleParserUnitTests
    {
        [TestMethod]
        public void ParseAllSteps_Success()
        {
            IStandardIOReaderWriter consoleMock = Substitute.For<IStandardIOReaderWriter>();
            consoleMock
                .ReadLine().Returns("4", "10 20", "E 2", "E 5", "W 3", "S 7");

            var sut = new ConsoleParser(consoleMock);
            var inputCommand = sut.ParseAllSteps();

            Assert.IsTrue(inputCommand.StartingCoordinate.X == 10);
            Assert.IsTrue(inputCommand.StartingCoordinate.Y == 20);
            Assert.IsTrue(inputCommand.AtomicNavigationSteps.Count == 17);
        }
    }
}
