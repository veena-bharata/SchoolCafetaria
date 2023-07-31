using System;
using System.Collections.Generic;

using NUnit.Framework;
using NUnit.Framework.Interfaces;

using System.Linq;
using OpenQA.Selenium;
using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Interfaces;

namespace Cafetaria.Common.Pages
{
  public  class webbase : ITestBase
    {
        public IWebDriver Driver { get; set; }
        public void FinalTearDown()
        {
            Driver.Quit();
           // AppliToolsManager.GetAndPublishTestSummary();
        }

        public void SetUp()
        {
            var dateTime = DateTime.Now.ToString();
            var suiteName = TestContext.CurrentContext.Test.ClassName.Split('.').LastOrDefault();
          //  AppliToolsManager.InitiateEyesObject();
          //  AppliToolsManager.SetBatchInfo(batch);
        }

        public void TestSetUp()
        {
            var testName = TestContext.CurrentContext.Test.MethodName.Split('.').LastOrDefault();
            var suiteName = TestContext.CurrentContext.Test.ClassName.Split('.').LastOrDefault();

            Logger.LogInfo("Test Case Name: " + testName);
          //  AppliToolsManager.OpenEye(Driver, suiteName, testName);
        }

        public void TestTearDown()
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            _ = " " + TestContext.CurrentContext.Result.StackTrace + " ";
            string errorMessage = TestContext.CurrentContext.Result.Message;
            Logger.LogInfo("status of test case Is: " + status);
          //  string screenShotPath = Driver.GetScreenshot();
           // var node = ExtentReport.ExtentTest.CreateNode("Test Status");

            try
            {
                switch (status)
                {
                    case TestStatus.Failed:
                        Logger.LogFail("Test ended with Failure: " + errorMessage);
                     //   node.Fail("Test ended with Failure: " + errorMessage, ExtentReport.CreateScreenCapture(screenShotPath));
                        break;
                    case TestStatus.Skipped:
                        Logger.LogSkip("Test Skipped!");
                       // node.Skip("Test Skipped!");
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
                       // node.Info("Test Info", ExtentReport.CreateScreenCapture(screenShotPath));
                        break;
                }
               // AppliToolsManager.CloseEye();
                Logger.LogInfo("extent report path is: ");
               // node.Info("extent report path is: " + EnvironmentManager.ExtentReportPath);
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
