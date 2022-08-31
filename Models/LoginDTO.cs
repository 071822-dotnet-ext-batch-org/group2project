using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LoginDTO
    {
            public LoginDTO(string Email, string Password)
            {
                EmailGrab = Email;
                PasswordSet = Password;
            }
            public string EmailGrab { get; set; }
            public string PasswordSet { get; set; }



        
    }
}
