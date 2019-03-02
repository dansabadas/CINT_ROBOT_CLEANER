﻿using System.ComponentModel;

namespace RobotCleaningLogic
{
    public class Orchestrator
    {
        private readonly ConsoleParser _consoleParser;
        private readonly IRobotCleaner _robotCleaner;

        private Orchestrator(ConsoleParser consoleParser, IRobotCleaner robotCleaner)
        {
            _consoleParser = consoleParser;
            _robotCleaner = robotCleaner;
        }

        private Orchestrator() : this(new ConsoleParser(), new RobotCleaner())
        {
        }

        public static readonly Orchestrator Instance = new Orchestrator();

        public void Clean()
        {
            var cleaningCommand = _consoleParser.ParseAllSteps();
            var uniqueVerticesCleaned = _robotCleaner.StartWithInput(cleaningCommand);
            _consoleParser.DisplayResult(uniqueVerticesCleaned);
        }
    }
}
