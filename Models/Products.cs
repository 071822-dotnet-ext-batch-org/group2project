using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;
public class Products
{
    public Products(Guid ProductID,  string ProductName, string productcolor, int ProductAmount, Decimal ProductPrice, Int16 Productsize)
    {
        ProductsID = ProductID;
        ProductDye = ProductName;
        TheColor = productcolor;
        TheAmount = ProductAmount;
        ThePrice = ProductPrice;
        TheSize = Productsize;
    }
    public Guid ProductsID { get; set; }
    public string ProductDye { get; set; }
    public string TheColor { get; set; }
    public int TheAmount { get; set; }
    public Decimal ThePrice { get; set; }
    public Int16 TheSize { get; set; }

}
