using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Dtos;
using Cafetaria.Common.Helpers.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Pages
{
   public  class BaseClass
    {
        private readonly IWebDriver Driver;
        private readonly ICommon _Common;
        private readonly LoginDto systemData = TestDataHelper.ReadJsonText<LoginDto>("Login_Data.json");
        public BaseClass()
        {
            Logger.CreateLogFile();
            ExtentReport.InitiateExtentReport();
            Logger.Write("Initial Setup!!");
            _Common = BaseFactory.GetInstance<ICommon>();
           
            Driver = _Common.GetDriver(systemData.Data.Browser);
            _Common.NavigateToUrl(systemData.Data.Url);
           
        }
        [OneTimeTearDown]
        public  void FinalTearDown()
        {
            Driver.Quit();
            // AppliToolsManager.GetAndPublishTestSummary();
            Logger.Write("end of suite execution ");
           // SystemHelper.KillProcess("chromedriver.exe");
            ExtentReport.Extent.Flush();
        }
        [OneTimeSetUp]
        public virtual void SetUp()
        {
            var dateTime = DateTime.Now.ToString();
            var suiteName = TestContext.CurrentContext.Test.ClassName.Split('.').LastOrDefault();
            // AppliToolsManager.InitiateEyesObject();
            // AppliToolsManager.SetBatchInfo(batch);
            Logger.Write("start of suite execution ");
            ExtentReport.CreateExtentTest("Initial set up");
        }
        [SetUp]
        public virtual void TestSetUp()
        {
            var testName = TestContext.CurrentContext.Test.MethodName.Split('.').LastOrDefault();
            var suiteName = TestContext.CurrentContext.Test.ClassName.Split('.').LastOrDefault();
            Logger.Write("start of test execution ");
            Logger.LogInfo("Test Case Name: " + testName);
            ExtentReport.CreateExtentTest(testName);
           // AppliToolsManager.OpenEye(Driver, suiteName, testName);
        }
        [TearDown]
        public  void TestTearDown()
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            _ = " " + TestContext.CurrentContext.Result.StackTrace + " ";
            string errorMessage = TestContext.CurrentContext.Result.Message;
            Logger.LogInfo("status of test case Is: " + status);
            Logger.Write("end of test execution ");
             //string screenShotPath = Driver.GetScreenshot();
              var node = ExtentReport.ExtentTest.CreateNode("Test Status");

            try
            {
                switch (status)
                {
                    case TestStatus.Failed:
                        Logger.LogFail("Test ended with Failure: " + errorMessage );// ExtentReport.CreateScreenCapture(screenShotPath));
                       // node.Fail("Test ended with Failure: " + errorMessage, ExtentReport.CreateScreenCapture(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        Logger.LogSkip("Test Skipped!");
                        node.Skip("Test Skipped!");
                        break;
                    case TestStatus.Inconclusive:
                        break;
                    case TestStatus.Passed:
                       // node.Pass("Test passed", ExtentReport.CreateScreenCapture(screenShotPath));

                        break;
                    case TestStatus.Warning:
                        break;
                    default:
                        Logger.LogPass("Test Passed");
                        //node.Info("Test Info", ExtentReport.CreateScreenCapture(screenShotPath));
                        break;
                }
              //  AppliToolsManager.CloseEye();
              //  Logger.LogInfo("extent report path is: " + EnvironmentManager.ExtentReportPath);
              // node.Info("extent report path is: " + ExtentReportPath);
               // TestContext.AddTestAttachment(EnvironmentManager.ExtentReportPath);
            }
            catch (Exception ex)
            {
                Logger.LogInfo("Some Exception Occured: " + ex.Message + ",Stack Trace: " + ex.StackTrace);
               // node.Info("Some Exception Occured: " + ex.Message + ",Stack Trace: " + ex.StackTrace);
            }
        }

    }
}
