using System;
using System.Collections.Generic;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.RandomGenerator;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class DiceTest
    {
        [TestCase]
        public void ToStringEvaluatesCorrect()
        {
            Dictionary<List<int>, string> diceNumber = new Dictionary<List<int>,string>();
            diceNumber.Add(new List<int> { 0, 0, 0 }, "0");
            diceNumber.Add(new List<int> { 1, 0, 0 }, "0");
            diceNumber.Add(new List<int> { 0, 6, 0 }, "0");
            diceNumber.Add(new List<int> { 0, 0, 1 }, "1");
            diceNumber.Add(new List<int> { 0, 6, 1 }, "1");
            diceNumber.Add(new List<int> { 1, 0, 1 }, "1");
            diceNumber.Add(new List<int> { 1, 6, 0 }, "1w6");
            diceNumber.Add(new List<int> { 1, 6, 1 }, "1w6+1");
            diceNumber.Add(new List<int> { 1, 6, -1 }, "1w6-1");

            bool faultyFound = false;
            foreach(List<int> testNumber in diceNumber.Keys)
            {
                Dice diceUnderTest = new Dice(testNumber[0], testNumber[1], testNumber[2]);

                TestContext.WriteLine("Test: \"" + diceNumber[testNumber] + "\" - " + testNumber[0] + " - " + testNumber[1] + " - " + testNumber[2]
                    + "\t Dice: " + diceUnderTest.ToString());
                if(diceUnderTest.ToString() != diceNumber[testNumber])
                {
                    faultyFound = true;
                }
            }

            Assert.False(faultyFound);
        }

        [TestCase]
        public void DiceUpperLowerBound()
        {
            //upperLowerBound[Dice,[Lower,Upper]
            Dictionary<Dice, List<int>> upperLowerBound = new Dictionary<Dice, List<int>>();
            upperLowerBound.Add(new Dice(0, 0, 0), new List<int> { 0, 0 });
            upperLowerBound.Add(new Dice(1, 0, 0), new List<int> { 0, 0 });
            upperLowerBound.Add(new Dice(0, 6, 0), new List<int> { 0, 0 });
            upperLowerBound.Add(new Dice(0, 0, 1), new List<int> { 1, 1 });
            upperLowerBound.Add(new Dice(0, 6, 1), new List<int> { 1, 1 });
            upperLowerBound.Add(new Dice(1, 0, 1), new List<int> { 1, 1 });
            upperLowerBound.Add(new Dice(1, 6, 0), new List<int> { 1, 6 });
            upperLowerBound.Add(new Dice(1, 6, 1), new List<int> { 2, 7 });
            upperLowerBound.Add(new Dice(1, 6, -1), new List<int> { 0, 5 });
            upperLowerBound.Add(new Dice(2, 6, 0), new List<int> { 2, 12 });

            Dictionary<Dice, bool> dicePassed = new Dictionary<Dice, bool>();
            foreach(Dice testDie in upperLowerBound.Keys)
            {
                TestContext.WriteLine("\nTesting {0}", testDie.ToString());
                dicePassed.Add(testDie, false);

                Dictionary<int, bool> eyesGotThrown = new Dictionary<int, bool>();
                for(int eyes = upperLowerBound[testDie][0]; eyes <= upperLowerBound[testDie][1]; eyes++)
                {
                    eyesGotThrown.Add(eyes, false);
                }

                int maxTests = 100;
                for (int throwIndex = 0; throwIndex < maxTests; throwIndex++)
                {
                    int thrownEyes = testDie.Throw();
                    TestContext.WriteLine("Throw {0} on {1}\t Result:{2}", throwIndex, testDie.ToString(), thrownEyes);
                    eyesGotThrown[thrownEyes] = true;

                    if (!eyesGotThrown.ContainsValue(false))
                    {
                        dicePassed[testDie] = true;
                        break;
                    }
                }
            }

            TestContext.WriteLine();
            foreach(Dice testDie in dicePassed.Keys)
            {
                TestContext.WriteLine("Dice {0} \t Result: {1}", testDie.ToString(), dicePassed[testDie]);
            }

            if(!dicePassed.ContainsValue(false))
            {
                Assert.Pass("All Dice have passed the test");
            }
            else
            {
                Assert.Fail("Not all Dice have passed the test");
            }

        }
    }
}
