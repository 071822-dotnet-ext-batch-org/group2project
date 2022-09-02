using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Accounts
    {
        public Accounts(Guid AccountID, string FirstName, string LastName, bool IsAdmin, string Email, string Password, string Address)
        {
            accountID = AccountID;
            firstName = FirstName;
            lastName = LastName;
            isAdmin = IsAdmin;
            email = Email;
            password = Password;
            address = Address; 
        }

        public Guid accountID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isAdmin { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }
}