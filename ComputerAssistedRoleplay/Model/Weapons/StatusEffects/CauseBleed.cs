using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model.Weapons.StatusEffects
{
    class CauseBleed : IStatusEffects
    {
        public void ApplyEffectOn(CharacterSheet CS)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Description of the Cause Bleed statuseffect
        /// </summary>
        /// <returns></returns>
        public string effectDesc()
        {
            return "Verursacht Blutungen";
        }
    }
}
