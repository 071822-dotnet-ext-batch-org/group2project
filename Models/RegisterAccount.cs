using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Accounts
    {
        public Accounts(string Email, string Password, string FirstName, string LastName, string Address, bool IsAdmin)
        {
            email = Email;
            password = Password;
            firstName = FirstName;
            lastName = LastName;
            address = Address;
            isAdmin = IsAdmin;
        }

        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public bool isAdmin { get; set; }
    }
}