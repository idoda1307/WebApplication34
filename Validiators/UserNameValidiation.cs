using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication34.Repositories;

namespace WebApplication34.Validiators
{
    public class UserNameValidiation : ValidationAttribute
    {
        public override bool IsValid(Object userName)
        {
            if (userName != null)
            {
                FindUserRepository use = new FindUserRepository();
                string uName = (string)userName;
                if (use.FindIfUserExist(uName))
                    return true;
            }
            return false;
        }
    }
}