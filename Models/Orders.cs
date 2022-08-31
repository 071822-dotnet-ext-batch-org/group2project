using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Orders
    {
        public Orders(Guid OrderID, Guid ProductIDFK, Guid AccountIDFK, DateTime OrderDate)
        {
            IDOrder = OrderID;
            FKProduct = ProductIDFK;
            FKAccount = AccountIDFK;
            Date = OrderDate;

        }
        public Guid IDOrder { get; set; }
        public Guid FKProduct { get; set; }
        public Guid FKAccount { get; set; }
        public DateTime Date { get; set; }
    }
}
