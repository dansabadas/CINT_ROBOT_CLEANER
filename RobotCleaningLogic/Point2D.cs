using System;

namespace RobotCleaningLogic
{
    public struct Point2D
    {
        private const int CoordinatesHardBoundary = 100000;
        public int X { get; }

        public int Y { get; }

        public Point2D(int x, int y)
        {
            if (x < -CoordinatesHardBoundary ||
                x > CoordinatesHardBoundary ||
                y < -CoordinatesHardBoundary ||
                y > CoordinatesHardBoundary)
            {
                throw new InvalidOperationException($"Invalid coordinates: ({x},{y})");
            }

            X = x;
            Y = y;
        }
    }
}
