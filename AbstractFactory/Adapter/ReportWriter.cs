using System;

namespace AbstractFactory.Adapter
{
    public class ReportWriter : IConsoleWrite
    {
        private readonly string _report;

        public ReportWriter(string report)
        {
            _report = report;
        }

        public void Write()
        {
            Console.WriteLine(_report);
        }
    }
}
