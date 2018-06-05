using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class FindUserRepository
    {
        public UsersModel FindUserModelByID(long ID)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var u = (from use in asp.Users
                         where use.UserID == ID
                         select new UsersModel
                         {
                             firstName = use.FirstName,
                             lastName = use.LastName,
                             birthDate = use.BirthDate,
                             email = use.Email,
                             password = use.Password,
                             userName = use.UserName
                         }).SingleOrDefault();
                return u;
            }
        }
        public long FindUserId(string userName)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                long id = asp.Users.Where(u => u.UserName == userName).Select(u => u.UserID).SingleOrDefault();
                return id;
            }
        }
        public UsersModel FindUserModelByUserName(string uName)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                UsersModel user = (from u in asp.Users
                                   where u.UserName == uName
                                   select new UsersModel
                                   {
                                       userName = u.UserName,
                                       password = u.Password,
                                       birthDate = u.BirthDate,
                                       email = u.Email,
                                       firstName = u.FirstName,
                                       lastName = u.LastName
                                   }).SingleOrDefault();
                return user;
            }
        }
        public bool FindIfUserExist(string userName)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                foreach (var user in asp.Users)
                {
                    if (user.UserName == userName)
                        return false;
                }
                return true;
            }
        }
    }
}