using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model
{
    public class CARCalculator
    {
        public HitzoneFactory HitFab = new HitzoneFactory();
        private Random rand = new Random();

        public CharacterSheet PlayerCharacter { get; }
        public int Round { get; set; }

        #region Constructors
        public CARCalculator()
        {
            PlayerCharacter = new CharacterSheet(HitFab.getZonesFor(HitFab.AvailableRaces[0]));
            Round = 0;

        }
        #endregion

        #region Methods for Random Numbers
        public int throwDice(int maxPoints)
        {
            return rand.Next(maxPoints+1);
        }
        #endregion
    }
}
