using log4net;
using System;
using System.IO;
using System.Reflection;

namespace Bank.Infra.Logger
{
    public static class LoggerManager
    {
        private static readonly ILog _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static ILog Logger => _logger;

        public static void Initialize()
        {
            string log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            string log4NetConfigFilePath = @"C:\Users\ndduser\Desktop\FlashCode\ws-banco-tabajara-log\Bank.Infra\Logger\log4net.config";
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
