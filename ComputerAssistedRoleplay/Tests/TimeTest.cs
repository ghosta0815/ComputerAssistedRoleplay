using System;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Misc;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class TimeTest
    {
        [OneTimeSetUp]
        public void Reset()
        {
            CombatTime.getInstance.Reset();
        }

        [TestCase]
        public void TimeIncrementsCorrect()
        {
            TestContext.WriteLine("Time: " + CombatTime.getInstance.ToString() + " Current Time: " + DateTime.Now.ToString("ss.FFF"));
            for (int i = 0; i < 2; i++)
            {
                CombatTime.getInstance.Step();
                TestContext.WriteLine("Time: " + CombatTime.getInstance.ToString() + " Current Time: " + DateTime.Now.ToString("ss.FFF"));
            }
            Assert.AreEqual("0:00.2", CombatTime.getInstance.ToString());
        }

        [TestCase]
        public void ResetToZeroWorks()
        {
            TestContext.WriteLine("Time: " + CombatTime.getInstance.ToString());
            Assert.AreEqual("0:00.0", CombatTime.getInstance.ToString());
        }
    }
}
