using System;
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
        public int Hitpoints { get; set; } = 100;
        public int Consciousness { get; set; } = 100;
        public int Pain { get; set; } = 0;
        public int Blood { get; set; } = 100;
        public List<IStatusEffect> AppliedEffects = new List<IStatusEffect>();

        private StatusFactory StatusFab;

        public StatusSheet(CharacterSheet character)
        {
            StatusFab = new StatusFactory(character);
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
    }
}
