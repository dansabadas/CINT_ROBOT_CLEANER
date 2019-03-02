using System;
using System.Collections.Generic;

namespace RobotCleaningLogic
{
    /// <summary>
    /// Console Parser is dedicated to reading information from the standard console input (keyboard)
    /// and transforming it into formal input to be fed to the robot
    /// </summary>
    public class ConsoleParser
    {
        private const char East = 'E';
        private const char West = 'W';
        private const char South = 'S';
        private const char North = 'N';

        private readonly IStandardIOReaderWriter _standardIoReaderWriter;

        public ConsoleParser(IStandardIOReaderWriter standardIoReaderWriter)
        {
            _standardIoReaderWriter = standardIoReaderWriter;
        }

        public ConsoleParser() : this(new ConsoleReaderWriter())
        {
        }

        public CleaningInputCommand ParseAllSteps()
        {
            int numberOfCommands = ParseNumberOfCommands();

            Point2D startingCoordinate = ParseStartingCoordinates();

            var navigationDirections = ParseNavigationDirections(numberOfCommands);

            return new CleaningInputCommand(startingCoordinate, navigationDirections);
        }

        public void DisplayResult(uint places)
        {
            _standardIoReaderWriter.WriteLine($"=> Cleaned: {places}");
        }

        /// <summary>
        /// It represents the first step of the Console input where we set the number of commands to be accepted
        /// </summary>
        /// <returns></returns>
        private int ParseNumberOfCommands()
        {
            int numberOfCommands = int.Parse(_standardIoReaderWriter.ReadLine());
            return numberOfCommands;
        }

        /// <summary>
        /// It represents the second step of the Console input where we set the starting coordinates of the robot
        /// </summary>
        /// <returns></returns>
        private Point2D ParseStartingCoordinates()
        {
            string[] commandTokens = _standardIoReaderWriter.ReadLine().Split();
            return new Point2D(int.Parse(commandTokens[0]), int.Parse(commandTokens[1]));
        }
        /// <summary>
        /// It parses the third step, the navigation directions
        /// If stops after the given the number of commands to be taken into account (provided at step 1)
        /// </summary>
        /// <param name="numberOfCommands"></param>
        private List<NavigationDirections> ParseNavigationDirections(int numberOfCommands)
        {
            var navigationDirections = new List<NavigationDirections>();
            while (numberOfCommands > 0)
            {
                string[] commandTokens = _standardIoReaderWriter.ReadLine().Split();
                int numberOfSteps = int.Parse(commandTokens[1]);
                char direction = char.Parse(commandTokens[0]);
                var navigationDirection = ConvertToNavigationDirection(direction);
                
                while (numberOfSteps > 0)
                {
                    navigationDirections.Add(navigationDirection);
                    numberOfSteps -= 1;
                }

                numberOfCommands -= 1;
            }

            return navigationDirections;
        }

        private static NavigationDirections ConvertToNavigationDirection(char directionCharacter)
        {
            switch (directionCharacter)
            {
                case East:
                    return NavigationDirections.East;
                case West:
                    return NavigationDirections.West;
                case South:
                    return NavigationDirections.South;
                case North:
                    return NavigationDirections.North;
                default:
                    throw new InvalidOperationException($"invalid direction input: {directionCharacter}");
            }
        }
    }
}
