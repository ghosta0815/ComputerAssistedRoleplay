using System;
using ComputerAssistedRoleplay.Model.Hitzone;
using ComputerAssistedRoleplay.Model.Weapons;

namespace ComputerAssistedRoleplay.Model.Character
{
    public class CharacterSheet
    {
        public Hitzones Hitzone { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public StatusSheet Status { get; }

        public CharacterSheet(Hitzones hitzone, Weapon defaultWeapon)
        {
            Hitzone = hitzone;
            EquippedWeapon = defaultWeapon;
            Status = new StatusSheet(this);
        }

        /// <summary>
        /// Attacks another Character
        /// </summary>
        /// <param name="enemyCS">The Character to attack</param>
        public void Attack(CharacterSheet enemyCS)
        {
            //Calculate if character hits (something like Attackchance vs agility)
            //Currently we always hit

            SingleHitZone hitBodyPart = enemyCS.Hitzone.randomizeHitzone();
            DamageItem damage = new DamageItem(hitBodyPart);

            damage.Pierce = EquippedWeapon.PierceDamage.Throw() ;
            damage.Cut = EquippedWeapon.CutDamage.Throw();
            damage.Bash = EquippedWeapon.BashDamage.Throw();

            damage.Afflictions.AddRange(EquippedWeapon.Afflictions);

            enemyCS.ProcessHit(damage);
        }

        /// <summary>
        /// Processes a hit by a weapon
        /// </summary>
        /// <param name="affliction">The Damage item that is applied to the character</param>
        public void ProcessHit(DamageItem hit)
        {
            //Substract Hitpoints for Bash
            //Substract Hitpoints for Cut
            //Substract Hitpoints for Pierce
            Status.DealDamage(hit.Bash + hit.Pierce + hit.Cut);
            Status.AddAfflictions(hit.Afflictions);
        }
    }
}
