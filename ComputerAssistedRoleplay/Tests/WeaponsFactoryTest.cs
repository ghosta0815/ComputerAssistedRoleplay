using System;
using System.Collections.Generic;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.Weapons.Affliction;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class WeaponsFactoryTest
    {
        WeaponsFactory WeapFab;

        [OneTimeSetUp]
        public void InitWeaponsFactory()
        {
            WeapFab = new WeaponsFactory();
        }

        [TestCase]
        public void FabAvailable()
        {
            Assert.NotNull(WeapFab);
        }

        [TestCase]
        public void ContainsWeapons()
        {
            Assert.GreaterOrEqual(WeapFab.AvailableWeapons.Count, 1);

            TestContext.WriteLine("Available Weapons");
            foreach (string weaponName in WeapFab.AvailableWeapons)
            {
                TestContext.WriteLine(weaponName);
            }

        }

        [TestCase]
        public void AllWeaponsAreValid()
        {
            bool allWeaponsValid = true;

            foreach(string weapID in WeapFab.AvailableWeapons)
            {
                if(WeapFab.getWeapon(weapID) != null)
                {
                    allWeaponsValid = true;
                    TestContext.WriteLine("{0}: {1}", weapID, true);
                }
                else
                {
                    allWeaponsValid = false;
                    TestContext.WriteLine("{0}: {1}", weapID, false);
                }

                Assert.True(allWeaponsValid);
            }
        }

        [TestCase]
        public void WeaponDamageDiceAreValid()
        {
            bool containsAtLeastOneValidDie = false;
            foreach(string weaponName in WeapFab.AvailableWeapons)
            {
                Weapon weapUnderEval = WeapFab.getWeapon(weaponName);
                TestContext.WriteLine(weapUnderEval.Name + " \t- Bash: " + weapUnderEval.BashDamage.ToString() + 
                    " - Pierce: " + weapUnderEval.PierceDamage.ToString() +
                    " - Cut: " + weapUnderEval.CutDamage.ToString());

                if(weapUnderEval.BashDamage.ToString() != "0" 
                    | weapUnderEval.CutDamage.ToString() != "0" 
                    | weapUnderEval.PierceDamage.ToString() != "0")
                {
                    containsAtLeastOneValidDie = true;
                }
            }

            Assert.True(containsAtLeastOneValidDie);
        }
        
        [TestCase]
        public void WeaponAppliesStatusEffects()
        {
            bool containsAtLeastOneEffect = false;

            foreach(string weapID in WeapFab.AvailableWeapons)
            {
                foreach(ICauseAfflictions effect in WeapFab.getWeapon(weapID).Afflictions)
                {
                    if (effect != null)
                    {
                        containsAtLeastOneEffect = true;
                        TestContext.WriteLine("{0}: {1}", weapID, effect.GetType().ToString());
                    }
                }
            }

            Assert.IsTrue(containsAtLeastOneEffect);
        }
    }
}
