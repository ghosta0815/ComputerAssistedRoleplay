using System;

namespace ComputerAssistedRoleplay.Model.RandomGenerator
{
    public sealed class RNG
    {
        public static RNG Instance { get; } = new RNG();
        private Random rand;

        private RNG()
        {
            rand = new Random();
        }

        public int throwDiceWithSides(int maxEyes)
        {
            maxEyes = Math.Abs(maxEyes);
            return rand.Next(maxEyes) + 1;
        }
    }
}
