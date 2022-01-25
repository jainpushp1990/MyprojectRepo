using System.Web.Mvc;
using Design_Calculator_New.Controllers;
using Design_Calculator_New.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Design_Calculator_New.Entity;
using System.Collections.Generic;

namespace UnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private UserModel userModel;
        private SimpleDBEntities Dbcontext = new SimpleDBEntities();
        private Employee employee;

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Login(userModel) as ViewResult;
            employee = new Employee()
            {
                UserName = "Raj",
                Password = "12345"
            };

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
