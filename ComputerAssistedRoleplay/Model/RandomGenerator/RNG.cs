using System;
using System.Text.RegularExpressions;

namespace ComputerAssistedRoleplay.Model.RandomGenerator
{
    /// <summary>
    /// Singleton Random Number Generator Class.
    /// Can throw dice
    /// </summary>
    public sealed class RNG
    {
        /// <summary>
        /// The single instance of RNG
        /// </summary>
        public static RNG Instance { get; } = new RNG();

        /// <summary>
        /// Internal Random Number generator of the Class
        /// </summary>
        private Random rand { get; }

        /// <summary>
        /// Creates the single instance of RNG
        /// </summary>
        private RNG()
        {
            rand = new Random();
        }

        /// <summary>
        /// Returns a random number between 1 and max Eyes
        /// </summary>
        /// <param name="maxEyes">maximum Amount of eyes</param>
        /// <returns>Random number</returns>
        public int throwDiceWithSides(int maxEyes)
        {
            maxEyes = Math.Abs(maxEyes);
            return rand.Next(maxEyes) + 1;
        }

        /// <summary>
        /// Validates if formulaString matches the allowed expression (e.g. 1w6+1)
        /// </summary>
        /// <param name="formulaString">String to test</param>
        /// <returns>True if formulaString is a valid expression</returns>
        public bool isValidDiceFormula(string formulaString)
        {
            Regex dicePattern = new Regex(@"^\d+w\d+[\+-]?\d*$");
            return dicePattern.IsMatch(formulaString);
        }

        #region extract to own class
        /// <summary>
        /// Interprets the formulaString and returns a random number based on the formula
        /// </summary>
        /// <param name="formula">formula to interpret (e.g. 1w6+1)</param>
        /// <returns>Random number in the specified range</returns>
        public int throwDiceWithFormula(string formula)
        {
            int diceAmount = GetDiceAmount(formula);
            int diceSides = GetDiceSides(formula);
            int adder = getAdder(formula);

            int resultSum = 0;
            for (int diceNumber = 1; diceNumber <= diceAmount; diceNumber++)
            {
                resultSum += throwDiceWithSides(diceSides);

            }

            return resultSum + adder;
        }

        public int getAdder(string formula)
        {
            Regex adderRegex = new Regex(@"[\+-]\d*$");
            string adderString = adderRegex.Match(formula).ToString();
            int adder = 0;

            if (adderString != "")
            {
                if (!Int32.TryParse(adderString, out adder))
                    System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to adder.\n", formula);
            }

            return adder;
        }

        public int GetDiceSides(string formula)
        {
            Regex diceRegex = new Regex(@"^\d+w\d+");
            string diceString = diceRegex.Match(formula).ToString();

            int diceSides = 0;
            string diceSidesStr = diceString.Split('w')[1];

            if (!Int32.TryParse(diceSidesStr, out diceSides))
                System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to sides of dice.\n", formula);

            return diceSides;
        }

        public int GetDiceAmount(string formula)
        {
            Regex diceRegex = new Regex(@"^\d+w\d+");
            string diceString = diceRegex.Match(formula).ToString();

            int diceAmount = 0;
            string diceAmountStr = diceString.Split('w')[0];

            if (!Int32.TryParse(diceAmountStr, out diceAmount))
                System.Diagnostics.Debug.WriteLine("Could not parse '{0}' to an amount of dice.\n", formula);

            return diceAmount;
        }
        #endregion
    }
}
