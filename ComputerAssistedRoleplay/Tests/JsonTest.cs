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
                System.Diagnostics.Debug.WriteLine(jex.Message.ToString());
                isValidJson = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                isNoOtherExecption = false;
            }

            Assert.True(isValidJson);
            Assert.True(isNoOtherExecption);

        }
        #endregion

    }
}
