using System;

namespace RobotCleaningLogic
{
    /// <summary>
    /// Console Parser is dedicated to reading information from the standard console input (keyboard)
    /// and transforming it into formal input to be fed to the robot
    /// </summary>
    public class ConsoleParser
    {
        public void ParseAllSteps()
        {
            int numberOfCommands = ParseNumberOfCommands();

            Point2D startingCoordinate = ParseStartingCoordinates();
        }

        /// <summary>
        /// It represents the first step of the Console input where we set the number of commands to be accepted
        /// </summary>
        /// <returns></returns>
        private int ParseNumberOfCommands()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            return numberOfCommands;
        }

        /// <summary>
        /// It represents the second step of the Console input where we set the starting coordinates of the robot
        /// </summary>
        /// <returns></returns>
        private Point2D ParseStartingCoordinates()
        {
            string[] tokens = Console.ReadLine().Split();
            return new Point2D(int.Parse(tokens[0]), int.Parse(tokens[0]));
        }

        private void ParseNavigationDirections(int numberOfCommands)
        {
            while (numberOfCommands > 0)
            {

                numberOfCommands -= 1;
            }
        }
    }
}
