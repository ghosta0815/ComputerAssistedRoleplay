using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.RandomGenerator;
using NUnit.Framework;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class RNGTest
    {
        [TestCase]
        public void upperLowerBoundMatches()
        {

            int diceMaxSides = 4;

            Dictionary<int, bool> numberIsAvailable = new Dictionary<int, bool>();
            for (int i = 1; i <= diceMaxSides; i++)
            {
                numberIsAvailable.Add(i, false);
            }

            for (int i = 0; i < diceMaxSides * 100; i++)
            {
                int thrownDie = RNG.Instance.throwDiceWithSides(diceMaxSides);
                TestContext.WriteLine("Number {0}:\t{1}", i, thrownDie);
                numberIsAvailable[thrownDie] = true;

                if (!numberIsAvailable.ContainsValue(false))
                {
                    Assert.Pass("All values available");
                    return;
                }

                if (thrownDie < 1 || thrownDie > diceMaxSides)
                {
                    Assert.Fail("Number < 1 or > maxSides detected");
                }
            }

            Assert.Fail("Not all Numbers available");
        }

        [TestCase]
        public void ZeroTest()
        {
            Assert.Zero(RNG.Instance.throwDiceWithSides(0));
        }
    }
}
