using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.RandomGenerator;
using NUnit.Framework;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class DiceInterpreterTest
    {
        [TestCase]
        public void diceFormulaRegexValidity()
        {
            DiceInterpreter diceEngine = new DiceInterpreter();

            Dictionary<string, bool> diceFormulaTestStrings = new Dictionary<string, bool>();
            diceFormulaTestStrings.Add("2", true);
            diceFormulaTestStrings.Add("1w6", true);
            diceFormulaTestStrings.Add("3w2+1", true);
            diceFormulaTestStrings.Add("9w4-3", true);
            diceFormulaTestStrings.Add("10w31-20", true);
            diceFormulaTestStrings.Add("123w456+789", true);
            diceFormulaTestStrings.Add("-1w6", false);
            diceFormulaTestStrings.Add("(1w6)", false);
            diceFormulaTestStrings.Add("a", false);
            diceFormulaTestStrings.Add("3w5+2w4", false);
            diceFormulaTestStrings.Add("3w5+", false);

            foreach (string testStr in diceFormulaTestStrings.Keys)
            {
                bool isMatching = diceEngine.isValidDiceFormula(testStr);
                TestContext.WriteLine("Evaluating \t{0} returns \t{1} should be \t{2}", testStr, isMatching, diceFormulaTestStrings[testStr]);

                if (diceFormulaTestStrings[testStr])
                {
                    Assert.True(isMatching);
                }
                else
                {
                    Assert.False(isMatching);
                }
            }
        }

        [TestCase]
        public void diceFormulaDoesNotThrowException()
        {
            DiceInterpreter diceEngine = new DiceInterpreter();

            Dictionary<string, bool> diceFormulaTestStrings = new Dictionary<string, bool>();
            diceFormulaTestStrings.Add("2", true);
            diceFormulaTestStrings.Add("1w6", true);
            diceFormulaTestStrings.Add("3w2+1", true);
            diceFormulaTestStrings.Add("9w4-3", true);
            diceFormulaTestStrings.Add("10w31-20", true);
            diceFormulaTestStrings.Add("123w456+789", true);

            foreach (string testStr in diceFormulaTestStrings.Keys)
            {
                try
                {
                    Dice dice = diceEngine.getDice(testStr);
                    int result = dice.Throw();
                    TestContext.WriteLine("Evaluating \t{0} returns {1}", testStr, result);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message.ToString());
                    return;
                }
            }

            Assert.Pass("No Exception thrown");
        }

        [TestCase]
        public void diceFormulaNumberOfDiceExtract()
        {
            DiceInterpreter diceEngine = new DiceInterpreter();

            Dictionary<string, int> numberOfDice = new Dictionary<string, int>();
            numberOfDice.Add("2", 0);
            numberOfDice.Add("1w6", 1);
            numberOfDice.Add("3w2+1", 3);
            numberOfDice.Add("9w4-3", 9);
            numberOfDice.Add("10w31-20", 10);
            numberOfDice.Add("123w456+789", 123);

            foreach (string testStr in numberOfDice.Keys)
            {
                int extractedDice = diceEngine.GetDiceAmount(testStr);
                TestContext.WriteLine("TestString: \t{0}, Extracted dice: \t{1}, Matches?: \t{2}", testStr, extractedDice, extractedDice == numberOfDice[testStr]);
                Assert.True(extractedDice == numberOfDice[testStr]);
            }
        }

        [TestCase]
        public void diceFormulaNumberOfSidesExtract()
        {
            DiceInterpreter diceEngine = new DiceInterpreter();

            Dictionary<string, int> numberOfSides = new Dictionary<string, int>();
            numberOfSides.Add("2", 0);
            numberOfSides.Add("1w6", 6);
            numberOfSides.Add("3w2+1", 2);
            numberOfSides.Add("9w4-3", 4);
            numberOfSides.Add("10w31-20", 31);
            numberOfSides.Add("123w456+789", 456);

            foreach (string testStr in numberOfSides.Keys)
            {
                int extractedSides = diceEngine.GetDiceSides(testStr);
                TestContext.WriteLine("TestString: \t{0}, Extracted sides: \t{1}, Matches?: \t{2}", testStr, extractedSides, extractedSides == numberOfSides[testStr]);
                Assert.True(extractedSides == numberOfSides[testStr]);
            }
        }

        [TestCase]
        public void diceFormulaAdderExtract()
        {
            DiceInterpreter diceEngine = new DiceInterpreter();

            Dictionary<string, int> adderTests = new Dictionary<string, int>();
            adderTests.Add("2", 2);
            adderTests.Add("1w6", 0);
            adderTests.Add("3w2+1", 1);
            adderTests.Add("9w4-3", -3);
            adderTests.Add("10w31-20", -20);
            adderTests.Add("123w456+789", 789);

            foreach (string testStr in adderTests.Keys)
            {
                int adder = diceEngine.getAdder(testStr);
                TestContext.WriteLine("TestString: \t{0}, Extracted Adder: \t{1}, Matches?: \t{2}", testStr, adder, adder == adderTests[testStr]);
                Assert.True(adder == adderTests[testStr]);
            }
        }
    }
}
