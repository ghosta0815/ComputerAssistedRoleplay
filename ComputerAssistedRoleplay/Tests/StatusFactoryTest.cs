using System;
using System.Collections.Generic;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Character.StatusEffect;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class StatusFactoryTest
    {
        [TestCase]
        public void afflictionToStatusConversion()
        {
            StatusFactory statusFab = new StatusFactory();

            Dictionary<ICauseAfflictions, IStatusEffect> testCases = new Dictionary<ICauseAfflictions, IStatusEffect>();
            CauseBleed bleedAffliction = new CauseBleed();
            testCases.Add(bleedAffliction, new Bleed(bleedAffliction));

            CauseBreakBones breakBonesAffliction = new CauseBreakBones();
            testCases.Add(breakBonesAffliction, new BrokenBone(breakBonesAffliction));

            CauseUnconsciousness unconsciousnessAffliction = new CauseUnconsciousness();
            testCases.Add(unconsciousnessAffliction, new Unconsciousness(unconsciousnessAffliction));

            bool allConvertedCorrect = true;
            foreach(ICauseAfflictions testAffliction in testCases.Keys)
            {
                TestContext.Write("Affliction {0}: ", testAffliction.getAfflictionType());
                string constrTypeString = testCases[testAffliction].ToString();
                string factTypeString = statusFab.createStatus(testAffliction).ToString();
                bool hashCodesAreEqual = constrTypeString == factTypeString;
                TestContext.WriteLine("Constr.: {0}, Fact.: {1}, Equal: {2}", constrTypeString, factTypeString, hashCodesAreEqual);

                if (!hashCodesAreEqual)
                    allConvertedCorrect = false;
            }

            Assert.True(allConvertedCorrect);

        }
    }
}
