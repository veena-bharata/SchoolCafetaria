using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Selenium.Library
{
    public static class WebElementExtensions
    {
        public static TimeSpan GlobalTimeOut { get; } = TimeSpan.FromSeconds(120);


        public static TimeSpan DefaultTimeToWaitForElementToExist = TimeSpan.FromSeconds(5);
        /// <summary>
        /// This extension method checks whether a webelement exists or not
        /// </summary>
        /// <param name="by">Locator</param>
        /// <param name="timeOut">Optional parameter to set timeout, Default is 10</param>
        /// <returns>Returns boolean</returns>
        public static bool IsElementExists(this IWebDriver _driver, By by, TimeSpan? timeOut = null)
        {
            bool isPresent = false;
            if (timeOut == null)
                timeOut = DefaultTimeToWaitForElementToExist;
            try
            {
                _driver.WaitForCondition(() => _driver.FindElements(by).Count > 0, timeOut);
                isPresent = true;
            }
            catch (Exception)
            {
                isPresent = false;
            }
            return isPresent;
        }
        /// <summary>
        /// This extension method clicks the element
        /// </summary>
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }
        /// <summary>
        /// This extension method fetches WebElement
        /// </summary>
        /// <param name="by">Locator</param>
        /// <returns>Returns WebElemnet</returns>
        public static IWebElement GetElement(this IWebDriver _driver, By by)
        {
            _driver.WaitForElementToBePresent(by);
            return _driver.FindElements(by).FirstOrDefault();
        }
        /// <summary>
        /// This extension method select all the text and clears it and set the text
        /// </summary>
        /// <param name="value">Value corresponding to the radio option to be selected</param>
        public static void SelectAllClearAndSetText(this IWebDriver driver, By element, string text, bool scroll = false)
        {
            driver.ClickElement(element, scroll);
            Actions a = new Actions(driver);
            a.KeyDown(Keys.Control).SendKeys("a").Build().Perform();
            driver.GetElement(element).SendKeys(Keys.Backspace);
            driver.GetElement(element).SendKeys(text);
        }


        /// <summary>
        /// This extension method clicks the element after scrolling the element in its view
        /// </summary>
        /// <param name="by">Locator</param>
        public static void ClickElement(this IWebDriver _driver, By by, bool scroll = false)
        {
            _driver.WaitForElementToBeClickable(by);
            var element = _driver.GetElement(by);
            if (scroll)
                _driver.ScrollIntoView(element);
            element.Click();
        }
    }
}



