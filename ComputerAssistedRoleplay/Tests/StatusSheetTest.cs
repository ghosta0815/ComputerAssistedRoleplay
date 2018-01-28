using System;
using NUnit.Framework;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class StatusSheetTest
    {
        private StatusChangedEventArgs eventResult;

        [TestCase]
        public void CanRaiseHitpointsEvent()
        {
            StatusSheet testSheet = new StatusSheet();
            testSheet.statusHandler += TestStatus_changed;

            int testHitpoints = 20;
            testSheet.Hitpoints = testHitpoints;

            TestContext.WriteLine("Hitpoints changed to: {0}", testHitpoints);
            TestContext.WriteLine("Feedback from Event: {0}: {1}", eventResult.ChangedVariable, eventResult.HitPoints);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(testHitpoints, eventResult.HitPoints);
                Assert.AreEqual("Hitpoints", eventResult.ChangedVariable);
            });
        }

        [TestCase]
        public void CanRaiseIsDeadEvent()
        {
            StatusSheet testSheet = new StatusSheet();
            testSheet.statusHandler += TestStatus_changed;

            bool testIsDead = true;
            testSheet.IsDead = testIsDead;

            TestContext.WriteLine("Hitpoints changed to: {0}", testIsDead);
            TestContext.WriteLine("Feedback from Event: {0}: {1}", eventResult.ChangedVariable, eventResult.CharacterIsDead);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(testIsDead, eventResult.CharacterIsDead);
                Assert.AreEqual("IsDead", eventResult.ChangedVariable);
            });
        }

        private void TestStatus_changed(StatusSheet sender, StatusChangedEventArgs e)
        {
            eventResult = e;
        }

    }
}
