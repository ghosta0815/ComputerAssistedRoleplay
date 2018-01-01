using System;


namespace ComputerAssistedRoleplay.Model.Weapons.StatusEffects
{
    /// <summary>
    /// Interface for creating weapon status effects
    /// </summary>
    public interface IStatusEffects
    {
        /// <summary>
        /// Applies a status effect on a character
        /// </summary>
        /// <param name="CS">The character the statuseffect is applied on</param>
        void ApplyEffectOn(CharacterSheet CS);

        /// <summary>
        /// Returns a Description of the Statuseffect
        /// </summary>
        /// <returns>Description</returns>
        string effectDesc();
    }

    /// <summary>
    /// Available Statuseffects
    /// </summary>
    enum AvailableStatusEffets
    {
        Bleed,
        Unconsciousness,
        BreakBones
    }
}
