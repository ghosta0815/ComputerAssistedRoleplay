using System;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Character.StatusEffect;

namespace ComputerAssistedRoleplay.Model.Weapons.Affliction
{
    class CauseBleed : ICauseAfflictions
    {
        AvailableAfflictions type = AvailableAfflictions.Bleed;

        public void AddAfflictionTo(DamageItem damageItem)
        {
            damageItem.Afflictions.Add(this);
        }

        /// <summary>
        /// Description of the Cause Bleed statuseffect
        /// </summary>
        /// <returns></returns>
        public string effectDesc()
        {
            return "Verursacht Blutungen";
        }

        public AvailableAfflictions getAfflictionType()
        {
            return type;
        }
    }
}
