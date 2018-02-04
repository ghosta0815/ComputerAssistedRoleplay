using System;

namespace ComputerAssistedRoleplay.Model.Misc
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
        /// Returns true when the log was cleared with this event;
        /// </summary>
        public bool LogCleared;
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
        public LogEventArgs(string logText, string newLog, bool logCleared)
        {
            LogCleared = logCleared;
            LogText = logText;
            NewLogEntry = newLog;
        }
    }

    /// <summary>
    /// The Interface every observer must Implement if they want to get notified about Log changes
    /// </summary>
    public interface ILogObserver
    {
        void logTextChangedEvent(ILog sender, LogEventArgs e);
    }

    /// <summary>
    /// Log interface to allow subscription and unsubscription
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Subscribe to the Log Event
        /// </summary>
        /// <param name="ilo"></param>
        void Subscribe(ILogObserver ilo);

        /// <summary>
        /// Unsubscribe from the Logevent
        /// </summary>
        /// <param name="ilo"></param>
        void UnSubscribe(ILogObserver ilo);
    }

    /// <summary>
    /// Stores a Log and notifies observers about changes via Events
    /// </summary>
    public sealed class CombatLog : ILog
    {
        /// <summary>
        /// Singleton instance of Combatlog
        /// </summary>
        private static readonly CombatLog Log = new CombatLog();

        /// <summary>
        /// Provides access to the singleton Instance
        /// </summary>
        public static CombatLog getInstance
        {
            get
            {
                return Log;
            }
        }

        /// <summary>
        /// The Log text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Creates an Instance of the Log
        /// </summary>
        private CombatLog()
        {
            Text = "";
        }

        /// <summary>
        /// Appends a Textstring to the Log and notifies observers about the added Values
        /// </summary>
        /// <param name="textToAppend">The Text to append to the Log</param>
        public void Append(string valueToAppend, params Object[] args)
        {
            string stringToAppend = String.Format(valueToAppend, args);
            Text = Text + stringToAppend + "\r\n";
            textHandler.Invoke(this, new LogEventArgs(Text, stringToAppend, false));
        }

        /// <summary>
        /// Clears the Content of the Log;
        /// </summary>
        public void Clear()
        {
            Text = "";
            if (textHandler != null)
            {
                textHandler.Invoke(this, new LogEventArgs("", "", true));
            }
        } 

        /// <summary>
        /// Occurs when the Text of the log changes.
        /// </summary>
        public event LogHandler<CombatLog> textHandler = delegate { };

        /// <summary>
        /// Subscribe if you want to get notified about changes to the Log
        /// </summary>
        /// <param name="ilo"></param>
        public void Subscribe(ILogObserver ilo)
        {
            textHandler += new LogHandler<CombatLog>(ilo.logTextChangedEvent);
        }

        /// <summary>
        /// UnSubscribe if you do not want to get notified about changes to the Log
        /// </summary>
        /// <param name="ilo"></param>
        public void UnSubscribe(ILogObserver ilo)
        {
            textHandler -= new LogHandler<CombatLog>(ilo.logTextChangedEvent);
        }
    }
}
