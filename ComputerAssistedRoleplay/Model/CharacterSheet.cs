using System;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Model
{
    public class CharacterSheet
    {
        public Hitzones Hitzone { get; set; }

        public CharacterSheet(Hitzones hitzone)
        {
            Hitzone = hitzone;
        }
    }
}
