using OpenQA.Selenium;
using Cafetaria.Common.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafetaria.Common.Helpers.Interfaces;
using Cafetaria.Selenium.Library;
using System;

namespace Cafetaria.Common.Pages
{
    
    
        public class PaymentInfoPage : IPaymentInfo
        {
            private readonly IWebDriver _driver = null;
            public void ClickOnClosePopUp()
            {
            Logger.LogInfo("Inside the method ");
            //    foreach (var windowHandle in _driver.WindowHandles)
            //    {
            //        if (!windowHandle.Equals(_driver.CurrentWindowHandle))
            //        {
            //            _driver.SwitchTo().Window(windowHandle);
            //            break;
            //        }
            //    }
            //    _driver.WaitForElementToBePresent(By.XPath("//span[contains(text(),' Close ')]"));
            //    _driver.ClickButton(" Close ");
            }
        }
    }


