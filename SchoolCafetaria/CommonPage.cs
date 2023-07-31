using AventStack.ExtentReports;
using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Interfaces;
using Cafetaria.Selenium.Library;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace Cafetaria.Common.Pages
{
    public class CommonPage:ICommon
    {
        IWebDriver _driver = null;
        public IWebDriver GetDriver(string browser)
        {


            try
            {
                string path = System.IO.Path.Combine(
                            Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) ??
                            throw new InvalidOperationException("Drive path is null"));
                switch (browser)
                {
                    case "Chrome":

                        
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--no-sandbox"); // Bypass OS security model, MUST BE THE VERY FIRST OPTION
                        chromeOptions.AddArguments("start-maximized"); // open Browser in maximized mode
                                                                       //chromeOptions.AddArguments("--headless");
                                                                       //chromeOptions.AddArguments("disable-infobars"); // disabling infobars
                                                                       //chromeOptions.AddArguments("--disable-extensions"); // disabling extensions
                                                                       //chromeOptions.AddArguments("--disable-gpu"); // applicable to windows os only
                                                                       //chromeOptions.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
                                                                       //chromeOptions.AddArguments("--window-size=1920,1080");
                                                                       // Allow download in headless mode
                         _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(path), chromeOptions, TimeSpan.FromMinutes(3));
                        //Set Page Load
                        // driver.Manage().Timeouts().PageLoad = 20;

                       // driver.Navigate().GoToUrl("https://qa.perseusedge.com/");

                        break;
                    case "IE":
                        // InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                        //     _driver = new InternetExplorerDriver(ieOptions);
                        break;
                    default:
                        break;
                }
                return _driver;
            }
            catch (Exception ex)
            {
                Console.Write("Warning: Exception has occured: " + ex.Message + ",Stack Trace: " + ex.StackTrace);
                return _driver;
            }
        }
        public void Login(string userName, string passWord)
        {

            bool isLoggedin = false;
            var node =  ExtentReport.ExtentTest.CreateNode("PrimeroEdge LogIn");
            try
            {
                 Logger.LogInfo("Entering User Name: " + userName);
                node.Pass("enterd username");
                _driver.SetInputWithId("username", userName);

                Logger.LogInfo("Entering password: " + passWord);
                _driver.SetInputWithId("password", passWord);
                node.Pass("enterd password", ExtentReport.CreateScreenCapture(_driver.GetScreenshot()));
                Logger.LogInfo("Clicking on Sign In Button ");
                _driver.ClickButton(" Sign in ");
                _driver.WaitForLoaderToDisappear();
                 Logger.LogInfo("Wait for progress bars to disappear");
                //  _driver.WaitForCircularProgressBarToDisappear();
                //  _driver.WaitForLinearProgressBarToDisappear();

                isLoggedin = true;
            }
            catch (Exception ex)
            {
                isLoggedin = false;
                //   Logger.LogFail("Some Exception occured while log in: " + ex.Message + "/n Stack Trace: " + ex.StackTrace, ExtentReport.CreateScreenCapture(_driver.GetScreenshot()));
            }
            Assert.IsTrue(isLoggedin, "User is not able to log in!");
        }

        public void NavigateToUrl(string url)
        {
            {
                try
                {
                    // Logger.Write("Info: Inside NavigateToURL method, Running all tests in Environment: " + EnvironmentManager.PrimeroEdgeEnvironment.ToString());
                    switch (url)
                    {
                        case "Test":
                            //  EnvironmentManager.EnvironmentName = "Test Environment";
                            //  Logger.Write("Info: Navigating to test environment URL: " + EnvironmentManager.TestURL.ToString());
                            _driver.Navigate().GoToUrl("http://schoolcafetest.perseusedge.com/");
                            _driver.WaitForLoaderToDisappear();
                            ExtentReport.CreateExtentTest("Navigating to URL");
                        var node=  ExtentReport.ExtentTest.CreateNode("navigating to url");
                           node.Pass("bn",ExtentReport.CreateScreenCapture(_driver.GetScreenshot()));
                            break;
                        //case ProductEnvironment.Release:
                        //    EnvironmentManager.EnvironmentName = "Release Environment";
                        //    Logger.Write("Info: Navigating to release environment URL: " + EnvironmentManager.ReleaseURL.ToString());
                        //    Driver.Navigate().GoToUrl(EnvironmentManager.ReleaseURL);
                        //    break;
                        //case ProductEnvironment.Staging:
                        //    EnvironmentManager.EnvironmentName = "Staging Environment";
                        //    Logger.Write("Info: Navigating to release environment URL: " + EnvironmentManager.StagingURL.ToString());
                        //    Driver.Navigate().GoToUrl(EnvironmentManager.StagingURL);
                        //    break;
                        default: break;
                    }
                }
                catch (Exception ex)
                {
                    //  Logger.Write("Fail: Some Exception occured! " + ex.Message + ",Stack Trace: " + ex.StackTrace);
                }
            }
        }
    }
}

