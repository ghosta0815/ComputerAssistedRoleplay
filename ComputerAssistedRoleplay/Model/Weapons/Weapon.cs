using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.JSON;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;
using ComputerAssistedRoleplay.Model.RandomGenerator;
using ComputerAssistedRoleplay.Model.Misc;

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
        public Dice PierceDamage { get; set; }
    
        /// <summary>
        /// The Bash Damage the weapon is inflicting
        /// </summary>
        public Dice BashDamage { get; set; }

        /// <summary>
        /// The Cutting Damage the weapon is inflicting
        /// </summary>
        public Dice CutDamage { get; set; }

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
        public List<ICauseAfflictions> Afflictions { get; set; } = new List<ICauseAfflictions>();
        #endregion

        /// <summary>
        /// Default Constructor for a weapon object. All Variables must be set manually
        /// </summary>
        public Weapon()
        {
            Name = "Undefined";
            PierceDamage = new Dice(0, 0, 0);
            BashDamage = new Dice(0, 0, 0);
            CutDamage = new Dice(0, 0, 0);
        }

        /// <summary>
        /// Createas an instance of a Weapon using a JS-Object as initializer
        /// </summary>
        /// <param name="weaponJS">JSON Object to create the Weapon with</param>
        public Weapon(SingleWeaponJS weaponJS)
        {
            DiceInterpreter weaponDamageConverter = new DiceInterpreter();

            Name = weaponJS.Name;
            PierceDamage = weaponDamageConverter.getDice(weaponJS.PierceDamageString);
            BashDamage = weaponDamageConverter.getDice(weaponJS.BashDamageString);
            CutDamage = weaponDamageConverter.getDice(weaponJS.CutDamageString);
            Length = weaponJS.Length;
            Weight = weaponJS.Weight;

            foreach(string effectName in weaponJS.StatusEffects)
            {
                if(effectName == AvailableAfflictions.Bleed.ToString())
                {
                    Afflictions.Add(new CauseBleed());
                }
                else if(effectName == AvailableAfflictions.BreakBones.ToString())
                {
                    Afflictions.Add(new CauseBreakBones());
                }
                else if (effectName == AvailableAfflictions.Unconsciousness.ToString())
                {
                    Afflictions.Add(new CauseUnconsciousness());
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Invalid Status Effect {0} detected", effectName);
                }
            }
        }

        /// <summary>
        /// Inflicts Damage of the Weapon
        /// </summary>
        /// <param name="pierce">Piercing Damage the weapon inflicts</param>
        /// <param name="bash">Bashing Damage the weapon inflicts</param>
        /// <param name="cut">Cutting Damage the weapon inflicts</param>
        internal void InflictDamage(out int pierce, out int bash, out int cut)
        {
            pierce = PierceDamage.Throw();
            bash = BashDamage.Throw();
            cut = CutDamage.Throw();

            CombatLog.getInstance.Append("{0} verursacht {1}/{2}/{3} = {4} Trefferpunkte", Name, pierce, bash, cut, pierce + bash + cut);
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
            desc += "Wuchtschaden: " + BashDamage + "\r\n";
            desc += "Stichschaden: " + PierceDamage + "\r\n";
            desc += "Gewicht: " + Weight + " g\r\n";
            desc += "Länge: " + Length + " cm\r\n";
            desc += "Waffenreichweite: " + AttackRange + " cm\r\n";
            foreach(ICauseAfflictions affliciton in Afflictions)
            {
                desc += affliciton.effectDesc() + "\r\n";
            }

            return desc;
        }
    }
}
