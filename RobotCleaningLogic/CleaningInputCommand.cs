using System.Collections.Generic;

namespace RobotCleaningLogic
{
    /// <summary>
    /// Represents the input information to be fed to the robot in order to perform the cleaning operations
    /// </summary>
    public class CleaningInputCommand
    {
        public Point2D StartingCoordinate { get; private set; }
        public List<NavigationDirections> Atomic { get; private set; }
    }
}
