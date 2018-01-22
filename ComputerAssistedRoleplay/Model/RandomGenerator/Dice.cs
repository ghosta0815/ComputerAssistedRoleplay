using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model.RandomGenerator
{
    /// <summary>
    /// Class that represents a collection of dice
    /// </summary>
    public class Dice
    {
        int Amount { get; set; } 
        int Sides { get; set; }
        int Adder { get; set; }

        /// <summary>
        /// Constructor of a collection of dice (e.g. 3w5+3)
        /// </summary>
        /// <param name="amount">Amount of Dice</param>
        /// <param name="sides">Amount of sides of the dice</param>
        /// <param name="adder">Gets added after the dice throw</param>
        public Dice(int amount, int sides, int adder)
        {
            Amount = amount;
            Sides = sides;
            Adder = adder;
        }

        /// <summary>
        /// Throws the dice
        /// </summary>
        /// <returns>Randomly generated dice result</returns>
        public int Throw()
        {
            int resultSum = 0;
            for (int diceNumber = 1; diceNumber <= Amount; diceNumber++)
            {
                resultSum += RNG.Instance.throwDiceWithSides(Sides);

            }

            return resultSum + Adder;
        }

        /// <summary>
        /// OVerrides the toString method and returns a string representation of the thrown dice
        /// </summary>
        /// <returns>string of the form 2w5+1</returns>
        public override string ToString()
        {
            string diceString = "";
            if(Amount == 0 || Sides == 0)
            {
                return diceString = Adder.ToString();
            }

            diceString += Amount.ToString() + "w" + Sides.ToString();
            if(Adder != 0 )
            {
                if (Adder > 0 )
                {
                    diceString += "+";
                }
                diceString += Adder.ToString();
            }
            return diceString;
        }
    }
}
