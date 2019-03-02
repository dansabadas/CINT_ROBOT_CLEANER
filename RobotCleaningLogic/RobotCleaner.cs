namespace RobotCleaningLogic
{
    /// <summary>
    /// If the Robot encounters any error, will stop right away
    /// </summary>
    public class RobotCleaner : IRobotCleaner
    {
        public uint StartWithInput(CleaningInputCommand cleaningInputCommand)
        {
            return 1;
        }
    }
}
