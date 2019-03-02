using System.Threading.Tasks;

namespace RobotCleaningLogic
{
    /// <summary>
    /// This robot cleaner is exposed as interface
    /// in order to allow for Liskov substitution principle
    /// </summary>
    public interface IRobotCleaner
    {
        /// <summary>
        /// Cleans an office based on initial input commands
        /// </summary>
        /// <param name="cleaningInputCommand"></param>
        /// <returns>Returns the number of unique places in the office that were cleaned</returns>
        Task<uint> StartWithInput(CleaningInputCommand cleaningInputCommand);
    }
}
