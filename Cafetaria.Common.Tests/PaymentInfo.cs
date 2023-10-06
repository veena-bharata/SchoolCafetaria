using Cafetaria.Common.Helpers;
using Cafetaria.Common.Helpers.Dtos;
using Cafetaria.Common.Helpers.Interfaces;
using Cafetaria.Common.Pages;
using NUnit.Framework;

namespace Cafetaria.Common.Tests
{
    public class PaymentInfo:BaseClass
    {//testing
        private readonly ICommon _Common;
        private readonly IPaymentInfo _PaymentInfo;
        private readonly LoginDto systemData = TestDataHelper.ReadJsonText<LoginDto>("Login_Data.json");
        public PaymentInfo() : base()
        {         
            _Common = BaseFactory.GetInstance<ICommon>();
            _PaymentInfo = BaseFactory.GetInstance<IPaymentInfo>();
                   }
       public override void SetUp()
        {
            base.SetUp();
        }
        public override void TestSetUp()
        {
            base.TestSetUp();
        }
        [Test]
        public void test()
        {
            _Common.Login("berkeleyparent", "password");
            _PaymentInfo.ClickOnClosePopUp();
        }
        [Test]
        public void test1()
        {
            _PaymentInfo.ClickOnClosePopUp();
        }
    }
}
