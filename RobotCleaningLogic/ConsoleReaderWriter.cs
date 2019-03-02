using System;

namespace RobotCleaningLogic
{
    public class ConsoleReaderWriter : IStandardIOReaderWriter
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
