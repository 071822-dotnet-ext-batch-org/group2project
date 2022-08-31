using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegisterAccount
    {
        public RegisterAccount(Guid AccountID, string firstName, string lastName, bool isAdmin, string email, string password)
        {
            accountID = AccountID;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            Email = email;
            Password = password;
        }
        public Guid accountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}