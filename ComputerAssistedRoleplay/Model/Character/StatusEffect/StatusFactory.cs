using System;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Character.StatusEffect;

namespace ComputerAssistedRoleplay.Model.Character.StatusEffect
{
    /// <summary>
    /// Converts afflictions to Statuseffects
    /// </summary>
    internal class StatusFactory
    {
        /// <summary>
        /// Creates a new instance of the status factory
        /// </summary>
        internal StatusFactory()
        {
        }

        /// <summary>
        /// Converts an Affliction to a statuseffect based on the character
        /// </summary>
        /// <param name="affliction">The affliction to convert</param>
        /// <returns>A status effect</returns>
        internal IStatusEffect createStatus(ICauseAfflictions affliction)
        {
            if (affliction.getAfflictionType() == AvailableAfflictions.Bleed)
            {
                return new Bleed((CauseBleed)affliction);
            }
            else if (affliction.getAfflictionType() == AvailableAfflictions.BreakBones)
            {
                return new BrokenBone((CauseBreakBones)affliction);
            }
            else if (affliction.getAfflictionType() == AvailableAfflictions.Unconsciousness)
            {
                return new Unconsciousness((CauseUnconsciousness)affliction);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Unknown affliction to status conversion");
                return null;
            }
        }
    }
}