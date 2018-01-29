using System;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;


namespace ComputerAssistedRoleplay.Model.Character.StatusEffect
{
    class Bleed : IStatusEffect
    {
        private CauseBleed affliction;

        public Bleed(CauseBleed affliction)
        {
            this.affliction = affliction;
        }

        public void ApplyEffect(CharacterSheet cs)
        {
            throw new NotImplementedException();
        }

        public string Description()
        {
            return "Der Charakter blutet";
        }
    }
}
