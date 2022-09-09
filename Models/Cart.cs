using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        public Cart(Guid OrderID, Guid FK_ProductID)
        {
            orderID = OrderID;
            FK_productID = FK_ProductID;
        }
        
        public Guid orderID { get; set; }
        public Guid FK_productID { get; set; }