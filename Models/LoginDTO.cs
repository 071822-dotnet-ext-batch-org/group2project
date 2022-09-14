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
                email = Email;
                password = Password;
            }

            public string email { get; set; }
            public string password { get; set; }
    }
}
