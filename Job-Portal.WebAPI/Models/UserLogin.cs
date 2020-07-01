using System;
using System.Collections.Generic;

namespace Job_Portal.WebAPI.Models
{
    public partial class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
