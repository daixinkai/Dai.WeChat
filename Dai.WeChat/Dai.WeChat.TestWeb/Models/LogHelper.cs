using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Dai.WeChat.TestWeb.Models
{
    public class LogHelper
    {

        static LogHelper()
        {
            IsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEnabledLog"]);
        }

        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        static bool IsEnabled { get; set; }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }
    }
}