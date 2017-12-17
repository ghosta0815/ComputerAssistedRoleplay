using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
