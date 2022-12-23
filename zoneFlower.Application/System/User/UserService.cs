using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using zoneFlower.Data.Entities;
using zoneFlower.Utilities.Exceptions;
using zoneFlower.ViewModel.System.User;

namespace zoneFlower.Application.System.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager,IConfiguration config)
        {
            this._userManager=userManager;
            this._signInManager=signInManager;
            this._roleManager = roleManager;
            this._config = config;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user=await _userManager.FindByNameAsync(request.UserName);
            if (user == null) 
            return null;

            var result =await _signInManager.PasswordSignInAsync(user, request.Password,request.RemeberMe,true);
            if(!result.Succeeded)
            {
                return null;
            }

            var roles=await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
