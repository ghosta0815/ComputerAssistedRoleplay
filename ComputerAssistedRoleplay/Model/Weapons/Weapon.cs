using System;
using ComputerAssistedRoleplay.Model.JSON;

namespace ComputerAssistedRoleplay.Model.Weapons
{
    class Weapon
    {
        #region Variables
        public string Name { get; set; } = "";
        public int PierceDamage { get; set; } = 0;
        public int BashDamage { get; set; } = 0;
        public int CutDamage { get; set; } = 0;
        #endregion

        #region Constructors
        public Weapon()
        {
            Name = "Undefined";
            PierceDamage = 0;
            BashDamage = 0;
            CutDamage = 0;
        }
        public Weapon(SingleWeaponJS weaponJS)
        {
            Name = weaponJS.Name;
            PierceDamage = weaponJS.PierceDamage;
            BashDamage = weaponJS.BashDamage;
            CutDamage = weaponJS.CutDamage;

            //To be added: Weaponeffects by Interface
        }
        #endregion
    }
}
