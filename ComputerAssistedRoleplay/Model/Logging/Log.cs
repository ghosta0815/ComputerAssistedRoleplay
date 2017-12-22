using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model.Logging
{
    /// <summary>
    /// Delegate for the LogEvents
    /// </summary>
    /// <typeparam name="ILog">Interface of the Log</typeparam>
    /// <param name="sender">Source of the event</param>
    /// <param name="e">Contains the Event Data</param>
    public delegate void LogHandler<ILog>(ILog sender, LogEventArgs e);

    /// <summary>
    /// The Event Data of the Log Events
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// The string that was just added to the Log entry;
        /// </summary>
        public string NewLogEntry;
        /// <summary>
        /// The full Text of Log;
        /// </summary>
        public string LogText;

        /// <summary>
        /// Creates a new Instance of LogEventArgs
        /// </summary>
        /// <param name="logText">The full Text of the Log</param>
        /// <param name="newLog">The new Log entry that was added</param>
        public LogEventArgs(string logText, string newLog)
        {
            LogText = logText;
            NewLogEntry = newLog;
        }
    }

    /// <summary>
    /// The Interface every observer must Implement
    /// </summary>
    public interface ILogObserver
    {
        void textChanged(ILog log, LogEventArgs e);
    }

    /// <summary>
    /// Log interface to allow subscription and unsubscription
    /// </summary>
    public interface ILog
    {
        void Subscribe(ILogObserver ilo);
        void UnSubscribe(ILogObserver ilo);
    }

    /// <summary>
    /// Stores a Log and notifies observers about changes via Events
    /// </summary>
    public class Log : ILog
    {
        #region Variables
        /// <summary>
        /// The Log text
        /// </summary>
        public string Text { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates an Instance of the Log
        /// </summary>
        public Log()
        {
            Text = "";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Appends a Textstring to the Log and notifies observers about the added Values
        /// </summary>
        /// <param name="textToAppend">The Text to append to the Log</param>
        public void Append(string textToAppend)
        {
            Text = Text + textToAppend + "\r\n";
            if (textChanged != null)
            {
                textChanged.Invoke(this, new LogEventArgs(Text, textToAppend));
            }
        }

        /// <summary>
        /// Clears the Content of the Log;
        /// </summary>
        public void Clear()
        {
            Text = "";
        } 
        #endregion

        #region Event stuff
        /// <summary>
        /// Occurs when the Text of the log changes.
        /// </summary>
        public event LogHandler<Log> textChanged;

        /// <summary>
        /// Subscribe if you want to get notified about changes to the Log
        /// </summary>
        /// <param name="ilo"></param>
        public void Subscribe(ILogObserver ilo)
        {
            textChanged += new LogHandler<Log>(ilo.textChanged);
        }

        /// <summary>
        /// UnSubscribe if you do not want to get notified about changes to the Log
        /// </summary>
        /// <param name="ilo"></param>
        public void UnSubscribe(ILogObserver ilo)
        {
            textChanged -= new LogHandler<Log>(ilo.textChanged);
        }
        #endregion
    }
}
