using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Models;
using Utils;
using Tests.Base;
using Core.Controllers;

namespace Tests.Projects
{
    [TestClass]
    public class Projects : BaseTest
    {
        private string projectName;
        private ProjectController projectController;
        Project actualProject;
        int statusCode;

        [TestInitialize]
        public void TestInit()
        {
            projectName = DataGenerator.Name;
            projectController = new ProjectController();
        }

        [TestMethod]
        public void CreateProject()
        {
            Project payLoadProject = new Project()
            {
                Content = projectName,
                Icon = 4
            };

            actualProject = projectController.Post(payLoadProject, Data.ProjectEndPoint, out statusCode);

            Assert.AreEqual(statusCode, 200,
               $"The status code getting as response is {statusCode} and the status code should be 200");
            Assert.AreEqual(payLoadProject.Content, actualProject.Content,
                $"The content should be {payLoadProject.Content}, however the actual content is {actualProject.Content}");
            Assert.AreEqual(payLoadProject.Icon, actualProject.Icon,
                $"The Icon should be {payLoadProject.Icon}, however the actual icon is {actualProject.Icon}");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            projectController.Delete(Data.ProjectByIdEndPoint, actualProject.Id, out statusCode);
        }
    }
}
