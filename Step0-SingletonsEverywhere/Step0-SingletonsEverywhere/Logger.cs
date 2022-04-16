using System;

namespace Step0_SingletonsEverywhere
{
    public class Logger
    {
        #region Singleton pattern
        private static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }
        private Logger() { }
        #endregion

        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
