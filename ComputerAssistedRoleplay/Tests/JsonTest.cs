using System;
using System.IO;
using ComputerAssistedRoleplay.Model.JSON;
using NUnit.Framework;
using Newtonsoft.Json;

namespace ProximaB.UnitTests
{
    [TestFixture]
    class JsonTest
    {
        #region HitzonesJS.json
        /// <summary>
        /// Tests if the path in the HitzonesJS directs to a file
        /// </summary>
        [TestCase]
        public void HitzonesJSPathCorrect()
        {
            TestContext.WriteLine(HitzonesJS.HitZoneJSPath);
            Assert.True(File.Exists(HitzonesJS.HitZoneJSPath));
        }

        /// <summary>
        /// Tests if Hitzones is a valid Json file by parsing it;
        /// </summary>
        [TestCase]
        public void HitzonesJSIsValidJson()
        {
            bool isValidJson = true;
            bool isNoOtherExecption = true;
            try
            {
                JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(HitzonesJS.HitZoneJSPath));
            }
            catch (JsonReaderException jex)
            {
                TestContext.WriteLine(jex.Message.ToString());
                isValidJson = false;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine(ex.Message.ToString());
                isNoOtherExecption = false;
            }

            Assert.Multiple(() =>
            {
                Assert.True(isValidJson);
                Assert.True(isNoOtherExecption);
            });


        }
        #endregion

        #region WeaponsJS.json
        /// <summary>
        /// Tests if the path in the WeaponsJS directs to a file
        /// </summary>
        [TestCase]
        public void WeaponsJSPathCorrect()
        {
            TestContext.WriteLine(WeaponsJS.WeaponsJSPath);
            Assert.True(File.Exists(WeaponsJS.WeaponsJSPath));
        }

        /// <summary>
        /// Tests if WeaponsJS is a valid Json file by parsing it;
        /// </summary>
        [TestCase]
        public void WeaponsJSIsValidJson()
        {
            bool isValidJson = true;
            bool isNoOtherExecption = true;
            try
            {
                JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(WeaponsJS.WeaponsJSPath));
            }
            catch (JsonReaderException jex)
            {
                
                TestContext.WriteLine(jex.Message.ToString());
                isValidJson = false;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine(ex.Message.ToString());
                isNoOtherExecption = false;
            }

            Assert.Multiple(() =>
            {
                Assert.True(isValidJson);
                Assert.True(isNoOtherExecption);
            });
        }
        #endregion
    }
}
