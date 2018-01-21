using System;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Model.Character.StatusEffect
{
    class Unconsciousness : IStatusEffect
    {
        private CauseUnconsciousness affliction;

        public Unconsciousness(CauseUnconsciousness affliction)
        {
            this.affliction = affliction;
        }

        public void ApplyEffect(CharacterSheet cs)
        {
            throw new NotImplementedException();
        }

        public string Description()
        {
            throw new NotImplementedException();
        }
    }
}
