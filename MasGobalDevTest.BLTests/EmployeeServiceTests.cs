using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGobalDevTest.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasGobalDevTest.BL.Tests
{
    [TestClass()]
    public class EmployeeServiceTests
    {
        [TestMethod()]
        public void GetByIdAsyncTest()
        {
            var employeeService = new EmployeeService();
            Assert.Fail();
        }
    }
}