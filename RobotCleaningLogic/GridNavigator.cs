using System;
using System.Collections.Generic;

namespace RobotCleaningLogic
{
    /// <summary>
    /// This class handles the Navigation logic enforcing the business rules:
    /// 1. Points must be between the agreed boundaries
    /// 2. Tracked points must be unique
    /// </summary>
    public class GridNavigator
    {
        private const int CoordinatesHardBoundary = 100000;

        /// <summary>
        /// Tracks the current point of the Robot
        /// </summary>
        private Point2D _currentPoint;

        /// <summary>
        /// Tracks the already walked path (poly-line) of the robot 
        /// </summary>
        private readonly List<Point2D> _navigatedPath;

        public GridNavigator()
        {
            _navigatedPath = new List<Point2D>();
        }

        public void InitializeCoordinates(Point2D point)
        {
            ValidateCoordinates(point);
            _currentPoint = point;
        }

        public Point2D NavigateTo(NavigationDirections navigationDirection)
        {
            int x = _currentPoint.X, 
                y = _currentPoint.Y;

            switch (navigationDirection)
            {
                case NavigationDirections.East:
                    x += 1;
                    break;
                case NavigationDirections.West:
                    x -= 1;
                    break;
                case NavigationDirections.North:
                    y += 1;
                    break;
                case NavigationDirections.South:
                    y -= 1;
                    break;
            }

            var newPoint = new Point2D(x, y);
            ValidateCoordinates(newPoint);
            _currentPoint = newPoint;

            return newPoint;
        }

        private void ValidateCoordinates(Point2D point)
        {
            if (point.X < -CoordinatesHardBoundary ||
                point.X > CoordinatesHardBoundary ||
                point.Y < -CoordinatesHardBoundary ||
                point.Y > CoordinatesHardBoundary)
            {
                throw new InvalidOperationException($"Invalid coordinates: ({point.X},{point.Y})");
            }
        }
    }
}
