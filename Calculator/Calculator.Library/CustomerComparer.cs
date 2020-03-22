using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAssertDemo
{
    public class CustomerComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Customer c1 = x as Customer;
            Customer c2 = y as Customer;

            if (c1 == null || c2 == null)
            {
                return -1;
            }

            return c1.Name.CompareTo(c2.Name);
        }
    }
}
