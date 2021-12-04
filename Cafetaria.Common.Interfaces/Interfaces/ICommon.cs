using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Helpers.Interfaces
{
    public interface ICommon
    {
        IWebDriver GetDriver(string browser);
        void NavigateToUrl(string url);
        void Login(string userName, string passWord);
    }
}
