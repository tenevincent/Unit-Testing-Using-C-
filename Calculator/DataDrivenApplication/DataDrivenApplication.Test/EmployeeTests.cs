using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataDrivenApplication.Test
{
    [TestClass]
    public class EmployeeTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("UnitTestDataSource")]
        public void DataDrivenEmployeeTest()
        {
            Employee employee = new Employee();
            employee.Name = TestContext.DataRow["Name"].ToString();
            employee.Email = TestContext.DataRow["Email"].ToString();
            Assert.IsNotNull(employee.Name);
            Assert.IsNotNull(employee.Email);
        }



        //[TestMethod]
        //[DataSource("System.Data.SqlClient",
        //            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True", "Employees", DataAccessMethod.Sequential)]
        //public void DataDrivenEmployeeTest()
        //{
        //    Employee employee = new Employee();
        //    employee.Name = TestContext.DataRow["Name"].ToString();
        //    employee.Email = TestContext.DataRow["Email"].ToString();
        //    Assert.IsNotNull(employee.Name);
        //    Assert.IsNotNull(employee.Email);
        //}



        //[TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
        //     "Employees.xml",
        //     "Employee", DataAccessMethod.Sequential)]
        //public void DataDrivenEmployeeTestFromXml()
        //{
        //    Employee employee = new Employee();
        //    employee.Name = TestContext.DataRow["Name"].ToString();
        //    employee.Email = TestContext.DataRow["Email"].ToString();
        //    Assert.IsNotNull(employee.Name);
        //    Assert.IsNotNull(employee.Email);
        //}


        //[TestMethod]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        //            "Employees.csv",
        //            "Employees.csv", DataAccessMethod.Sequential)]
        //public void DataDrivenEmployeeTestFromCSV()
        //{
        //    Employee employee = new Employee();
        //    employee.Name = TestContext.DataRow["Name"].ToString();
        //    employee.Email = TestContext.DataRow["Email"].ToString();
        //    Assert.IsNotNull(employee.Name);
        //    Assert.IsNotNull(employee.Email);
        //}

    }
}
