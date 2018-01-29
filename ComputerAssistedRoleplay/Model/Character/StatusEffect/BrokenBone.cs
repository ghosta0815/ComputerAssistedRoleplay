using System;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Model.Character.StatusEffect
{
    class BrokenBone : IStatusEffect
    {
        private CauseBreakBones affliction;

        public BrokenBone(CauseBreakBones affliction)
        {
            this.affliction = affliction;
        }

        public void ApplyEffect(CharacterSheet cs)
        {
            throw new NotImplementedException();
        }

        public string Description()
        {
            return "Der Charakter hat gebrochene Knochen";
        }
    }
}
