using Job_Portal.WebAPI.Models;
using Microsoft.OpenApi.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Job_Portal.WebAPI.Services
{
    public interface IRegistartionService
    {
        int User(UserRegistration objUserRegistration);
    }

    public class RegistartionService : IRegistartionService
    {

        public int User(UserRegistration objUserRegistration)
        {
            using (var db = new zab_dataContext())
            {
                var userLogin = new UserLogin
                {
                    UserName = objUserRegistration.Username,
                    Password = objUserRegistration.Password,
                    Role = objUserRegistration.Role,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                db.UserLogin.Add(userLogin);
                return db.SaveChanges();
            }
        }
    }
}
