using Book_Core.Interfaces;
using Book_Core.Models;
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

namespace Book_Infrastructer.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly IConfiguration configuration;

        public AuthRepository(UserManager<Users> userManager, SignInManager<Users> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public Task<string> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<string> LoginAsync(string usersName, string password)
        {
            var user = await userManager.FindByNameAsync(usersName);
            if (user == null)
            {
                return "invalid username or password";
            }
            var result = await signInManager.PasswordSignInAsync(user, password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            return GenerateToken(user); 
        }

        private string GenerateToken(Users users) 
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, users.UserName),
                new Claim(ClaimTypes.Name, users.UserName.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"], 
                claims: claims,
                signingCredentials: cred,
                expires: DateTime.Now.AddMinutes(30)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> RegisterAsync(Users users, string password)
        {
            var result = await userManager.CreateAsync(users, password);
            if (result.Succeeded)
            {
                return "user registered successfully"; 
            }
            var errorMessage = result.Errors.Select(error => error.Description).ToList();
            return string.Join(", ", errorMessage);
        }
    }
}
