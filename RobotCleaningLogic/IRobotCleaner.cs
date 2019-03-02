namespace RobotCleaningLogic
{
    /// <summary>
    /// This robot cleaner is exposed as interface
    /// in order to allow for Liskov substitution principle
    /// </summary>
    public interface IRobotCleaner
    {
        uint StartWithInput(CleaningInputCommand cleaningInputCommand);
    }
}
