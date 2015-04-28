using System.Diagnostics;
using Microsoft.Practices.Prism.Logging;

namespace PrismDataTemplateExample.Models
{
    internal static class LoggerFactory
    {
        #region Static members

        public static ILoggerFacade CreateLogger()
        {
            return _logger ?? (_logger = new LoggerFacade());
        }

        private static ILoggerFacade _logger;

        #endregion

        #region Nested type: LoggerFacade

        private class LoggerFacade : ILoggerFacade
        {
            #region ILoggerFacade Members

            public void Log(string message, Category category, Priority priority)
            {
                Debug.WriteLine("{0}({1}):{2}", category, priority, message);
            }

            #endregion
        }

        #endregion
    }
}