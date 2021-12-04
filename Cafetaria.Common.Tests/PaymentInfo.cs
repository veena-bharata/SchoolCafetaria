using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Interfaces;
using Cafetaria.Common.Pages;
using NUnit.Framework;

namespace Cafetaria.Common.Tests
{
    public class PaymentInfo:BaseClass
    {
        private readonly ICommon _Common;
        private readonly IPaymentInfo _PaymentInfo;
        public PaymentInfo() 
        {
            _Common = BaseFactory.GetInstance<ICommon>();
            _PaymentInfo = BaseFactory.GetInstance<IPaymentInfo>();
        }

        [Test]
        public void test()
        {
            _PaymentInfo.ClickOnClosePopUp();
        }
    }
}
