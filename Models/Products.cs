using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Products
    {
        public Products(Guid ProductID, string ProductName, string ProductColor, int ProductAmount, Decimal ProductPrice, Int16 ProductSize)
        {
            productID = ProductID;
            productName = ProductName;
            productColor = ProductColor;
            productAmount = ProductAmount;
            productPrice = ProductPrice;
            productSize = ProductSize;
        }

        public Guid productID { get; set; }
        public string productName { get; set; }
        public string productColor { get; set; }
        public int productAmount { get; set; }
        public Decimal productPrice { get; set; }
        public Int16 productSize { get; set; }
    }
}
