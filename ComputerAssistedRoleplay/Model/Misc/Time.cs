using System;

namespace ComputerAssistedRoleplay.Model.Misc
{
    /// <summary>
    /// Delegate that handles the Clock event
    /// </summary>
    /// <typeparam name="IClock"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ClockHandler<IClock>(IClock sender, ClockEventArgs e);

    /// <summary>
    /// Interface the Observer must implement to use the Clock
    /// </summary>
    public interface IClockObserver
    {
        void ClockTimeChangedEvent(IClock sender, ClockEventArgs e);
    }

    /// <summary>
    /// Arguments for the Clockevent
    /// </summary>
    public class ClockEventArgs: EventArgs
    {
        /// <summary>
        /// The time string displaying the combat time when the event occured
        /// </summary>
        public string TimeString { get; }
        
        /// <summary>
        /// Create a new instance of ClockEventArgs
        /// </summary>
        /// <param name="timeString">The time string displaying the current Combat timte</param>
        public ClockEventArgs(string timeString)
        {
            TimeString = timeString;
        }
    }

    /// <summary>
    /// Interface that is implemented by the Sender
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Subscribe to the Clockevents
        /// </summary>
        /// <param name="iCO">The Observer that subscribes</param>
        void Subscribe(IClockObserver iCO);

        /// <summary>
        /// Unsubscribe from the Clock event
        /// </summary>
        /// <param name="iCO">The Observer that unsubscribes</param>
        void Unsubscribe(IClockObserver iCO);
    }


    /// <summary>
    /// Manages the Combat Timer
    /// </summary>
    public sealed class CombatTime : IClock
    {
        private static readonly CombatTime _Instance = new CombatTime();

        /// <summary>
        /// Contains the current combat time
        /// </summary>
        private TimeSpan _CombatTime;
        /// <summary>
        /// Returns the current combat time
        /// </summary>
        internal TimeSpan getCombatTime
        {
            get
            {
                return _CombatTime;
            }
        }
        /// <summary>
        /// Sets the current combat time and fires the timeChanged Event
        /// </summary>
        private TimeSpan setCombatTime
        {
            set
            {
                _CombatTime = value;
                lastExecution = DateTime.Now;
                TimeHandler.Invoke(this, new ClockEventArgs(this.ToString()));
            }
        }

        /// <summary>
        /// The last Time the CombatTIme was updated;
        /// </summary>
        private DateTime lastExecution;
        public event ClockHandler<CombatTime> TimeHandler = delegate { };

        /// <summary>
        /// Returns the singleton instance of the Clock
        /// </summary>
        public static CombatTime getInstance
        {
            get
            {
                return _Instance;
            }
        }

        /// <summary>
        /// Singleton Constructor
        /// </summary>
        private CombatTime()
        {
            setCombatTime = new TimeSpan(0);
        }

        /// <summary>
        /// Advances the clock by 100 ms and sets the thread to sleep to advance in realtime
        /// </summary>
        public void Step()
        {
            TimeSpan stepTime = TimeSpan.FromMilliseconds(100);
            setCombatTime = getCombatTime.Add(stepTime);

            TimeSpan timeSinceLastExecution = DateTime.Now.Subtract(lastExecution);
            TimeSpan diffTime = stepTime - timeSinceLastExecution;
            if(diffTime.TotalMilliseconds > 0)
            {
                System.Threading.Thread.Sleep(diffTime);
            }
        }

        /// <summary>
        /// Resets the Clock back to Zero
        /// </summary>
        public void Reset()
        {
            setCombatTime = new TimeSpan(0);
        }

        /// <summary>
        /// Returns the time in the format "g": 50.5
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return getCombatTime.ToString(@"%m\:ss\.f");
        }

        /// <summary>
        /// Subscribe to the ClockEvent
        /// </summary>
        /// <param name="iCO"></param>
        public void Subscribe(IClockObserver iCO)
        {
            TimeHandler += new ClockHandler<CombatTime>(iCO.ClockTimeChangedEvent);
        }

        /// <summary>
        /// Subscribe to the ClockEvent
        /// </summary>
        /// <param name="iCO"></param>
        public void Unsubscribe(IClockObserver iCO)
        {
            TimeHandler -= new ClockHandler<CombatTime>(iCO.ClockTimeChangedEvent);
        }
    }
}
