using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.JSON;
using ComputerAssistedRoleplay.Model.Weapons.StatusEffects;

namespace ComputerAssistedRoleplay.Model.Weapons
{
    /// <summary>
    /// A Weapon Object that can inflict Damage and apply status effects
    /// </summary>
    class Weapon
    {
        #region Variables
        /// <summary>
        /// Name of the Weapon
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The Piercing Damage the weapon is inflicting
        /// </summary>
        public int PierceDamage { get; set; } = 0;

        /// <summary>
        /// The Bash Damage the weapon is inflicting
        /// </summary>
        public int BashDamage { get; set; } = 0;

        /// <summary>
        /// The Cutting Damage the weapon is inflicting
        /// </summary>
        public int CutDamage { get; set; } = 0;

        public List<IStatusEffects> StatusEffects { get; set; } = new List<IStatusEffects>();
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor for a weapon object. All Variables must be set manually
        /// </summary>
        public Weapon()
        {
            Name = "Undefined";
            PierceDamage = 0;
            BashDamage = 0;
            CutDamage = 0;
        }

        /// <summary>
        /// Createas an instance of a Weapon using a JS-Object as initializer
        /// </summary>
        /// <param name="weaponJS">JSON Object to create the Weapon with</param>
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
