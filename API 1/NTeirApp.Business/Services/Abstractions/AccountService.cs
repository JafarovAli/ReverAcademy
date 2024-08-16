using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NTeirApp.Business.DTOs.AppUserDTO;
using NTeirApp.Business.Helpers;
using NTeirApp.Business.Services.Interfaces;
using NTeirApp.Core.Enums;
using NTierApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTeirApp.Business.Services.Abstractions
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<AppUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<ResponseDTO> LoginAsync(LoginDTO dto)
        {
            var oldUser = await _userManager.FindByEmailAsync(dto.UsernameOrEmail)
                ?? await _userManager.FindByNameAsync(dto.UsernameOrEmail);

            if (oldUser == null)
                throw new Exception("Email address/Username or password is not valid.");

            if (!await _userManager.CheckPasswordAsync(oldUser, dto.Password))
                throw new Exception("Email address/Username or password is not valid.");

            var userRole = await GetUserRoleAsync(oldUser);

            var jwtToken = JWTGenerator.GenerateToken(oldUser, userRole, _configuration);

            return new ResponseDTO
            {
                StatusCode = 200,
                JwtToken = jwtToken,
            };
        }

        public async Task RegisterAysnc(RegisterDTO dto)
        {
            var newUser = new AppUser
            {
                UserName = dto.Username, 
                Email = dto.Email,
                Surname = dto.Surname,
                Name = dto.Name
            };

            await AddRolesToDatabaseAsync();

            IdentityResultChecker(await _userManager.CreateAsync(newUser, dto.Password));
            IdentityResultChecker(await _userManager.AddToRoleAsync(newUser, EUserRole.Admin.ToString()));
        }


        // Supportive Methods
        public void IdentityResultChecker(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return (await _userManager.GetRolesAsync(user)).FirstOrDefault();
        }

        public async Task AddRolesToDatabaseAsync()
        {
            foreach (var item in Enum.GetValues(typeof(EUserRole)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
                }
            }
        }
    }
}
