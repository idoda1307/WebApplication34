using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class AddToDBRepository
    {
        public void AddProduct(Product p)
        {
            using (var db = new AspProjectEntities())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }
        }
        public void AddUser(UsersModel user)
        {
            User newUser = new User()
            {
                FirstName = user.firstName,
                LastName = user.lastName,
                BirthDate = user.birthDate,
                Email = user.email,
                UserName = user.userName,
                Password = user.password
            };
            using (var db = new AspProjectEntities())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}