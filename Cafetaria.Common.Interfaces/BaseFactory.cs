using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cafetaria.Common.Helpers
{
    public class BaseFactory
    {
        public static T GetInstance<T>(params object[] param)
        {
            T obj = default;

            try
            {
                var pageType = from t in Assembly.Load("Cafetaria.Common.Pages").GetTypes()
                               where t.GetInterfaces().Contains(typeof(T))
                               select t;
                obj = (T)Activator.CreateInstance(pageType.SingleOrDefault());
                return obj;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception occured!!" + ex.Message);
                return obj;
            }
        }
    }
}
