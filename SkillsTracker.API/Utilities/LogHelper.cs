using System;
using System.Linq;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace SkillsTracker.API.Utilities
{
    public sealed class LogHelper
    {
        static ILog _log = null;
        static LogHelper _logger = null;
        private LogHelper()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        public static LogHelper Initialize()
        {
            if (_logger == null)
            {
                _logger = new LogHelper();
            }
            return _logger;
        }
        public static ILog Logger
        {
            get
            {
                if (_logger == null) Initialize();
                return _log;
            }
        }
        public static ILog GetFileLogger(System.Type type)
        {
            return LogManager.GetLogger(type);
        }

        public static void ConfigureLog4Net(string suffixFileName)
        {
            log4net.ThreadContext.Properties["GroupName"] = suffixFileName;
            string filePattern = ConfigurationManager.AppSettings["log4net.filepattern"];
            string log4NetFile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, filePattern, SearchOption.AllDirectories).FirstOrDefault();
            if (string.IsNullOrEmpty(log4NetFile)) return;
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetFile));
        }

        public static string GetLoggingFilePath()
        {
            var rootAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<FileAppender>().FirstOrDefault();
            return rootAppender != null ? new FileInfo(rootAppender.File).DirectoryName : string.Empty;
        }

        /// <summary>
        /// Alternative to log4net especially for the Library projects or Services where one cannot find the logging folder due to
        /// the such projects being referenced in the main projects. Use this only for the debugging purposes.
        /// </summary>
        /// <param name="filePath">Absolute Path: For e.g. C:\logs\Custom</param>
        /// <param name="message">Message to be logged</param>
        public static void WriteCustomLog(string filePath, string message)
        {
            if (!filePath.EndsWith(@"\"))
            {
                filePath += @"\";
            }

            string fileName = String.Format("{3}log-{0:D2}{1:D2}{2}.txt", DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, Process.GetCurrentProcess().ProcessName);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (StreamWriter writer = new StreamWriter(File.Open(filePath + fileName, FileMode.Create, FileAccess.Write, FileShare.Write)))
            {
                writer.WriteLine(String.Format("{0} -Time :{1}", message, Convert.ToString(DateTime.Now)));
                writer.Flush();
            }
        }

        public static void WriteCustomExceptionLog(string filePath, Exception ex)
        {
            WriteCustomLog(filePath, String.Format("{0} ----------", DateTime.Now));
            WriteCustomLog(filePath, String.Format("\t{0}", ex.ToString()));
            WriteCustomLog(filePath, String.Format("\tSTACK TRACE : {0}", ex.StackTrace));
        }
    }
}