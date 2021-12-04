using OpenQA.Selenium;

namespace Cafetaria.Selenium.Library
{
   
        public static class ReactComponents
        {
            private static readonly string ButtonPath = "//span[text()='~']";

            private static readonly string InputPathWithId = "//input[@id='~' and contains(@class,'mat-input-element')]";
            /// Set text to input box which has Id and no placeholder
            /// </summary>
            /// <param name="id">id attribute</param>
            /// <param name="text">Text to be set</param>

            public static void SetInputWithId(this IWebDriver driver, string id, string text)
            {
                try
                {
                    //Logger.LogInfo("Updating Input box with id:" + id + " with input text: " + text);
                    By inputBox = By.XPath(InputPathWithId.Replace("~", id));
                    driver.SelectAllClearAndSetText(inputBox, text);
                }
                catch (Exception ex)
                {
                    // Logger.LogFail("Some exception occured while Setting input with Id: <br/> <b>Error: </b>" + ex.Message + "<br/> <b>StackTrace: </b>" + ex.StackTrace,
                    //  ExtentReport.CreateScreenCapture(driver.GetScreenshot()));
                }
            }
            public static void ClickButton(this IWebDriver driver, string label, string parentXpath = null, bool scroll = false)
            {
                try
                {
                    // Logger.LogInfo("Selecting Button with label: " + label);
                    if (parentXpath == null)
                    {
                        By tab = By.XPath(ButtonPath.Replace("~", label));
                        driver.ClickElement(tab, scroll);
                        // Logger.LogInfo("Clicked on Button");
                    }
                    else
                    {
                        By element = By.XPath(parentXpath + ButtonPath.Replace("~", label));
                        driver.ClickElement(element, scroll);
                        //  Logger.LogInfo("Clicked on Button with parent specified");

                    }
                }
                catch (Exception ex)
                {
                    //  Logger.LogFail("Some exception occured while Clicking button: <br/> <b>Error: </b>" + ex.Message + "<br/> <b>StackTrace: </b>" + ex.StackTrace,
                    //   ExtentReport.CreateScreenCapture(driver.GetScreenshot()));
                }

            }
        }
    }
