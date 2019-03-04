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
                .ReadLine().Returns(
                    "4",              // the number of directional commands to process
                    "10 20",    // the starting point coordinate 
                    "E 2",                      // from there and below follow navigation commands
                    "E 5", 
                    "W 3", 
                    "S 7",
                    "S 7",
                    "whatever invalid argument won't be processed as we retrieve only the first four directional parameters");

            var sut = new ConsoleParser(consoleMock);
            var inputCommand = sut.ParseAllSteps();

            Assert.IsTrue(inputCommand.StartingCoordinate.X == 10);
            Assert.IsTrue(inputCommand.StartingCoordinate.Y == 20);
            Assert.IsTrue(inputCommand.AtomicNavigationSteps.Count == 17);

            consoleMock.Received(6).ReadLine(); // we invoked the ReadLine only 6 = 2 + 4 times regardless of how many additional navigation parameters we supplied
        }
    }
}
