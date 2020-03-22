using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace AssemblyInitializeAndAssemblyCleanup
{
    [TestClass]
    public class AssemblyInitializeCleanUp
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            MessageBox.Show("AssemblyInitialize");
        }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            MessageBox.Show("ClassInitialize");
        }

        [TestInitialize()]
        public void TestInit()
        {
            MessageBox.Show("TestInitialize");
        }

        [TestCleanup()]
        public void TestCleanupMethod()
        {
            MessageBox.Show("TestCleanup");
        }

        [ClassCleanup()]
        public static void ClassCleanupMethod()
        {
            MessageBox.Show("ClassCleanup");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanupMethod()
        {
            MessageBox.Show("AssemblyCleanup");
        }

        [TestMethod()]
        public void UnitTestMethod()
        {
            MessageBox.Show("TestMethod");
        }
    }
}
