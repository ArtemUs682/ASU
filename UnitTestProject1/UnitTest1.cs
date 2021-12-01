using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ASU;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Тесты не проходят, проверял несколько раз правильность написания логики для тестов, всё должно работать.
        //Скорее всего не получается из-за того, что при выполнении тестов невозможно заполнить и/или прочитать Datagrid
        [TestMethod]
        public void TestFunc1()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual(47, window.Testing(0, 6, 2, 2, 7, 2));
        }

        [TestMethod]
        public void TestFunc2()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual(111, window.Testing(1, 9, 4, 0, 3, 5));
        }

        [TestMethod]
        public void TestFunc3()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual(15034, window.Testing(2, 8, 6, 4, 10, 33));
        }

        [TestMethod]
        public void TestFunc4()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual(49252, window.Testing(3, 4, 11, 3, 9, 12));
        }

        [TestMethod]
        public void TestFunc5()
        {
            MainWindow window = new MainWindow();
            Assert.AreEqual(2298132, window.Testing(4, 3, 7, 1, 15, 1));
        }
    }
}
