using System;
using ComputerAssistedRoleplay.Model.Logging;
using ComputerAssistedRoleplay.Model.Hitzone;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.RandomGenerator;

namespace ComputerAssistedRoleplay.Model
{
    public class CARCalculator
    {
        public HitzoneFactory HitFab { get; set; }
        public WeaponsFactory WeapFab { get; set; }


        public CharacterSheet PlayerCharacter { get; }
        public int Round { get; set; }

        public CombatLog Log { get; set; }

        #region Constructors
        public CARCalculator()
        {
            Log = CombatLog.getInstance;
            HitFab = new HitzoneFactory();
            WeapFab = new WeaponsFactory();

            PlayerCharacter = new CharacterSheet(HitFab.getZonesFor(HitFab.AvailableRaces[0]));
            Round = 0;

        }
        #endregion

        #region Methods for Random Numbers
        public int throwDice(int maxPoints)
        {
            int thrownNumber = RNG.Instance.throwDiceWithSides(maxPoints);
            Log.Append("Es fallen " + thrownNumber + " Augen auf w" + maxPoints);
            return thrownNumber;
        }
        #endregion
    }
}
