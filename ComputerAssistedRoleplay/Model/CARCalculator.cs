using System;
using ComputerAssistedRoleplay.Model.Misc;
using ComputerAssistedRoleplay.Model.Hitzone;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.RandomGenerator;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Model
{
    public class CARCalculator
    {
        public HitzoneFactory HitFab { get; set; }
        public WeaponsFactory WeapFab { get; set; }
        public DiceInterpreter DiceEngine { get; set; }

        public CharacterSheet PlayerCharacter { get; }
        public CharacterSheet EnemyCharacter { get; }
        public int Round { get; set; }

        /// <summary>
        /// Provides the combat log of the Model to the outer world (e.g. the controller)
        /// </summary>
        public CombatLog Log { get; set; }

        /// <summary>
        /// Povides the Combat Time of the Model to the outer world (e.g. the controller)
        /// </summary>
        public CombatTime Time { get; set; }

        public CARCalculator()
        {
            Log = CombatLog.getInstance;
            Time = CombatTime.getInstance;
            HitFab = new HitzoneFactory();
            WeapFab = new WeaponsFactory();
            DiceEngine = new DiceInterpreter();

            PlayerCharacter = new CharacterSheet(HitFab.getZonesFor(HitFab.AvailableRaces[0]), WeapFab.getWeapon(WeapFab.AvailableWeapons[0]));
            EnemyCharacter = new CharacterSheet(HitFab.getZonesFor(HitFab.AvailableRaces[0]), WeapFab.getWeapon(WeapFab.AvailableWeapons[0]));
            Round = 0;

        }

        public void setPlayerWeapon(string weaponName)
        {
            PlayerCharacter.Weapon = WeapFab.getWeapon(weaponName);
        }

        public void setEnemyWeapon(string weaponName)
        {
            EnemyCharacter.Weapon = WeapFab.getWeapon(weaponName);
        }

        /// <summary>
        /// Throws a single dice
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <returns></returns>
        public int throwDice(int maxPoints)
        {
            Dice dieToThrow = new Dice(1, maxPoints, 0);
            int thrownNumber = dieToThrow.Throw();
            Log.Append("Es fallen " + thrownNumber + " Augen auf w" + maxPoints);

            return thrownNumber;
        }

        /// <summary>
        /// Throws a series of dice, based on a string formula
        /// </summary>
        /// <param name="diceString">Represents a dice string e.g. 1w6+3</param>
        /// <returns>Random number based on the dice string</returns>
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
    }
}
