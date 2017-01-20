using NLog;
using System;

namespace UniversitySystem.Core
{
    public class LogService
    {
        private Logger _logger;
        public LogService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void WriteError(String message)
        {            
           _logger.Log(LogLevel.Error, message);
        }
        public void WriteInfo(String message)
        {
            _logger.Log(LogLevel.Info, message);
        }
    }
}