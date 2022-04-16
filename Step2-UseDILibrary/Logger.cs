using System;

namespace Step0_SingletonsEverywhere
{
    public class Logger : ILogger
    {
        public Logger() { }

        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
