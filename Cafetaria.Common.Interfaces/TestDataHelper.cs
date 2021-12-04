using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Helpers
{
    public class TestDataHelper
    {
        public static string QATestData { get; } = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/TestData/";
        public static NUnit.Framework.TestContext? CurrentContext { get; }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static T ReadJsonText<T>(string? dataFile = null) where T : new()
        {
            try
            {
                string input = null;
                //  ProductEnvironment env = EnvironmentManager.PrimeroEdgeEnvironment;
                if (dataFile == null)
                {
                    // dataFile =  "Login_Data.json";

                    dataFile = NUnit.Framework.TestContext.CurrentContext.Test.MethodName.ToString() + "_Data.json";
                };
                string env = "Test";

                switch (env)
                {
                    case "Test":
                        input = File.ReadAllText(QATestData + dataFile).ToString();
                        break;
                    //case ProductEnvironment.Release:
                    //    input = File.ReadAllText(EnvironmentManager.ProdTestData + dataFile).ToString();
                    //    break;
                    //case ProductEnvironment.Staging:
                    //    input = File.ReadAllText(EnvironmentManager.StagingTestData + dataFile).ToString();
                    //    break;
                    default:
                        break;
                }
                //var input = File.ReadAllText(EnvironmentManager.AssemblyPath + dataFile).ToString();
                return DeserializeJSON<T>(input);
            }
            catch (Exception ex)
            {
                // Logger.LogFail("Exception occured while reading Json file!! " + ex.Message);

                return default;
            }
        }

        private static T DeserializeJSON<T>(string input) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
