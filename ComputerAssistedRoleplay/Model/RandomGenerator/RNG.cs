using System;

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
        internal int throwDiceWithSides(int maxEyes)
        {
            if(maxEyes == 0)
            {
                return 0;
            }
            else
            {
                maxEyes = Math.Abs(maxEyes);
                return rand.Next(1, maxEyes + 1);
            }

        }
    }
}
