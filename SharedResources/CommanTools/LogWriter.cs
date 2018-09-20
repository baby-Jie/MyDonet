/********************************************************************************
** Author: 
** Date:   2011-05-26
** LogWriter:
**          Logger format info to file
*********************************************************************************/

using System;
using System.IO;
using log4net;

namespace WpfTest.CommanTools
{
    /// <summary>
    /// LogWrite class for Action logger 
    /// </summary>
    public class LogWriter
    {
        //Init ILog object
        private static readonly ILog action = LogManager.GetLogger("ActionLog");

        //define private static a LogWriter instance
        private static LogWriter instance = null;

        /// <summary>
        /// Read config file of log
        /// </summary>
        public LogWriter()
        {
        }

        /// <summary>
        /// Load Confog File and Init
        /// </summary>
        /// <param name="logConfigFileName">Config File Name of Log</param>
        public void LoadLogConfig(string logConfigFileName)
        {
            FileInfo fInfo = new FileInfo(logConfigFileName);
            if (!fInfo.Exists)
            {
                throw new ApplicationException("Failed to load log configuration!");
            }
            else
            {
                try
                {
                    log4net.Config.XmlConfigurator.Configure(fInfo);
                }
                catch
                {
                    throw new ApplicationException("Failed to parse log configuration!");
                }
            }
        }

        /// <summary>
        /// Get LogWriter only one object
        /// </summary>
        public static LogWriter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogWriter();
                }
                return instance;
            }
        }

        /// <summary>
        /// Get a defined logger
        /// </summary>
        public ILog ActionLogger
        {
            get { return action; }
        }
    }
}
