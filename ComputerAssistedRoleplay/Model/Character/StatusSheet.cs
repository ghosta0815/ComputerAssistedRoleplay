using System;
using System.Linq;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.Character.StatusEffect;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Model.Character
{
    /// <summary>
    /// Contains the status of a character
    /// </summary>
    public class StatusSheet
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
                }
            }
        }

        public List<IStatusEffect> AppliedEffects = new List<IStatusEffect>();

        private StatusFactory StatusFab;

        /// <summary>
        /// Default consturctor of the Statussheet
        /// </summary>
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

        /// <summary>
        /// Overridden toString method to display the status of the character
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string statusSummary = "";
            statusSummary += "Lebenspunkte: " + Hitpoints;
            statusSummary += "\r\nBewusstsein: " + Consciousness;
            statusSummary += "\r\nSchmerz: " + Pain;
            statusSummary += "\r\nBlut: " + Blood;
            statusSummary += "\r\nLebt noch: " + !IsDead;
            statusSummary += "\r\nStatuseffekte:\r\n";

            List<string> statusDescriptions = new List<string>();
            foreach(IStatusEffect effect in AppliedEffects)
            {
                statusDescriptions.Add(effect.Description());
            }

            statusDescriptions = statusDescriptions.Distinct().ToList<string>();

            foreach(string effectDesc in statusDescriptions)
            {
                statusSummary += effectDesc + "\r\n";
            }

            return statusSummary;
        }
    }
}
