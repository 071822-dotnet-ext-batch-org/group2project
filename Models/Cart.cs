using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public Cart(Guid CartID, Guid FK_AccountID, Guid FK_ProductID, string ProductName, string ProductColor, int ProductAmount, Decimal ProductPrice, Int16 ProductSize)
        {
            cartID = CartID;
            FK_accountID = FK_AccountID;
            FK_productID = FK_ProductID;
            productName = ProductName;
            productColor = ProductColor;
            productAmount = ProductAmount;
            productPrice = ProductPrice;
            productSize = ProductSize;
        }
        
        public Guid cartID { get; set; }
        public Guid FK_accountID { get; set; }
        public Guid FK_productID { get; set; }
        public string productName {get; set;}
        public string productColor {get; set;}
        public int productAmount { get; set; }
        public Decimal productPrice { get; set; }
        public Int16 productSize { get; set; }
    }
}
