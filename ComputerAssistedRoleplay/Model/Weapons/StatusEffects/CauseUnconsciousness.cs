using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model.Weapons.StatusEffects
{
    class CauseUnconsciousness : IStatusEffects
    {
        public void ApplyEffectOn(CharacterSheet CS)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Description of the Cause Unconsciousness statuseffect
        /// </summary>
        /// <returns></returns>
        public string effectDesc()
        {
            return "Verursacht Bewusstseinsverlust";
        }
    }
}
