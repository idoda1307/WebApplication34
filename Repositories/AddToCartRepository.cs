using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class AddToCartRepository
    {

        public List<ProductsModel> ProductsInCart(long uID)
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var products = (from p in asp.Products
                                where p.State == (int)state.cart && p.UserID == uID
                                select new ProductsModel
                                {
                                    title = p.Title,
                                    price = p.Price,
                                    shortDescription = p.ShortDescription,
                                    longDescription = p.LongDescription,
                                    image1 = p.Picture1,
                                    image2 = p.Picture2,
                                    image3 = p.Picture3,
                                    date = p.Date,
                                    status = (state)p.State,
                                    ID = p.ProductID,
                                    userID=(long)p.UserID
                                }).ToList();
                return products;
            }
        }
    }
}