using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Model.Character
{
    /// <summary>
    /// Collated Damage and Affliction after a succesful attack.
    /// </summary>
    public class DamageItem
    {
        public int Pierce { get; set; } = 0;
        public int Bash { get; set; } = 0;
        public int Cut { get; set; } = 0;
        SingleHitZone HitBodyPart { get; set; }
        public List<ICauseAfflictions> Afflictions { get; set; } = new List<ICauseAfflictions>();

        /// <summary>
        /// Constructor of the Damageitem
        /// </summary>
        /// <param name="hitBodyPart">Bodypart that got hit</param>
        /// <param name="weaponThatHit">Weapon that hit the Target</param>
        public DamageItem(SingleHitZone hitBodyPart, Weapon weaponThatHit)
        {
            HitBodyPart = hitBodyPart;
            int pierce, bash, cut;
            weaponThatHit.InflictDamage(out pierce, out bash, out cut);
            Pierce = pierce;
            Bash = bash;
            Cut = cut;

            Afflictions.AddRange(weaponThatHit.Afflictions);
        }
    }
}
