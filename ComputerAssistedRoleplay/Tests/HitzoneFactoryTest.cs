using System;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class HitzoneFactoryTest
    {
        HitzoneFactory HitFab;

        [OneTimeSetUp]
        public void InitHitzone()
        {
            Random rand = new Random();
            HitFab = new HitzoneFactory();
        }

        [TestCase]
        public void FabAvailable()
        {
            Assert.NotNull(HitFab);
        }

        [TestCase]
        public void ContainsRaces()
        {
            Assert.GreaterOrEqual(HitFab.AvailableRaces.Count, 1);
            TestContext.WriteLine("Available Races:");
            foreach(string raceNames in HitFab.AvailableRaces)
            {
                TestContext.WriteLine(raceNames);
            }
        }

        [TestCase]
        public void HitzonesAvailable()
        {
            Hitzones hitZ = HitFab.getZonesFor(HitFab.AvailableRaces[0]);
            Assert.NotNull(hitZ);
        }

        [TestCase]
        public void HitzoneContainsBodyparts()
        {
            Hitzones hitZ = HitFab.getZonesFor(HitFab.AvailableRaces[0]);
            Assert.GreaterOrEqual(hitZ.Bodyparts.Count,1);
        }

        [TestCase]
        public void ReturnsRandomHitzone()
        {
            Hitzones hitZ = HitFab.getZonesFor(HitFab.AvailableRaces[0]);
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(hitZ.randomizeHitzone());
                Assert.IsNotEmpty(hitZ.randomizeHitzone().ZoneName);
            });
        }

        [TestCase]
        public void RandomHitzoneIsRandom()
        {
            Hitzones hitZ = HitFab.getZonesFor(HitFab.AvailableRaces[0]);

            bool isRand = false;

            for (int i = 0; i < 1000; i++)
            {
                if (hitZ.randomizeHitzone().LastDiceThrow != hitZ.randomizeHitzone().LastDiceThrow)
                {
                    isRand = true;
                    break;
                }
            }

            Assert.IsTrue(isRand);
        }
    }
}
