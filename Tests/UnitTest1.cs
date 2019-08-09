using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Base;
using Core.Controllers;
using Core.Models;

namespace Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        [Description("Get a user and verify the values are correct")]
        public void TestMethod1()
        {
            UserController userController = new UserController();
            int statusCode;
            User actualResult = userController.GetUser(Data.UserEndPoint, out statusCode);

            User expectedResult = new User()
            {
                ID = "576166",
                Email = "jcardozo2302@gmail.com",
                Password = null,
                FullName = "jose cardozo",
                TimeZone = "0",
                IsProUser = false,
                DefaultProjectId = 3519558,
                AddItemMoreExpanded = false,
                EditDueDateMoreExpanded = false,
                ListSortType = 0,
                FirstDayOfWeek = 0,
                NewTaskDueDate = -1,
                TimeZoneId = "Pacific Standard Time"
            };

            Assert.AreEqual(statusCode, 200, 
                $"The status code getting as response is {statusCode} and the status code should be 200");
            Assert.AreEqual(actualResult.ID, expectedResult.ID, 
                $"The userID expeted is: {expectedResult.ID} however the userId retrived is: {actualResult.ID}");
            Assert.AreEqual(actualResult.Email, expectedResult.Email,
                $"The Email expeted is: {expectedResult.Email} however the Email retrived is: {actualResult.Email}");
            Assert.AreEqual(actualResult.FullName, expectedResult.FullName,
                $"The Full Name expeted is: {expectedResult.FullName} however the Full Name retrived is: {actualResult.FullName}");
        }
    }
}
