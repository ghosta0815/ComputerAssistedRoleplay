using System;
using System.Text.RegularExpressions;

namespace ComputerAssistedRoleplay.Model.RandomGenerator
{
    public class DiceInterpreter
    {
        /// <summary>
        /// Default constructor for the dice intepreter
        /// </summary>
        public DiceInterpreter()
        {

        }

        /// <summary>
        /// Validates if formulaString matches the allowed expression (e.g. 1w6+1)
        /// </summary>
        /// <param name="formulaString">String to test</param>
        /// <returns>True if formulaString is a valid expression</returns>
        public bool isValidDiceFormula(string formulaString)
        {
            Regex dicePattern = new Regex(@"(^\d+w\d+([\+-]?\d)*$|^\d+$)");
            return dicePattern.IsMatch(formulaString);
        }

        /// <summary>
        /// Interprets the formulaString and returns a random number based on the formula
        /// </summary>
        /// <param name="formula">formula to interpret (e.g. 1w6+1)</param>
        /// <returns>Random number in the specified range</returns>
        public Dice getDice(string formula)
        {
            int diceAmount = GetDiceAmount(formula);
            int diceSides = GetDiceSides(formula);
            int adder = getAdder(formula);

            return new Dice(diceAmount, diceSides, adder);
        }

        /// <summary>
        /// Gets the Adder in the Formula (e.g. the 3 in 1w6+3)
        /// </summary>
        /// <param name="formula">String formula to interpret</param>
        /// <returns>What is added to the dicethrow</returns>
        public int getAdder(string formula)
        {
            Regex adderRegex = new Regex(@"([\+-]\d*$|^\d+$)");
            string adderString = adderRegex.Match(formula).ToString();
            int adder = 0;

            if (adderString != "")
            {
                if (!Int32.TryParse(adderString, out adder))
                    System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to adder.\n", formula);
            }

            return adder;
        }

        /// <summary>
        /// Gets the Number of Sides a dice has in the formula to interpret (e.g. the 6 in 1w6+3)
        /// </summary>
        /// <param name="formula">String formula to interpret</param>
        /// <returns>The sides of the dice to throw</returns>
        public int GetDiceSides(string formula)
        {
            Regex diceRegex = new Regex(@"^\d+w\d+");
            string diceString = diceRegex.Match(formula).ToString();

            int diceSides = 0;
            if (diceString == "")
            {
                return diceSides;
            } else
            {
                string diceSidesStr = diceString.Split('w')[1];

                if (!Int32.TryParse(diceSidesStr, out diceSides))
                    System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to sides of dice.\n", formula);

                return diceSides;
            }
        }

        /// <summary>
        /// Gets the Number of dice to throw (e.g. the 1 in 1w6+3)
        /// </summary>
        /// <param name="formula">String formula to interpret</param>
        /// <returns>The number of dice</returns>
        public int GetDiceAmount(string formula)
        {
            Regex diceRegex = new Regex(@"^\d+w\d+");
            string diceString = diceRegex.Match(formula).ToString();

            int diceAmount = 0;
            if(diceString == "")
            {
                return diceAmount;
            }
            else
            {
            string diceAmountStr = diceString.Split('w')[0];

            if (!Int32.TryParse(diceAmountStr, out diceAmount))
                System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to an amount of dice.\n", formula);

            return diceAmount;
            }
        }
    }
}
