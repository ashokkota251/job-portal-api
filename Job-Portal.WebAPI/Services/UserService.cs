using Job_Portal.WebAPI.Entities;
using Job_Portal.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Job_Portal.WebAPI.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Job_Portal.WebAPI.Services
{
    public interface IUserService
    {
        UserDetails Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserDetails Authenticate(string username, string password)
        {
            zab_dataContext _context = new zab_dataContext();
            List<UserLogin> _users = _context.UserLogin.ToList();
            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var Token = tokenHandler.WriteToken(token);

            UserDetails objUserDetails = new UserDetails()
            {
                Id = user.UserId,
                Username = user.UserName,
                Token = Token,
                Role = user.Role
            };
            return objUserDetails;
        }

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public User GetById(int id)
        {
            return null;
        }
    }
}
