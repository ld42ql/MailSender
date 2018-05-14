using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordDLL;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestMethod]
        public void getCodPassword_abc_bcd()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = Cryptographer.GetCodPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }
    }
}
