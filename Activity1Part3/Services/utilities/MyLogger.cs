using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace Activity1Part3.Services.utilities
{
    public class MyLogger : ILogger
    {

        //singleton pattern example. One instance only!
        private static MyLogger instance; //singleton design pattern
        private static Logger logger;

        //single design patter constructor
        private MyLogger()
        {

        }


        //creates isntance if non exists
        public static MyLogger GetInstance()
        {
            if (instance == null)
                instance = new MyLogger();
            return instance;

        }

        public Logger GetLogger(string theLogger)
        {
            if (MyLogger.logger == null)
                MyLogger.logger = LogManager.GetLogger(theLogger);
            return MyLogger.logger;
        }









        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRule").Debug(message);
            else
                GetLogger("myAppLoggerRule").Debug(message,arg);
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRule").Error(message);
            else
                GetLogger("myAppLoggerRule").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRule").Info(message);
            else
                GetLogger("myAppLoggerRule").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLoggerRule").Warn(message);
            else
                GetLogger("myAppLoggerRule").Warn(message, arg);
        }
    }
}