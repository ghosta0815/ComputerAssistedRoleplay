using System;

namespace ComputerAssistedRoleplay.Model.Character.StatusEffect
{
    /// <summary>
    /// Interface for a status effect that is on the character
    /// </summary>
    public interface IStatusEffect
    {
        /// <summary>
        /// Applies the result of a statuseffect on the character 
        /// </summary>
        /// <param name="">The character a statuseffect is applied to</param>
        void ApplyEffect(CharacterSheet cs);

        /// <summary>
        /// Gets a description for a status Effect
        /// </summary>
        /// <returns></returns>
        string Description();
    }
}
