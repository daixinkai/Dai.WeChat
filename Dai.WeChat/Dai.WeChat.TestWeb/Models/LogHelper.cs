using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dai.WeChat.TestWeb.Models
{
    public class LogHelper
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();
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