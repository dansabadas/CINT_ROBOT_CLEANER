using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RobotCleaningLogic
{
    /// <summary>
    /// Represents the input information to be fed to the robot in order to perform the cleaning operations
    /// </summary>
    public class CleaningInputCommand
    {
        /// <summary>
        /// The coordinate where the robot starts the cleaning operation
        /// </summary>
        public Point2D StartingCoordinate { get; }

        /// <summary>
        /// Represents the atomic navigation steps (navigation between adjacent vertices)
        /// </summary>
        public ReadOnlyCollection<NavigationDirections> AtomicNavigationSteps { get; }

        public CleaningInputCommand(Point2D startingCoordinate, List<NavigationDirections> atomicNavigationSteps)
        {
            StartingCoordinate = startingCoordinate;
            AtomicNavigationSteps = atomicNavigationSteps.AsReadOnly();
        }
    }
}
