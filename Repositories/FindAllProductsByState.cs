using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication34.Models;

namespace WebApplication34.Repositories
{
    public class FindAllProductsByState
    {
        public IEnumerable<ProductsModel> GetAvailableProducts()
        {
            using (AspProjectEntities asp = new AspProjectEntities())
            {
                var products = (from p in asp.Products
                                where p.State == (int)state.upload
                                select new ProductsModel
                                {
                                    title = p.Title,
                                    price = (long)p.Price,
                                    shortDescription = p.ShortDescription,
                                    longDescription = p.LongDescription,
                                    date = p.Date,
                                    status = (state)p.State,
                                    ID = p.ProductID,
                                    image1 = p.Picture1,
                                    image2 = p.Picture2,
                                    image3 = p.Picture3,
                                    ownerID = (long)p.OwnerID
                                }).ToList();
                return products;
            }
        }

    }
}