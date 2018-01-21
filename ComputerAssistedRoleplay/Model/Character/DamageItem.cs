using System;
using System.Collections.Generic;
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

        public DamageItem(SingleHitZone hitBodyPart)
        {
            HitBodyPart = hitBodyPart;
        }
    }
}
