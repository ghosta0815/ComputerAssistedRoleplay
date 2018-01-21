using System;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Model.Weapons.Affliction
{
    /// <summary>
    /// Interface for creating weapon status effects
    /// </summary>
    public interface ICauseAfflictions
    {
        /// <summary>
        /// Applies a status effect on a character
        /// </summary>
        /// <param name="CS">The character the statuseffect is applied on</param>
        void AddAfflictionTo(DamageItem damageItem);

        /// <summary>
        /// Returns a Description of the Statuseffect
        /// </summary>
        /// <returns>Description</returns>
        string effectDesc();

        /// <summary>
        /// Returns the Type of affliction
        /// </summary>
        /// <returns></returns>
        AvailableAfflictions getAfflictionType();
    }

    /// <summary>
    /// Available Statuseffects
    /// </summary>
    public enum AvailableAfflictions
    {
        Bleed,
        Unconsciousness,
        BreakBones
    }
}
