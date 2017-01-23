using NLog;
using System;

namespace UniversitySystem.Core
{
    public class LogService
    {
        private readonly Logger _logger;
        public LogService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void WriteError(string message)
        {            
           _logger.Log(LogLevel.Error, message);
        }
        public void WriteInfo(string message)
        {
            _logger.Log(LogLevel.Info, message);
        }
    }
}