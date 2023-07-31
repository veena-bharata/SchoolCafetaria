using System;
using System.Collections.Generic;
using System.Text;

namespace Cafetaria.Common.Helpers.Interfaces
{
 public   interface ITestBase
    {
        void FinalTearDown();
        void SetUp();
        void TestSetUp();
        void TestTearDown();
    }
}
