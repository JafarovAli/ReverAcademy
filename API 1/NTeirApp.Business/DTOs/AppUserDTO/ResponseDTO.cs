using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.DTOs.AppUserDTO
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string? JwtToken { get; set; }
    }
}
