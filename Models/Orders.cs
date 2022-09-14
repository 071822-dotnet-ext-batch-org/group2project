using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public Orders(int OrderID, int FK_CartID, string FK_Email, string FK_ProductName, int OrderAmount, Decimal Subtotal,  DateTime OrderDate)
        {
            orderID = OrderID;
            FK_cartID = FK_CartID;
            FK_email = FK_Email;
            FK_productName = FK_ProductName;
            orderAmount = OrderAmount;
            subtotal = Subtotal;
            orderDate = OrderDate;
        }

        public int orderID { get; set; }
        public int FK_cartID { get; set; }
        public string FK_email { get; set; }
        public string FK_productName { get; set; }
        public decimal orderAmount { get; set; }
        public Decimal subtotal { get; set; }
        public DateTime orderDate { get; set; }
    }
}
