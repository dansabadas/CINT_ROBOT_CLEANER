using System.Threading.Tasks;
using RobotCleaningLogic;

namespace RobotExecuter
{
    class Program
    {
        static void Main(string[] args)
        {
            var orchestrator = Orchestrator.Instance;
            orchestrator.Clean().Wait();
        }
    }
}
