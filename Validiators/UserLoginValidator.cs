using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication34.Models;
using WebApplication34.Repositories;

namespace WebApplication34.Validiators
{
    public class UserLoginValidator : ValidationAttribute
    {
        public override bool IsValid(object user)
        {
            if (user != null)
            {
                UserLogin use = (UserLogin)user;
                LoginRepository log = new LoginRepository();
                if (log.FindUser(use.userName, use.password) != null)
                    return true;
                return false;
            }
            return false;
        }
    }
}