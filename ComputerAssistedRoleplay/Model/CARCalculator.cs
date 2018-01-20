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
        public DiceInterpreter DiceEngine { get; set; }

        public CharacterSheet PlayerCharacter { get; }
        public int Round { get; set; }

        /// <summary>
        /// Provides the combat log of the Model to the outer world (e.g. the controller)
        /// </summary>
        public CombatLog Log { get; set; }

        #region Constructors
        public CARCalculator()
        {
            Log = CombatLog.getInstance;
            HitFab = new HitzoneFactory();
            WeapFab = new WeaponsFactory();
            DiceEngine = new DiceInterpreter();

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

        public int throwDiceByFormula(string diceString)
        {
            int thrownNumber = 0;
            if(DiceEngine.isValidDiceFormula(diceString))
            {
                Dice diceToThrow = DiceEngine.getDice(diceString);
                thrownNumber = diceToThrow.Throw();
                Log.Append("Es fallen " + thrownNumber + " Augen auf " + diceString);
            }
            else
            {
                Log.Append("Ungültige Formel");
            }
            return thrownNumber;
        }
        #endregion
    }
}
