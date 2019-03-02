namespace RobotCleaningLogic
{
    public class Orchestrator
    {
        private readonly ConsoleParser _consoleParser;
        private readonly IRobotCleaner _robotCleaner;

        public Orchestrator(ConsoleParser consoleParser, IRobotCleaner robotCleaner)
        {
            _consoleParser = consoleParser;
            _robotCleaner = robotCleaner;
        }

        public Orchestrator() : this(new ConsoleParser(), new RobotCleaner())
        {
        }
    }
}
