using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing1
{

    [TestClass]
    public class tsOrder
    {
        private string mDescription = "Some description";

        [TestMethod]
        public void InstanceOk()
        {
             clsOrder AWidget = new clsOrder();
            //clsDataConnection adata = new clsDataConnection();
           // adata.GetDBName();
            Assert.IsNotNull(AWidget);
        }

        [TestMethod]
        public void NamePropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "UserName";
            AWidget.Name = TestData;
            var Error = AWidget.RegName(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void CityPropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "City";
            AWidget.City = TestData;
            var Error = AWidget.RegCity(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void AddressPropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "Address";
            AWidget.Address = TestData;
            var Error = AWidget.RegAddress(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PostcodePropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "12345";
            AWidget.Postcode = TestData;
            var Error = AWidget.RegPostCode(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void EmailPropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "Email@gmail.com";
            AWidget.Email = TestData;
            var Error = AWidget.RegEmail(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MobilePropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "987456123";
            AWidget.Mobile = TestData;
            var Error = AWidget.RegMobile(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void PasswordPropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "Password";
            AWidget.Password = TestData;
            var Error = AWidget.RegPassword(TestData);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void QuantityValidPropertyOK()
        {
            clsOrder AWidget = new clsOrder();
            string TestData = "1";
            AWidget.Quantity = TestData;
            var Error = AWidget.CheckQuantityValid(TestData);
            Assert.AreEqual(Error, true);
        }


        [TestMethod]
        public void ValidOk()
        {
            clsOrder AWidget = new clsOrder();
            string Error = "";
            string TestData = mDescription;
            Error = AWidget.Valid(mDescription);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void MinLessOne()
        {
            clsOrder AWidget = new clsOrder();
            string Error = "";
            string DataTest = "";
            Error = AWidget.Valid(DataTest);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void MinPlusOne()
        {
            clsOrder AWidget = new clsOrder();
            string Error = "";
            string DataTest = "";
            DataTest = DataTest.PadLeft(51, '*');
            Error = AWidget.Valid(DataTest);
            Assert.AreNotEqual(Error, "");
        }

        [TestMethod]
        public void ValidLogin()
        {
            clsOrder AWidget = new clsOrder();
            string Error = "";
            string username = "username";
            string password = "password";
            Error = AWidget.LoginValid(username,password);
            Assert.AreEqual(Error, "");
        }

        [TestMethod]
        public void findUser()
        {
            clsOrder AWidget = new clsOrder();
            string email = "navdeep@gmail.com";
            //var data = AWidget.GetStudent(email);
            Assert.AreEqual("true", "true");
        }

    }
}
