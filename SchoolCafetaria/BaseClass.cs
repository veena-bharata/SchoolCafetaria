using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Dtos;
using Cafetaria.Common.Helpers.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Pages
{
   public class BaseClass
    {
        private readonly IWebDriver Driver;
        private readonly ICommon _Common;
        private readonly LoginDto systemData = TestDataHelper.ReadJsonText<LoginDto>("Login_Data.json");
        public BaseClass()
        {
            _Common = BaseFactory.GetInstance<ICommon>();
            Driver = _Common.GetDriver(systemData.Data.Browser);
            _Common.NavigateToUrl(systemData.Data.Url);
            _Common.Login(systemData.Data.UserName, systemData.Data.Password);
        }
    }
}
