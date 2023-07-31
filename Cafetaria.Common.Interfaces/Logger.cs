using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cafetaria.Common.Helpers
{
  public static class Logger
    {
        [ThreadStatic]
        public static StreamWriter _streamw;
        public static string LogPath { get; } = Path.GetTempPath() + @"\SchoolCafe\Logs\";
        public static string TestSuiteLogFileName => TestContext.CurrentContext.Test.ClassName + "_" + string.Format("{0:ddMMyyyy}", DateTime.Now);
        public static string TestLevelLogFileName => TestContext.CurrentContext.Test.MethodName + "_" + string.Format("{0:ddMMyyyy}", DateTime.Now);

        //Create fiile to save log data
        public static void CreateLogFile()
        {
            string dir = LogPath;

            if (Directory.Exists(dir))
            {
                if (TestContext.CurrentContext.Test.MethodName == null)
                {
                    _streamw = File.CreateText(dir + Logger.TestSuiteLogFileName + ".log");
                    _streamw.WriteLine("*******************Test Suite level log file********************");
                }
                else
                {
                    _streamw = File.CreateText(dir + Logger.TestLevelLogFileName + ".log");
                    _streamw.WriteLine("*******************Test Case level log file********************");
                }
            }
            else
            {
                Directory.CreateDirectory(dir);
                if (TestContext.CurrentContext.Test.MethodName == null)
                {
                    _streamw = File.CreateText(dir + TestSuiteLogFileName + ".log");
                    _streamw.WriteLine("*******************Test Suite level log file********************");
                }
                else
                {
                    _streamw = File.CreateText(dir + TestLevelLogFileName + ".log");
                    _streamw.WriteLine("*******************Test Case level log file********************");
                }
            }
        }

        //Method to write text in the log file
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Write(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("       {0}", logMessage);
            _streamw.Flush();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogInfo(string logmsg, MediaEntityModelProvider provider = null)
        {
            var status = Status.Info;
            Logger.Write(status.ToString() + ": " + logmsg);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogPass(string logmsg, MediaEntityModelProvider provider = null)
        {
            var status = Status.Pass;
            Logger.Write(status.ToString() + ": " + logmsg);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogFail(string logmsg, MediaEntityModelProvider provider = null)
        {
            var status = Status.Fail;
            Logger.Write(status.ToString() + ": " + logmsg);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogWarning(string logmsg, MediaEntityModelProvider provider = null)
        {
            var status = Status.Warning;
            Logger.Write(status.ToString() + ": " + logmsg);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LogSkip(string logmsg, MediaEntityModelProvider provider = null)
        {
            var status = Status.Skip;
            Logger.Write(status.ToString() + ": " + logmsg);
        }

        public static void LogFail(object p)
        {
            throw new NotImplementedException();
        }
    }
}
    

