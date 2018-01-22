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
    }
}
