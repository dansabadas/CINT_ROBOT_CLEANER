namespace RobotCleaningLogic
{
    /// <summary>
    /// Keeps track of Geographical coordinates (latitude-longitude) on X and Y axis
    /// </summary>
    public struct Point2D
    {
        public int X { get; }

        public int Y { get; }

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
