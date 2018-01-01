using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.JSON;
using ComputerAssistedRoleplay.Model.Weapons.StatusEffects;

namespace ComputerAssistedRoleplay.Model.Weapons
{
    /// <summary>
    /// A Weapon Object that can inflict Damage and apply status effects
    /// </summary>
    public class Weapon
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

        /// <summary>
        /// Total weight of the weapon in g
        /// </summary>
        public int Weight { get; set; } = 0;

        /// <summary>
        /// Total length of the weapon in cm including handle
        /// </summary>
        public int Length { get; set; } = 0;

        /// <summary>
        /// Attackrange in cm in which this weapon can be used;
        /// </summary>
        public int AttackRange
        {
            get
            {
                return Length - 15;
            }
        }

        /// <summary>
        /// List of possible statuseffects the weapon can apply
        /// </summary>
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
            Length = weaponJS.Length;
            Weight = weaponJS.Weight;

            foreach(string effectName in weaponJS.StatusEffects)
            {
                if(effectName == AvailableStatusEffets.Bleed.ToString())
                {
                    StatusEffects.Add(new CauseBleed());
                }
                else if(effectName == AvailableStatusEffets.BreakBones.ToString())
                {
                    StatusEffects.Add(new CauseBreakBones());
                }
                else if (effectName == AvailableStatusEffets.Unconsciousness.ToString())
                {
                    StatusEffects.Add(new CauseUnconsciousness());
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid Status Effect {0} detected", effectName);
                }
            }
        }

        /// <summary>
        /// Overrides ToString method for detailed display of the Object
        /// </summary>
        /// <returns>Description of the Object</returns>
        public override string ToString()
        {
            string desc = "";
            desc += "Name: " + Name + "\r\n";
            desc += "Schnittschaden: " + CutDamage + "\r\n";
            desc += "Wuchtschaden:" + BashDamage + "\r\n";
            desc += "Stichschaden:" + PierceDamage + "\r\n";
            desc += "Gewicht: " + Weight + " g\r\n";
            desc += "Länge: " + Length + " cm\r\n";
            desc += "Waffenreichweite: " + AttackRange + " cm\r\n";
            desc += "Statuseffekte:\r\n";
            desc += "\r\n";
            foreach(IStatusEffects stateff in StatusEffects)
            {
                desc += stateff.effectDesc() + "\r\n";
            }

            return desc;
        }
        #endregion
    }
}
