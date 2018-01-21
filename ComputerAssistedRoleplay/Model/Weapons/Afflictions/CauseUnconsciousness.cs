using System;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Model.Weapons.Affliction
{
    class CauseUnconsciousness : ICauseAfflictions
    {
        AvailableAfflictions Type = AvailableAfflictions.Unconsciousness;
        public void AddAfflictionTo(DamageItem damageItem)
        {
            damageItem.Afflictions.Add(this);
        }

        /// <summary>
        /// Description of the Cause Unconsciousness statuseffect
        /// </summary>
        /// <returns></returns>
        public string effectDesc()
        {
            return "Verursacht Bewusstseinsverlust";
        }

        public AvailableAfflictions getAfflictionType()
        {
            return Type;
        }
    }
}
