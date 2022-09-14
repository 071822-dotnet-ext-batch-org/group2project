using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public Cart(int CartID, string FK_Email, string FK_ProductName, int OrderAmount, Decimal Subtotal)
        {
            cartID = CartID;
            FK_email = FK_Email;
            FK_productName = FK_ProductName;
            orderAmount = OrderAmount;
            subtotal = Subtotal;
        }
        public int cartID { get; set; }
        public string FK_email { get; set; }
        public string FK_productName { get; set; }
        public int orderAmount { get; set; }
        public Decimal subtotal { get; set; }
    }
}
