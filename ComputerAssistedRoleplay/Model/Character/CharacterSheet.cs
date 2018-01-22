using System;
using ComputerAssistedRoleplay.Model.Hitzone;
using ComputerAssistedRoleplay.Model.Weapons;

namespace ComputerAssistedRoleplay.Model.Character
{
    public class CharacterSheet
    {
        public Hitzones Hitzone { get; set; }
        public Weapon EquippedWeapon { get; set; }
        private StatusSheet Status;

        public CharacterSheet(Hitzones hitzone, Weapon defaultWeapon)
        {
            Hitzone = hitzone;
            EquippedWeapon = defaultWeapon;
            Status = new StatusSheet(this);
        }

        public void Attack(CharacterSheet enemyCS)
        {
            //Calculate if character hits

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
            Status.AddAfflictions(hit.Afflictions);
        }
    }
}
