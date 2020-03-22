using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertDemo
{
    public class Customer
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            Customer otherCustomerObject = obj as Customer;

            if (otherCustomerObject == null)
            {
                return false;
            }

            return this.Name == otherCustomerObject.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

    public class SavingsCustomer : Customer
    { }
}
