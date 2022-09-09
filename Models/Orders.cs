using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public Orders(Guid OrderID, Guid FK_AccountID, DateTime OrderDate, Int32 OrderAmount, Decimal OrderTotal)
        {
            orderID = OrderID;
            FK_accountID = FK_AccountID;
            orderDate = OrderDate;
            orderAmount = OrderAmount;
            orderTotal = OrderTotal;
        }

        public Guid orderID { get; set; }
        public Guid FK_accountID { get; set; }
        public DateTime orderDate { get; set; }
        public Int32 orderAmount { get; set; }
        public Decimal orderTotal { get; set; }
    }
}
