using System;
using ComputerAssistedRoleplay.Model.Logging;
using NUnit.Framework;

namespace ComputerAssistedRoleplay.Tests
{
    [TestFixture]
    class LogTest
    {
        string eventString;
         
        /// <summary>
        /// Test if the Log is created and not a null reference
        /// </summary>
        [TestCase]
        public void LogNotNull()
        {
            Assert.IsNotNull(CombatLog.getInstance);
        }

        /// <summary>
        /// Test if text can be added to the Log
        /// </summary>
        [TestCase]
        public void CanAddText()
        {
            string testString = "Hello World";
            CombatLog.getInstance.Append(testString);
            Assert.AreEqual(testString, CombatLog.getInstance.Text.Trim());
        }

        /// <summary>
        /// Test if the Log can be cleared, after Text is added
        /// </summary>
        [TestCase]
        public void CanClearText()
        {
            string testString = "Hello World";
            CombatLog.getInstance.Append(testString);
            CombatLog.getInstance.Clear();
            Assert.AreEqual("", CombatLog.getInstance.Text.Trim());
        }

        /// <summary>
        /// Test if the textChanged Event is fired;
        /// </summary>
        [TestCase]
        public void CanRaiseEvent()
        {
            string testString = "Hello World";

            CombatLog.getInstance.textHandler += TestLog_textChanged;
            CombatLog.getInstance.Append(testString);

            Assert.AreEqual(testString, eventString);
        }

        #region Methods
        /// <summary>
        /// Method that gets called when the Event is fired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestLog_textChanged(CombatLog sender, LogEventArgs e)
        {
            eventString = e.NewLogEntry;
        }
        #endregion
    }
}
