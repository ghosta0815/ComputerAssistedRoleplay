using System;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Weapons;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class CharacterSheetTest
    {
        private CharacterChangedEventArgs eventResult;

        [TestCase]
        public void CanRaiseEvent()
        {
            HitzoneFactory testHizonesFab = new HitzoneFactory();
            WeaponsFactory testWeapFab = new WeaponsFactory();
            CharacterSheet testSheet = new CharacterSheet(testHizonesFab.getZonesFor(testHizonesFab.AvailableRaces[0]), testWeapFab.getWeapon(testWeapFab.AvailableWeapons[0]));
            testSheet.charHandler += TestChar_changed;

            //Tbd
        }

        private void TestChar_changed(CharacterSheet sender, CharacterChangedEventArgs e)
        {
            eventResult = e;
        }

    }
}
