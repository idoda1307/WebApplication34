using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication34.Repositories
{
    public class LoginRepository
    {
        public User FindUser(string userName, string password)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                foreach (User user in asp.Users)
                {
                    if (user.UserName == userName && user.Password == password)
                        return user;
                }
                return null;
            }
        }
    }
}