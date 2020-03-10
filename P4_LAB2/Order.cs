using System;
using System.Collections.Generic;
using System.Text;

namespace P4_LAB2
{
    class Order
    {
        public int OrderID { get; set;  }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderDetails> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetails>();
        }
    }
}
