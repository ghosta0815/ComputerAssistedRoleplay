using System;
using System.Collections.Generic;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.Weapons.StatusEffects;

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
        public void WeaponVariablesInitialized()
        {
            Weapon weap = WeapFab.getWeapon(WeapFab.AvailableWeapons[0]);

            Assert.Multiple(() =>
            {
                Assert.NotZero(weap.BashDamage + weap.CutDamage + weap.PierceDamage);
                Assert.AreNotEqual(weap.Name, "");
            });
        }
        
        [TestCase]
        public void WeaponAppliesStatusEffects()
        {
            bool weaponContainsStatusEffects = false;

            foreach(string weapID in WeapFab.AvailableWeapons)
            {
                foreach(IStatusEffects effect in WeapFab.getWeapon(weapID).StatusEffects)
                {
                    if (effect != null)
                    {
                        weaponContainsStatusEffects = true;
                        TestContext.WriteLine("{0}: {1}", weapID, effect.GetType().ToString());
                    }
                }
            }

            Assert.IsTrue(weaponContainsStatusEffects);
        }
    }
}
