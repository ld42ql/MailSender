using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using PasswordDLL;

namespace CodePasswordDLL.Tests
{
    [TestClass]
    public class CodePasswordTests
    {
        private static string strIn;
        private static string strExpected;


        [TestInitialize()]
        public void Initialize()
        {
            Debug.WriteLine("TestMethodInit");
            strIn = "abc";
            strExpected = "bcd";
        }

        [TestCleanup()]
        public void Cleanup()
        {
            Debug.WriteLine("TestMethodCleanup");
        }

        [TestMethod]
        public void GetCodPasswordTest()
        {

            // act
            string strActual = Cryptographer.GetCodPassword(strIn);

            //assert
            AreEqual(strExpected, strActual, "Проверка расшифрования прошла");
            Debug.WriteLine("Проверка расшифрования прошла");
        }

        [TestMethod]
        public void GetPasswordTest()
        {

            // act
            string strActual = Cryptographer.GetPassword(strExpected);

            //assert
           AreEqual(strIn, strActual, "Проверка шифрования прошла");
            Debug.WriteLine("Проверка шифрования прошла");
        }

        [TestMethod]
        public void GetPasswordAndGetCodPasswordTest()
        {
            string strActual = Cryptographer.GetPassword(strIn);
            string strFinish = Cryptographer.GetCodPassword(strActual);

            StringAssert.Contains(strFinish, strIn, "Проверка методов закончена");
        }
    }
}
