using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Products
    {
        public Products(string ProductName, string ProductColor, int ProductAmount, int ProductPrice)
        {
            productName = ProductName;
            productColor = ProductColor;
            productAmount = ProductAmount;
            productPrice = ProductPrice;
        }

        public string productName { get; set; }
        public string productColor { get; set; }
        public int productAmount { get; set; }
        public int productPrice { get; set; }
    }
}
