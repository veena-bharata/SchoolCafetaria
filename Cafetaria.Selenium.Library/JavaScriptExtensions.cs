using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Selenium.Library
{
    public static class JavaxScriptExtensions
    {/// <summary>
     /// This extension method scrolls the element into view, it is being used currentky in ClickELement
     /// </summary>
     /// <param name="element">Locator</param>
        public static void ScrollIntoView(this IWebDriver _driver, IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'start', inline: 'nearest', behavior: 'smooth'});", element);
            //((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,-5);");
        }

        /// <summary>
        /// Scroll to Top of Page
        /// </summary>
        public static void ScrollToTop(this IWebDriver _driver)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0,0);");
        }

        /// <summary>
        /// Scroll to bottom of Page
        /// </summary>
        public static void ScrollToBottom(this IWebDriver _driver)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight);");
        }

    }
}

