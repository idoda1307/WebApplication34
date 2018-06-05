using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class FindProductRepository
    {
        public ProductsModel FindProductModelByID(long ID)
        {
            FindUserRepository find = new FindUserRepository();
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var product = (from p in asp.Products
                               where p.ProductID == ID
                               select new ProductsModel
                               {
                                   title = p.Title,
                                   price = p.Price,
                                   shortDescription = p.ShortDescription,
                                   longDescription = p.LongDescription,
                                   date = p.Date,
                                   ownerID = (long)p.OwnerID,
                                   ID = p.ProductID,
                                   image1 = p.Picture1,
                                   image2 = p.Picture2,
                                   image3 = p.Picture3
                               }).SingleOrDefault();
                return product;
            }
        }
    }
}