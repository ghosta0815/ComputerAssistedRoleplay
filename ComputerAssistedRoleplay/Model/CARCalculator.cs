using System;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Model
{
    public class CARCalculator
    {
        public HitzoneFactory HitFab { get; set; }
        private Random Rand { get; set; }

        public CharacterSheet PlayerCharacter { get; }
        public int Round { get; set; }

        public Logging.Log CombatLog { get; set; }

        #region Constructors
        public CARCalculator()
        {
            Rand = new Random();
            CombatLog = new Logging.Log();
            HitFab = new HitzoneFactory(Rand, CombatLog);

            PlayerCharacter = new CharacterSheet(HitFab.getZonesFor(HitFab.AvailableRaces[0]));
            Round = 0;

        }
        #endregion

        #region Methods for Random Numbers
        public int throwDice(int maxPoints)
        {
            return Rand.Next(maxPoints+1);
        }
        #endregion
    }
}
