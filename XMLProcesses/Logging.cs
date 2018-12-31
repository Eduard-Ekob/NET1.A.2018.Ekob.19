using System.Runtime.CompilerServices;
using NLog;
namespace XMLProcesses
{
    /// <summary>
    /// This for logging errors by NLog
    /// </summary>
    public class Logging : ILogging
    {
        private Logger log = LogManager.GetCurrentClassLogger();
        public void Log(string message)
        {
            log.Debug(message); 
        }
    }
}