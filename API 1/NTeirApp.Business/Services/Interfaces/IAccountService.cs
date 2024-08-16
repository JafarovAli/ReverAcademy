using NTeirApp.Business.DTOs.AppUserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAysnc(RegisterDTO dto);
        Task<ResponseDTO> LoginAsync(LoginDTO dto);
    }
}
