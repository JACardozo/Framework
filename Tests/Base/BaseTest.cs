using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.APIManager;
using Utils.Settings;
using Database.DBManager;

namespace Tests.Base
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    [TestClass]
    public class BaseTest
    {
        protected static SQLManager DbClient;
        protected static SettingsData Data;

        [AssemblyInitialize()]
        public static void MyTestInitialize(TestContext testContext)
        {
            SettingsManager.context = testContext;
            Data = SettingsManager.Instance().Data;
            DbClient = new SQLManager(Data.StringConnection);
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
    }
}
