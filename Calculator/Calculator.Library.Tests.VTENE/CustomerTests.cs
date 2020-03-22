using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CollectionAssertDemo.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void StringCollectionTest()
        {
            List<String> collection1 = new List<string>();
            collection1.Add("John");
            collection1.Add("Mike");
            collection1.Add("Pam");

            List<String> collection2 = new List<string>();
            collection2.Add("John");
            collection2.Add("Pam");
            collection2.Add("Mike");

            CollectionAssert.AreEqual(collection1, collection2);
        }

        [TestMethod]
        public void IntegerCollectionTest()
        {
            List<int> collection1 = new List<int>();
            collection1.Add(10);
            collection1.Add(20);
            collection1.Add(30);

            List<int> collection2 = new List<int>();
            collection2.Add(10);
            collection2.Add(20);
            collection2.Add(30);

            CollectionAssert.AreEqual(collection1, collection2);
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest()
        {
            List<Customer> collection1 = new List<Customer>();

            collection1.Add(new Customer() { Name = "John" });
            collection1.Add(new Customer() { Name = "Mike" });
            collection1.Add(new Customer() { Name = "Pam" });

            List<Customer> collection2 = new List<Customer>();

            collection2.Add(new Customer() { Name = "John" });
            collection2.Add(new Customer() { Name = "Mike" });
            collection2.Add(new Customer() { Name = "Pam" });

            //CollectionAssert.AreEqual(collection1, collection2, new CustomerComparer());
            CollectionAssert.AreEqual(collection1.Select(x => x.Name).ToList(), collection2.Select(x => x.Name).ToList());
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_AreEqual()
        {
            List<Customer> collection1 = new List<Customer>();

            collection1.Add(new Customer() { Name = "John" });
            collection1.Add(new Customer() { Name = "Mike" });
            collection1.Add(new Customer() { Name = "Pam" });

            List<Customer> collection2 = new List<Customer>();

            collection2.Add(new Customer() { Name = "Mike" });
            collection2.Add(new Customer() { Name = "John" });
            collection2.Add(new Customer() { Name = "Pam" });

            CollectionAssert.AreEqual(collection1, collection2, "Collections {0} and {1} are not equal", "ONE", "TWO" );
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_AreEquivalent()
        {
            List<Customer> collection1 = new List<Customer>();

            collection1.Add(new Customer() { Name = "John" });
            collection1.Add(new Customer() { Name = "Mike" });
            collection1.Add(new Customer() { Name = "Pam" });

            List<Customer> collection2 = new List<Customer>();

            collection2.Add(new Customer() { Name = "Mike" });
            collection2.Add(new Customer() { Name = "John" });
            collection2.Add(new Customer() { Name = "Pam" });

            CollectionAssert.AreEquivalent(collection1, collection2);
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_Contains()
        {
            List<Customer> collection1 = new List<Customer>();

            collection1.Add(new Customer() { Name = "John" });
            collection1.Add(new Customer() { Name = "Mike" });
            collection1.Add(new Customer() { Name = "Pam" });

            CollectionAssert.Contains(collection1, new Customer() { Name = "John" });
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_IsSubsetOf()
        {
            List<Customer> superset = new List<Customer>();

            superset.Add(new Customer() { Name = "John" });
            superset.Add(new Customer() { Name = "Mike" });
            superset.Add(new Customer() { Name = "Pam" });

            List<Customer> subset = new List<Customer>();

            subset.Add(new Customer() { Name = "John" });
            subset.Add(new Customer() { Name = "Mike" });

            CollectionAssert.IsSubsetOf(subset, superset);
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_AllItemsAreUnique()
        {
            List<Customer> collection = new List<Customer>();

            collection.Add(new Customer() { Name = "John" });
            collection.Add(new Customer() { Name = "Mike" });
            collection.Add(new Customer() { Name = "Pam" });
            collection.Add(new Customer() { Name = "Pam" });

            CollectionAssert.AllItemsAreUnique(collection);
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_AllItemsAreNotNull()
        {
            List<Customer> collection = new List<Customer>();

            collection.Add(new Customer() { Name = "John" });
            collection.Add(new Customer() { Name = "Mike" });
            collection.Add(new Customer() { Name = "Pam" });
            collection.Add(null);

            CollectionAssert.AllItemsAreNotNull(collection);
        }

        [TestMethod]
        public void ComplexObjectsCollectionTest_AllItemsAreInstancesOfType()
        {
            List<Customer> collection = new List<Customer>();

            collection.Add(new Customer() { Name = "John" });
            collection.Add(new Customer() { Name = "Mike" });
            collection.Add(new Customer() { Name = "Pam" });
            collection.Add(new SavingsCustomer());

            CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(SavingsCustomer));
        }
    }
}
