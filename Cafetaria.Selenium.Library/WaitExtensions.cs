using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Selenium.Library
{
    public static class WaitExtensions
    {
        public static TimeSpan GlobalTimeOut { get; } = TimeSpan.FromSeconds(120);


        public static TimeSpan DefaultTimeToWaitForElementToExist = TimeSpan.FromSeconds(5);
        /// <summary>
        /// This extension method waits till the condition provided becomes true
        /// </summary>
        /// <example>
        /// driver.WaitForCondition(() => driver.FindElements(By.ClassName("loading-spinner")).Count == 0);
        /// </example>
        /// <param name="condition">Anonymous function to be passed</param>
        /// <param name="timeout">Timeout value to be passed in format TimeoSpan.FromSeconds(), Default is 120</param>
        public static void WaitForCondition(this IWebDriver _driver, Func<bool> condition, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = GlobalTimeOut;

            WebDriverWait wait = new WebDriverWait(_driver, (TimeSpan)timeout);

            wait.Until<bool>((b) => condition());
        }
        /// <summary>
        /// This extension method waits till the element is clickable
        /// </summary>
        /// <example>
        /// driver.WaitForElementToBeClickable(Button)
        /// </example>
        /// <param name="element">element to wait to be clicked</param>
        /// <param name="timeout">Timeout value to be passed in format TimeoSpan.FromSeconds(), Default is 120</param>
        public static void WaitForElementToBeClickable(this IWebDriver driver, By element, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = GlobalTimeOut;
            WebDriverWait wait = new WebDriverWait(driver, (TimeSpan)timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        /// <summary>
        /// This extension method waits till the element is visible
        /// </summary>
        /// <example>
        /// driver.WaitForElementToBeVisible(Button)
        /// </example>
        /// <param name="element">element to wait to be visible</param>
        /// <param name="timeout">Timeout value to be passed in format TimeoSpan.FromSeconds(), Default is 120</param>
        public static void WaitForElementToBeVisible(this IWebDriver driver, By element, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = GlobalTimeOut;
            WebDriverWait wait = new WebDriverWait(driver, (TimeSpan)timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        /// <summary>
        /// This extension method waits till the element is invisible
        /// </summary>
        /// <example>
        /// driver.WaitForElementToBeInvisible(Button)
        /// </example>
        /// <param name="element">element to wait to be invisible</param>
        /// <param name="timeout">Timeout value to be passed in format TimeoSpan.FromSeconds(), Default is 120</param>
        public static void WaitForElementToBeInvisible(this IWebDriver driver, By element, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = GlobalTimeOut;
            WebDriverWait wait = new WebDriverWait(driver, (TimeSpan)timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(element));
        }
        /// <summary>
        /// This extension method waits till the element is present
        /// </summary>
        /// <example>
        /// driver.WaitForElementToBePresent(Button)
        /// </example>
        /// <param name="element">element to wait to be present</param>
        /// <param name="timeout">Timeout value to be passed in format TimeoSpan.FromSeconds(), Default is 120</param>
        public static void WaitForElementToBePresent(this IWebDriver driver, By element, TimeSpan? timeout = null)
        {
            if (timeout == null)
                timeout = GlobalTimeOut;
            WebDriverWait wait = new WebDriverWait(driver, (TimeSpan)timeout);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
        }
        /// <summary>
        /// This extension method waits till Ionic Loader icon disappears in ExpressPoint app
        /// </summary>
        public static void WaitForLoaderToDisappear(this IWebDriver driver)
        {
            if (driver.IsElementExists(By.ClassName("loading-spinner"), TimeSpan.FromSeconds(2)))
                driver.WaitForCondition(() => driver.FindElements(By.ClassName("loading-spinner")).Count == 0);
        }

    }
}


