using Cafetaria.Common.Helpers.Interfaces;
using Cafetaria.Selenium.Library;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cafetaria.Common.Pages
{
    public class CommonPage:ICommon
    {
        IWebDriver _driver = null;
        public IWebDriver GetDriver(string browser)
        {


            try
            {
                switch (browser)
                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--start-maximized");
                        chromeOptions.AddArguments("no-sandbox");
                        _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromMinutes(3));
                        //Set Page Load
                        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(3);
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
            // ExtentReport.CreateExtentNode("PrimeroEdge LogIn");
            try
            {
                // Logger.LogInfo("Entering User Name: " + uName);
                _driver.SetInputWithId("username", userName);

                // Logger.LogInfo("Entering password: " + pwd);
                _driver.SetInputWithId("password", passWord);

                // Logger.LogInfo("Clicking on Sign In Button ");
                _driver.ClickButton(" Sign in ");
                _driver.WaitForLoaderToDisappear();
                // Logger.LogInfo("Wait for progress bars to disappear");
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

