using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RobotCleaningLogic
{
    /// <summary>
    /// If the Robot encounters any error, will stop right away
    /// </summary>
    public class RobotCleaner : IRobotCleaner
    {
        private readonly List<Point2D> _alreadyCleanedPoints;
        private readonly GridNavigator _gridNavigator;

        public RobotCleaner() : this(new GridNavigator())
        {
        }

        public RobotCleaner(GridNavigator gridNavigator)
        {
            _gridNavigator = gridNavigator;
            _alreadyCleanedPoints = new List<Point2D>();
        }

        public async Task<uint> StartWithInput(CleaningInputCommand cleaningInputCommand)
        {
            _alreadyCleanedPoints.Clear();
            _gridNavigator.InitializeCoordinates(cleaningInputCommand.StartingCoordinate);
            _alreadyCleanedPoints.Add(cleaningInputCommand.StartingCoordinate);
            return await Task.Run(() =>
            {
                foreach (var direction in cleaningInputCommand.AtomicNavigationSteps)
                {
                    try
                    {
                        var newPoint = _gridNavigator.NavigateTo(direction);
                        bool pointAlreadyCleaned = _alreadyCleanedPoints
                            .Exists(point => point.X == newPoint.X && point.Y == newPoint.Y);

                        if (pointAlreadyCleaned == false)
                        {
                            _alreadyCleanedPoints.Add(newPoint);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        return (uint) _alreadyCleanedPoints.Count;
                    }
                }

                return (uint)_alreadyCleanedPoints.Count;
            });
        }
    }
}
