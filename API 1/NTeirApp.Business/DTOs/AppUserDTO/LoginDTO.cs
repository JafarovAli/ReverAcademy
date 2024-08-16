using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.DTOs.AppUserDTO
{
    public class LoginDTO
    {
        public string UsernameOrEmail {  get; set; }
        public string Password { get; set; }
    }
}
