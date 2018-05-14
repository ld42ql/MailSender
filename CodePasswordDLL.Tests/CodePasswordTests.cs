using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordDLL;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        [TestMethod]
        public void GetCodPasswordTest()
        {
            // arrange
            string strIn = "abc";
            string strExpected = "bcd";

            // act
            string strActual = Cryptographer.GetCodPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }

        [TestMethod]
        public void GetPasswordTest()
        {
            // arrange
            string strIn = "bcd";
            string strExpected = "abc";

            // act
            string strActual = Cryptographer.GetPassword(strIn);

            //assert
            Assert.AreEqual(strExpected, strActual);
        }
    }
}
