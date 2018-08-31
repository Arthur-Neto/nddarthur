using log4net;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace Arthur.MF7.Infra.Logger
{
    [ExcludeFromCodeCoverage]
    public static class LoggerManager
    {
        private static readonly ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static ILog Logger => _logger;

        public static void Initialize()
        {
            string log4NetConfigDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string log4NetConfigFilePath = Path.GetFullPath(Path.Combine(log4NetConfigDirectory, @"..\Arthur.MF7.Infra\Logger\log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }

        public static void Info(string message)
        {
            LoggerManager.Logger.Info(message);
        }

        public static void Error(string message)
        {
            LoggerManager.Logger.Error(message);
        }
    }
}
