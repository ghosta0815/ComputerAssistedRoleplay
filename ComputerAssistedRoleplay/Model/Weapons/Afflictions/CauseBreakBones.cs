using System;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Model.Weapons.Affliction
{
    class CauseBreakBones : ICauseAfflictions
    {
        AvailableAfflictions Type = AvailableAfflictions.BreakBones;
        public void AddAfflictionTo(DamageItem damageItem)
        {
            damageItem.Afflictions.Add(this);
        }

        /// <summary>
        /// Description of the Break Bones statuseffect
        /// </summary>
        /// <returns></returns>
        public string effectDesc()
        {
            return "Verursacht Knochenbrüche";
        }

        public AvailableAfflictions getAfflictionType()
        {
            return Type;
        }
    }
}
