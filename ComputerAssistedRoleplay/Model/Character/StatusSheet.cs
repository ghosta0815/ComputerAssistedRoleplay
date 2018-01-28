using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.Character.StatusEffect;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Model.Character
{
    /// <summary>
    /// Delegate for StatuschangedEvents
    /// </summary>
    /// <typeparam name="ILog">Interface to the StatusEvents</typeparam>
    /// <param name="sender">Source of the event</param>
    /// <param name="e">Contains the Event Data</param>
    public delegate void StatusSheetHandler<IStatus>(IStatus sender, StatusChangedEventArgs e);

    /// <summary>
    /// The Event Data of the Log Events
    /// </summary>
    public class StatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Name of the Variable that changed
        /// </summary>
        public string ChangedVariable;
        /// <summary>
        /// Hitpoints of the character
        /// </summary>
        public int HitPoints;
        /// <summary>
        /// Is the character dead?
        /// </summary>
        public bool CharacterIsDead;

        /// <summary>
        /// Creates a new Instance of the StatusChangedEventArgs
        /// </summary>
        /// <param name="logText">The full Text of the Log</param>
        /// <param name="newLog">The new Log entry that was added</param>
        public StatusChangedEventArgs(string changedVariable, int hitPoints, bool characterIsDead)
        {
            ChangedVariable = changedVariable;
            HitPoints = hitPoints;
            CharacterIsDead = characterIsDead;
        }
    }

    /// <summary>
    /// The Interface every observer must Implement if they want to get notified about Status changes
    /// </summary>
    public interface IStatusObserver
    {
        void statusChanged(IStatus status, StatusChangedEventArgs e);
    }

    /// <summary>
    /// Status interface to allow subscription and unsubscription
    /// </summary>
    public interface IStatus
    {
        void Subscribe(IStatusObserver iso);
        void UnSubscribe(IStatusObserver iso);
    }

    /// <summary>
    /// Contains the status of a character
    /// </summary>
    public class StatusSheet : IStatus
    {
        private int _Hitpoints = 100;
        /// <summary>
        /// Returns the Hitpoints of the Character
        /// </summary>
        public int Hitpoints
        {
            get
            {
                return _Hitpoints;
            }
            set
            {
                if (Hitpoints != value)
                {
                    _Hitpoints = value;
                    FireStatusChangedEvent("Hitpoints");
                }
            }
        }

        public int Consciousness { get; set; } = 100;
        public int Pain { get; set; } = 0;
        public int Blood { get; set; } = 100;

        private bool _IsDead = false;
        /// <summary>
        /// Returns true if the Character is dead
        /// </summary>
        public bool IsDead
        {
            get
            {
                return _IsDead;
            }
            set
            {
                if(IsDead != value)
                {
                    _IsDead = value;
                    FireStatusChangedEvent("IsDead");
                }
            }
        }

        public List<IStatusEffect> AppliedEffects = new List<IStatusEffect>();

        private StatusFactory StatusFab;

        public StatusSheet()
        {
            StatusFab = new StatusFactory();
        }

        /// <summary>
        /// Adds all afflictions to the Applied Status Effects;
        /// </summary>
        /// <param name="affliction">The Afflictions that are applied</param>
        internal void AddAfflictions(List<ICauseAfflictions> afflictions)
        {
            foreach (ICauseAfflictions affliction in afflictions)
            {
                AppliedEffects.Add(StatusFab.createStatus(affliction));
            }
        }

        /// <summary>
        /// Deals damage to the character
        /// </summary>
        /// <param name="damage">Amount of Damage</param>
        internal void DealDamage(int damage)
        {
            Hitpoints -= damage;
            if(Hitpoints < 0)
            {
                Hitpoints = 0;
                IsDead = true;
            }
        }

        #region Events
        public event StatusSheetHandler<StatusSheet> statusHandler = delegate { };

        /// <summary>
        /// Fires the Status Changed event
        /// </summary>
        /// <param name="changedVariable"></param>
        public void FireStatusChangedEvent(string changedVariable)
        {
            StatusChangedEventArgs args = new StatusChangedEventArgs(changedVariable, Hitpoints, IsDead);
            statusHandler.Invoke(this, args);
        }

        /// <summary>
        /// Subscribe to the StatusChangedEvent
        /// </summary>
        /// <param name="iso"></param>
        public void Subscribe(IStatusObserver iso)
        {
            statusHandler += new StatusSheetHandler<StatusSheet>(iso.statusChanged);
        }

        /// <summary>
        /// Unsubscribe from the statuschanged event
        /// </summary>
        /// <param name="iso"></param>
        public void UnSubscribe(IStatusObserver iso)
        {
            statusHandler -= new StatusSheetHandler<StatusSheet>(iso.statusChanged);
        }
        #endregion
    }
}
